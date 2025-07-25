using System;
using System.Collections.Generic;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Permission> CreatePermissionAsync(Permission entity);
        Task<Permission> GetPermissionByIdAsync(Guid id);
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<bool> UpdatePermissionAsync(Permission entity);
        Task<bool> DeletePermissionAsync(Guid id);
        Task<IEnumerable<Permission>> FindPermissionsByFieldsAsync(Dictionary<string, object> filters);
    }
}
