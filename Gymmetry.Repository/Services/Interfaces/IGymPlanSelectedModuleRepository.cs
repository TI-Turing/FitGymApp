using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IGymPlanSelectedModuleRepository
    {
        Task<GymPlanSelectedModule> CreateGymPlanSelectedModuleAsync(GymPlanSelectedModule entity);
        Task<GymPlanSelectedModule?> GetGymPlanSelectedModuleByIdAsync(Guid id);
        Task<IEnumerable<GymPlanSelectedModule>> GetAllGymPlanSelectedModulesAsync();
        Task<bool> UpdateGymPlanSelectedModuleAsync(GymPlanSelectedModule entity);
        Task<bool> DeleteGymPlanSelectedModuleAsync(Guid id);
        Task<IEnumerable<GymPlanSelectedModule>> FindGymPlanSelectedModulesByFieldsAsync(Dictionary<string, object> filters);
    }
}
