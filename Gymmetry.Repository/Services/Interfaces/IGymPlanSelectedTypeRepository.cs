using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IGymPlanSelectedTypeRepository
    {
        Task<GymPlanSelectedType> CreateGymPlanSelectedTypeAsync(GymPlanSelectedType entity);
        Task<GymPlanSelectedType?> GetGymPlanSelectedTypeByIdAsync(Guid id);
        Task<IEnumerable<GymPlanSelectedType>> GetAllGymPlanSelectedTypesAsync();
        Task<bool> UpdateGymPlanSelectedTypeAsync(GymPlanSelectedType entity);
        Task<bool> DeleteGymPlanSelectedTypeAsync(Guid id);
        Task<IEnumerable<GymPlanSelectedType>> FindGymPlanSelectedTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
