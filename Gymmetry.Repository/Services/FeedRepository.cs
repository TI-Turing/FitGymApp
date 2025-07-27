using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Gymmetry.Domain.DTO.Feed.Request;
using Gymmetry.Repository.Services.Cache;

namespace Gymmetry.Repository.Services
{
    public class FeedRepository : IFeedRepository
    {
        private readonly GymmetryContext _context;
        private readonly IConfiguration _configuration;
        private readonly IRedisCacheService _redisCache;
        private readonly ILogger<FeedRepository> _logger;
        private const string RedisPrefix = "feed:";

        public FeedRepository(GymmetryContext context, IConfiguration configuration, IRedisCacheService redisCache, ILogger<FeedRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Feed> AddFeedAsync(Feed feed, byte[]? media = null, string? fileName = null, string? mediaType = null)
        {
            if (feed == null) throw new ArgumentNullException(nameof(feed));
            try
            {
                feed.Id = Guid.NewGuid();
                feed.CreatedAt = DateTime.UtcNow;
                feed.IsActive = true;
                feed.IsDeleted = false;

                if (media != null && !string.IsNullOrEmpty(fileName))
                {
                    feed.MediaUrl = await UploadFeedMediaAsync(feed.Id, media, fileName, mediaType).ConfigureAwait(false);
                    feed.MediaType = mediaType;
                }

                _context.Feeds.Add(feed);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return feed;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding feed");
                throw;
            }
        }

        public async Task<bool> UpdateFeedAsync(Feed feed, byte[]? media = null, string? fileName = null, string? mediaType = null)
        {
            if (feed == null) throw new ArgumentNullException(nameof(feed));
            try
            {
                var existing = await _context.Feeds.FirstOrDefaultAsync(f => f.Id == feed.Id && f.IsActive && !f.IsDeleted).ConfigureAwait(false);
                if (existing == null) return false;

                existing.Title = feed.Title ?? existing.Title;
                existing.Description = feed.Description ?? existing.Description;
                existing.UpdatedAt = DateTime.UtcNow;
                if (media != null && !string.IsNullOrEmpty(fileName))
                {
                    existing.MediaUrl = await UploadFeedMediaAsync(existing.Id, media, fileName, mediaType).ConfigureAwait(false);
                    existing.MediaType = mediaType;
                }
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating feed");
                throw;
            }
        }

        public async Task<bool> DeleteFeedAsync(Guid feedId)
        {
            try
            {
                var feed = await _context.Feeds.FirstOrDefaultAsync(f => f.Id == feedId && f.IsActive && !f.IsDeleted).ConfigureAwait(false);
                if (feed == null) return false;
                feed.IsDeleted = true;
                feed.IsActive = false;
                feed.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting feed");
                throw;
            }
        }

        public async Task<Feed?> GetFeedByIdAsync(Guid feedId)
        {
            string cacheKey = RedisPrefix + feedId;
            try
            {
                var cached = await _redisCache.GetAsync(cacheKey).ConfigureAwait(false);
                if (cached != null)
                {
                    return System.Text.Json.JsonSerializer.Deserialize<Feed>(cached);
                }
                var feed = await _context.Feeds.FirstOrDefaultAsync(f => f.Id == feedId && f.IsActive && !f.IsDeleted).ConfigureAwait(false);
                if (feed != null)
                {
                    await _redisCache.SetAsync(cacheKey, System.Text.Json.JsonSerializer.Serialize(feed), TimeSpan.FromMinutes(10)).ConfigureAwait(false);
                }
                return feed;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting feed by id {FeedId}", feedId);
                throw;
            }
        }

        public async Task<IEnumerable<Feed>> GetFeedsByUserAsync(Guid userId)
        {
            string cacheKey = $"user:feeds:{userId}";
            try
            {
                var cached = await _redisCache.GetAsync(cacheKey).ConfigureAwait(false);
                if (cached != null)
                {
                    return System.Text.Json.JsonSerializer.Deserialize<List<Feed>>(cached) ?? new List<Feed>();
                }
                var feeds = await _context.Feeds.Where(f => f.UserId == userId && f.IsActive && !f.IsDeleted)
                    .OrderByDescending(f => f.CreatedAt).ToListAsync().ConfigureAwait(false);
                if (feeds.Any())
                {
                    await _redisCache.SetAsync(cacheKey, System.Text.Json.JsonSerializer.Serialize(feeds), TimeSpan.FromMinutes(5)).ConfigureAwait(false);
                }
                return feeds;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting feeds by user {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<Feed>> GetAllFeedsAsync()
        {
            try
            {
                return await _context.Feeds.Where(f => f.IsActive && !f.IsDeleted)
                    .OrderByDescending(f => f.CreatedAt).ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all feeds");
                throw;
            }
        }

        public async Task<string> UploadFeedMediaToBlobAsync(Guid feedId, byte[] media, string? fileName, string? mediaType)
        {
            return await UploadFeedMediaAsync(feedId, media, fileName ?? "media", mediaType).ConfigureAwait(false);
        }

        private async Task<string> UploadFeedMediaAsync(Guid feedId, byte[] media, string fileName, string? mediaType)
        {
            try
            {
                string connectionString = _configuration["BlobStorage:ConnectionString"] ?? _configuration["AzureWebJobsStorage"];
                string containerName = _configuration["BlobStorage:FeedMediaContainer"] ?? "feed-media";
                string extension = Path.GetExtension(fileName);
                string blobName = $"{feedId}{extension}";

                var blobServiceClient = new BlobServiceClient(connectionString);
                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                await containerClient.CreateIfNotExistsAsync(PublicAccessType.None).ConfigureAwait(false);
                var blobClient = containerClient.GetBlobClient(blobName);

                using (var ms = new MemoryStream(media))
                {
                    await blobClient.UploadAsync(ms, new BlobUploadOptions
                    {
                        HttpHeaders = new BlobHttpHeaders { ContentType = mediaType ?? "application/octet-stream" }
                    }).ConfigureAwait(false);
                }
                return blobClient.Uri.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading feed media to blob for FeedId {FeedId}", feedId);
                throw;
            }
        }

        public async Task<IEnumerable<Feed>> SearchFeedsAsync(SearchFeedRequest request)
        {
            try
            {
                var query = _context.Feeds.AsQueryable();
                if (!string.IsNullOrEmpty(request.Title))
                    query = query.Where(f => f.Title.Contains(request.Title));
                if (!string.IsNullOrEmpty(request.Description))
                    query = query.Where(f => f.Description != null && f.Description.Contains(request.Description));
                if (request.UserId.HasValue)
                    query = query.Where(f => f.UserId == request.UserId);
                if (!string.IsNullOrEmpty(request.Hashtag))
                    query = query.Where(f => f.Description != null && f.Description.Contains("#" + request.Hashtag));
                query = query.Where(f => f.IsActive && !f.IsDeleted);
                query = query.OrderByDescending(f => f.CreatedAt);
                if (request.PageNumber > 0 && request.PageSize > 0)
                    query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);
                return await query.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching feeds");
                throw;
            }
        }
    }
}
