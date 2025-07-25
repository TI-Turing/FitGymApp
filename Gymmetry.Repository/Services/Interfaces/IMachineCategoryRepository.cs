using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IMachineCategoryRepository
    {
        Task<MachineCategory> CreateMachineCategoryAsync(MachineCategory entity);
        Task<MachineCategory?> GetMachineCategoryByIdAsync(Guid id);
        Task<IEnumerable<MachineCategory>> GetAllMachineCategoriesAsync();
        Task<bool> UpdateMachineCategoryAsync(MachineCategory entity);
        Task<bool> DeleteMachineCategoryAsync(Guid id);
        Task<IEnumerable<MachineCategory>> FindMachineCategoriesByFieldsAsync(Dictionary<string, object> filters);
    }
}
