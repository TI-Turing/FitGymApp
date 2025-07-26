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
using Gymmetry.Domain.DTO.Feed.Request;
using Gymmetry.Repository.Services.Cache;

namespace Gymmetry.Repository.Services
{
    public class FeedRepository : IFeedRepository
    {
        private readonly GymmetryContext _context;
        private readonly IConfiguration _configuration;
        private readonly IRedisCacheService _redisCache;
        private readonly string _redisPrefix = "feed:";

        public FeedRepository(GymmetryContext context, IConfiguration configuration, IRedisCacheService redisCache)
        {
            _context = context;
            _configuration = configuration;
            _redisCache = redisCache;
        }

        public async Task<Feed> AddFeedAsync(Feed feed, byte[]? media = null, string? fileName = null, string? mediaType = null)
        {
            feed.Id = Guid.NewGuid();
            feed.CreatedAt = DateTime.UtcNow;
            feed.IsActive = true;
            feed.IsDeleted = false;

            if (media != null && !string.IsNullOrEmpty(fileName))
            {
                feed.MediaUrl = await UploadFeedMediaAsync(feed.Id, media, fileName, mediaType);
                feed.MediaType = mediaType;
            }

            _context.Feeds.Add(feed);
            await _context.SaveChangesAsync();
            return feed;
        }

        public async Task<bool> UpdateFeedAsync(Feed feed, byte[]? media = null, string? fileName = null, string? mediaType = null)
        {
            var existing = await _context.Feeds.FirstOrDefaultAsync(f => f.Id == feed.Id && f.IsActive && !f.IsDeleted);
            if (existing == null) return false;

            existing.Title = feed.Title ?? existing.Title;
            existing.Description = feed.Description ?? existing.Description;
            existing.UpdatedAt = DateTime.UtcNow;
            if (media != null && !string.IsNullOrEmpty(fileName))
            {
                existing.MediaUrl = await UploadFeedMediaAsync(existing.Id, media, fileName, mediaType);
                existing.MediaType = mediaType;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFeedAsync(Guid feedId)
        {
            var feed = await _context.Feeds.FirstOrDefaultAsync(f => f.Id == feedId && f.IsActive && !f.IsDeleted);
            if (feed == null) return false;
            feed.IsDeleted = true;
            feed.IsActive = false;
            feed.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Feed?> GetFeedByIdAsync(Guid feedId)
        {
            string cacheKey = _redisPrefix + feedId;
            var cached = await _redisCache.GetAsync(cacheKey);
            if (cached != null)
            {
                return System.Text.Json.JsonSerializer.Deserialize<Feed>(cached);
            }
            var feed = await _context.Feeds.FirstOrDefaultAsync(f => f.Id == feedId && f.IsActive && !f.IsDeleted);
            if (feed != null)
            {
                await _redisCache.SetAsync(cacheKey, System.Text.Json.JsonSerializer.Serialize(feed), TimeSpan.FromMinutes(10));
            }
            return feed;
        }

        public async Task<IEnumerable<Feed>> GetFeedsByUserAsync(Guid userId)
        {
            string cacheKey = $"user:feeds:{userId}";
            var cached = await _redisCache.GetAsync(cacheKey);
            if (cached != null)
            {
                return System.Text.Json.JsonSerializer.Deserialize<List<Feed>>(cached);
            }
            var feeds = await _context.Feeds.Where(f => f.UserId == userId && f.IsActive && !f.IsDeleted)
                .OrderByDescending(f => f.CreatedAt).ToListAsync();
            if (feeds.Any())
            {
                await _redisCache.SetAsync(cacheKey, System.Text.Json.JsonSerializer.Serialize(feeds), TimeSpan.FromMinutes(5));
            }
            return feeds;
        }

        public async Task<IEnumerable<Feed>> GetAllFeedsAsync()
        {
            return await _context.Feeds.Where(f => f.IsActive && !f.IsDeleted)
                .OrderByDescending(f => f.CreatedAt).ToListAsync();
        }

        public async Task<string> UploadFeedMediaToBlobAsync(Guid feedId, byte[] media, string? fileName, string? mediaType)
        {
            return await UploadFeedMediaAsync(feedId, media, fileName ?? "media", mediaType);
        }

        private async Task<string> UploadFeedMediaAsync(Guid feedId, byte[] media, string fileName, string? mediaType)
        {
            string connectionString = _configuration["BlobStorage:ConnectionString"] ?? _configuration["AzureWebJobsStorage"];
            string containerName = _configuration["BlobStorage:FeedMediaContainer"] ?? "feed-media";
            string extension = Path.GetExtension(fileName);
            string blobName = $"{feedId}{extension}";

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);
            var blobClient = containerClient.GetBlobClient(blobName);

            using (var ms = new MemoryStream(media))
            {
                await blobClient.UploadAsync(ms, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = mediaType ?? "application/octet-stream" }
                });
            }
            return blobClient.Uri.ToString();
        }

        public async Task<IEnumerable<Feed>> SearchFeedsAsync(SearchFeedRequest request)
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
            return await query.ToListAsync();
        }
    }
}
