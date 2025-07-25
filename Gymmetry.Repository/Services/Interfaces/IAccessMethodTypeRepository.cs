using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IAccessMethodTypeRepository
    {
        Task<AccessMethodType> CreateAccessMethodTypeAsync(AccessMethodType entity);
        Task<AccessMethodType?> GetAccessMethodTypeByIdAsync(Guid id);
        Task<IEnumerable<AccessMethodType>> GetAllAccessMethodTypesAsync();
        Task<bool> UpdateAccessMethodTypeAsync(AccessMethodType entity);
        Task<bool> DeleteAccessMethodTypeAsync(Guid id);
        Task<IEnumerable<AccessMethodType>> FindAccessMethodTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
