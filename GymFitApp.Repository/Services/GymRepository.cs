using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FitGymApp.Repository.Services
{
    public class GymRepository : IGymRepository
    {
        private readonly FitGymAppContext _context;
        private readonly IConfiguration _configuration;

        public GymRepository(FitGymAppContext context, IConfiguration configuration)
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
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Gym?> GetGymByIdAsync(Guid id)
        {
            return await _context.Gyms
                .Include(g => g.GymPlanSelecteds)
                    .ThenInclude(gps => gps.GymPlanSelectedType)
                .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<Gym>> GetAllGymsAsync()
        {
            return await _context.Gyms.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateGymAsync(Gym entity)
        {
            var existing = await _context.Gyms.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Entry(existing).Property(x => x.CreatedAt).IsModified = false;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteGymAsync(Guid id)
        {
            var entity = await _context.Gyms.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Gym>> FindGymsByFieldsAsync(Dictionary<string, object> filters)
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
                var right = Expression.Constant(Convert.ChangeType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<Gym, bool>>(predicate, parameter);
            return await _context.Gyms.Where(lambda).ToListAsync();
        }

        public async Task<string> UploadGymLogoAsync(Guid gymId, byte[] image, string? fileName, string? contentType)
        {
            // Obtener connection string de configuración
            string connectionString = _configuration["BlobStorage:ConnectionString"]
                ?? _configuration["AzureWebJobsStorage"];
            string containerName = "gym-logos";
            string blobName = fileName ?? $"{gymId}_logo.png";

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
            var blobClient = containerClient.GetBlobClient(blobName);

            using (var ms = new MemoryStream(image))
            {
                await blobClient.UploadAsync(ms, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = contentType ?? "image/png" }
                });
            }
            var url = blobClient.Uri.ToString();

            // Actualizar campo LogoUrl en la base de datos
            var gym = await _context.Gyms.FirstOrDefaultAsync(g => g.Id == gymId && g.IsActive);
            if (gym != null)
            {
                gym.LogoUrl = url;
                gym.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return url;
        }
    }
}
