using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Plan.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
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
