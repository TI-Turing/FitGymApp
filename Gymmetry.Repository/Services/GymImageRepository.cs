using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.GymImage;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Gymmetry.Repository.Services
{
    public class GymImageRepository : IGymImageRepository
    {
        private readonly GymmetryContext _context;
        private readonly IConfiguration _configuration;

        public GymImageRepository(GymmetryContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<GymImage> AddGymImageAsync(AddGymImageRequest request, string imageUrl)
        {
            var entity = new GymImage
            {
                Id = Guid.NewGuid(),
                Url = imageUrl,
                Description = request.Description,
                GymId = request.GymId,
                BranchId = request.BranchId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                Ip = request.Ip
            };
            _context.GymImages.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<GymImage?> GetGymImageByIdAsync(Guid id)
        {
            return await _context.GymImages.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<IEnumerable<GymImage>> GetAllGymImagesAsync()
        {
            return await _context.GymImages.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateGymImageAsync(UpdateGymImageRequest request)
        {
            var entity = await _context.GymImages.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsActive);
            if (entity == null) return false;
            entity.Description = request.Description;
            entity.GymId = request.GymId;
            entity.BranchId = request.BranchId;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Ip = request.Ip;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGymImageAsync(Guid id)
        {
            var entity = await _context.GymImages.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (entity == null) return false;
            entity.IsActive = false;
            entity.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> UploadGymImageToBlobAsync(byte[] image, Guid? gymId, Guid? branchId)
        {
            string connectionString = _configuration["BlobStorage:ConnectionString"] ?? _configuration["AzureWebJobsStorage"];
            string containerName = _configuration["BlobStorage:GymImageContainer"] ?? "gym-images";
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string blobName = $"{gymId ?? Guid.Empty}_{branchId ?? Guid.Empty}_GymImage_{timestamp}.png";

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);
            var blobClient = containerClient.GetBlobClient(blobName);

            using (var ms = new System.IO.MemoryStream(image))
            {
                await blobClient.UploadAsync(ms, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = "image/png" }
                });
            }
            return blobClient.Uri.ToString();
        }
    }
}
