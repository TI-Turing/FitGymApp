using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FitGymApp.Repository.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly FitGymAppContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(FitGymAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;
            user.IsActive = true;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id && (u.IsActive ?? false));
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Where(u => u.IsActive ?? false).ToListAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id && (u.IsActive ?? false));
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(user);
                existingUser.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && (u.IsActive ?? false));
            if (user != null)
            {
                user.IsActive = false;
                user.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> FindUsersByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(User), "u");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(User.IsActive)),
                Expression.Constant(true, typeof(bool?))
            );

            foreach (var filter in filters)
            {
                var property = typeof(User).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<User, bool>>(predicate, parameter);
            return await _context.Users.Where(lambda).ToListAsync();
        }

        public async Task<bool> BulkUpdateFieldAsync(IEnumerable<Guid> userIds, string fieldName, object? value)
        {
            try
            {
                var usersToUpdate = await _context.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();

                foreach (var user in usersToUpdate)
                {
                    var property = typeof(User).GetProperty(fieldName);
                    if (property != null && property.CanWrite)
                    {
                        property.SetValue(user, value);
                        user.UpdatedAt = DateTime.UtcNow; // Ensure UpdatedAt is set
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<string> UploadUserProfileImageAsync(Guid userId, byte[] image)
        {
            // Get connection string and container name from environment variables
            string connectionString = _configuration["BlobStorage:ConnectionString"] ?? _configuration["AzureWebJobsStorage"];
            string containerName = _configuration["BlobStorage:UserProfileContainer"] ?? "user-profile-images";
            string blobName = $"{userId}_ProfileImage.png";

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);
            var blobClient = containerClient.GetBlobClient(blobName);

            using (var ms = new MemoryStream(image))
            {   
                await blobClient.UploadAsync(ms, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = "image/png" }
                });
            }
            var uploadedUrl = blobClient.Uri.ToString();

            // Update the user's profile image URL in the database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.ProfileImageUrl = uploadedUrl;
            user.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return uploadedUrl;
        }
    }
}
