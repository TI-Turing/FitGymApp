using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IPlanTypeRepository
    {
        Task<PlanType> CreatePlanTypeAsync(PlanType entity);
        Task<PlanType> GetPlanTypeByIdAsync(Guid id);
        Task<IEnumerable<PlanType>> GetAllPlanTypesAsync();
        Task<bool> UpdatePlanTypeAsync(PlanType entity);
        Task<bool> DeletePlanTypeAsync(Guid id);
        Task<IEnumerable<PlanType>> FindPlanTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
