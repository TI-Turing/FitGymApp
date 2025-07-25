using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<UserType> CreateUserTypeAsync(UserType entity);
        Task<UserType> GetUserTypeByIdAsync(Guid id);
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<bool> UpdateUserTypeAsync(UserType entity);
        Task<bool> DeleteUserTypeAsync(Guid id);
        Task<IEnumerable<UserType>> FindUserTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
