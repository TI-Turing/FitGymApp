using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IPlanRepository
    {
        Task<Plan> CreatePlanAsync(Plan plan);
        Task<Plan> GetPlanByIdAsync(Guid id);
        Task<IEnumerable<Plan>> GetAllPlansAsync();
        Task<bool> UpdatePlanAsync(Plan plan);
        Task<bool> DeletePlanAsync(Guid id);
        Task<IEnumerable<Plan>> FindPlansByFieldsAsync(Dictionary<string, object> filters);
    }
}
