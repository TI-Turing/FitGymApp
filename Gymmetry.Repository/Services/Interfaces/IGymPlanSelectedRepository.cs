using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IGymPlanSelectedRepository
    {
        Task<GymPlanSelected> CreateGymPlanSelectedAsync(GymPlanSelected entity);
        Task<GymPlanSelected?> GetGymPlanSelectedByIdAsync(Guid id);
        Task<IEnumerable<GymPlanSelected>> GetAllGymPlanSelectedsAsync();
        Task<bool> UpdateGymPlanSelectedAsync(GymPlanSelected entity);
        Task<bool> DeleteGymPlanSelectedAsync(Guid id);
        Task<IEnumerable<GymPlanSelected>> FindGymPlanSelectedsByFieldsAsync(Dictionary<string, object> filters);
    }
}
