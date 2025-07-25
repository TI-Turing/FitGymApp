using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IModuleRepository
    {
        Task<Module> CreateModuleAsync(Module entity);
        Task<Module?> GetModuleByIdAsync(Guid id);
        Task<IEnumerable<Module>> GetAllModulesAsync();
        Task<bool> UpdateModuleAsync(Module entity);
        Task<bool> DeleteModuleAsync(Guid id);
        Task<IEnumerable<Module>> FindModulesByFieldsAsync(Dictionary<string, object> filters);
    }
}
