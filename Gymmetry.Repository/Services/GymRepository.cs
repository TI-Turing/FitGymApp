using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Gymmetry.Repository.Services
{
    public class GymRepository : IGymRepository
    {
        private readonly GymmetryContext _context;
        private readonly IConfiguration _configuration;

        public GymRepository(GymmetryContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Gym> CreateGymAsync(Gym entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            _context.Gyms.Add(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<Gym?> GetGymByIdAsync(Guid id)
        {
            return await _context.Gyms
                .Include(g => g.GymPlanSelecteds)
                    .ThenInclude(gps => gps.GymPlanSelectedType)
                .FirstOrDefaultAsync(e => e.Id == id && e.IsActive)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Gym>> GetAllGymsAsync()
        {
            return await _context.Gyms.Where(e => e.IsActive).ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateGymAsync(Gym entity)
        {
            var existing = await _context.Gyms.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive).ConfigureAwait(false);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.Entry(existing).Property(x => x.CreatedAt).IsModified = false;
            existing.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteGymAsync(Guid id)
        {
            var entity = await _context.Gyms.FirstOrDefaultAsync(e => e.Id == id && e.IsActive).ConfigureAwait(false);
            if (entity == null) return false;
            entity.IsActive = false;
            entity.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<IEnumerable<Gym>> FindGymsByFieldsAsync(Dictionary<string, object> filters)
        {
            var predicate = BuildPredicate(filters);
            return await _context.Gyms.Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<string> UploadGymLogoAsync(Guid gymId, byte[] image, string? fileName, string? contentType)
        {
            string connectionString = _configuration["BlobStorage:ConnectionString"]
                ?? _configuration["AzureWebJobsStorage"];
            string containerName = "gym-logos";
            string blobName = fileName ?? $"{gymId}_logo.png";

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob).ConfigureAwait(false);
            var blobClient = containerClient.GetBlobClient(blobName);

            using (var ms = new MemoryStream(image))
            {
                await blobClient.UploadAsync(ms, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = contentType ?? "image/png" }
                }).ConfigureAwait(false);
            }
            var url = blobClient.Uri.ToString();

            var gym = await _context.Gyms.FirstOrDefaultAsync(g => g.Id == gymId && g.IsActive).ConfigureAwait(false);
            if (gym != null)
            {
                gym.LogoUrl = url;
                gym.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            return url;
        }

        public async Task<string?> GetLogoFromBlobStorageAsync(Guid gymId)
        {
            string connectionString = _configuration["BlobStorage:ConnectionString"];
            string containerName = "gym-logos";
            string blobName = $"{gymId}_logo.png";

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            if (await blobClient.ExistsAsync().ConfigureAwait(false))
            {
                return blobClient.Uri.ToString();
            }
            return null;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        private static Expression<Func<Gym, bool>> BuildPredicate(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Gym), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Gym.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(Gym).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            return Expression.Lambda<Func<Gym, bool>>(predicate, parameter);
        }
    }
}
