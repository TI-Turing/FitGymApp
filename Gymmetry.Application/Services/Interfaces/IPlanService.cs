using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Plan.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IPlanService
    {
        Task<ApplicationResponse<Plan>> CreatePlanAsync(AddPlanRequest request);
        Task<ApplicationResponse<Plan>> GetPlanByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Plan>>> GetAllPlansAsync();
        Task<ApplicationResponse<bool>> UpdatePlanAsync(UpdatePlanRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeletePlanAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Plan>>> FindPlansByFieldsAsync(Dictionary<string, object> filters);
    }
}
