using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using FitGymApp.Domain.Models;

namespace FitGymApp.Repository.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
        Task<IEnumerable<User>> FindUsersByFieldsAsync(Dictionary<string, object> filters);
        Task<bool> BulkUpdateFieldAsync(IEnumerable<Guid> userIds, string fieldName, object? value);
        Task SaveChangesAsync();
        Task<string> UploadUserProfileImageAsync(Guid userId, byte[] image);
    }
}
