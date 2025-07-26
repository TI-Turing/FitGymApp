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

namespace Gymmetry.Repository.Services
{
    public class PostRepository : IPostRepository
    {
        private readonly GymmetryContext _context;
        private readonly IConfiguration _configuration;

        public PostRepository(GymmetryContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Post> AddPostAsync(Post post, byte[]? media = null, string? fileName = null, string? mediaType = null)
        {
            post.Id = Guid.NewGuid();
            post.CreatedAt = DateTime.UtcNow;
            post.IsActive = true;
            post.IsDeleted = false;

            if (media != null && !string.IsNullOrEmpty(fileName))
            {
                post.MediaUrl = await UploadPostMediaAsync(post.Id, media, fileName, mediaType);
                post.MediaType = mediaType;
            }

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> UpdatePostAsync(Post post, byte[]? media = null, string? fileName = null, string? mediaType = null)
        {
            var existing = await _context.Posts.FirstOrDefaultAsync(p => p.Id == post.Id && p.IsActive && !p.IsDeleted);
            if (existing == null) return false;

            existing.Content = post.Content ?? existing.Content;
            existing.UpdatedAt = DateTime.UtcNow;
            if (media != null && !string.IsNullOrEmpty(fileName))
            {
                existing.MediaUrl = await UploadPostMediaAsync(existing.Id, media, fileName, mediaType);
                existing.MediaType = mediaType;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId && p.IsActive && !p.IsDeleted);
            if (post == null) return false;
            post.IsDeleted = true;
            post.IsActive = false;
            post.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Post?> GetPostByIdAsync(Guid postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId && p.IsActive && !p.IsDeleted);
        }

        public async Task<IEnumerable<Post>> GetPostsByUserAsync(Guid userId)
        {
            return await _context.Posts.Where(p => p.UserId == userId && p.IsActive && !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.Where(p => p.IsActive && !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        private async Task<string> UploadPostMediaAsync(Guid postId, byte[] media, string fileName, string? mediaType)
        {
            string connectionString = _configuration["BlobStorage:ConnectionString"] ?? _configuration["AzureWebJobsStorage"];
            string containerName = _configuration["BlobStorage:PostMediaContainer"] ?? "post-media";
            string extension = Path.GetExtension(fileName);
            string blobName = $"{postId}{extension}";

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
    }
}
