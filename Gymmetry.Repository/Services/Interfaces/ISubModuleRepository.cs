using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface ISubModuleRepository
    {
        Task<SubModule> CreateSubModuleAsync(SubModule entity);
        Task<SubModule?> GetSubModuleByIdAsync(Guid id);
        Task<IEnumerable<SubModule>> GetAllSubModulesAsync();
        Task<bool> UpdateSubModuleAsync(SubModule entity);
        Task<bool> DeleteSubModuleAsync(Guid id);
        Task<IEnumerable<SubModule>> FindSubModulesByFieldsAsync(Dictionary<string, object> filters);
    }
}
