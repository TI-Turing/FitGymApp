using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.PlanType.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IPlanTypeService
    {
        Task<ApplicationResponse<PlanType>> CreatePlanTypeAsync(AddPlanTypeRequest request);
        Task<ApplicationResponse<PlanType>> GetPlanTypeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<PlanType>>> GetAllPlanTypesAsync();
        Task<ApplicationResponse<bool>> UpdatePlanTypeAsync(UpdatePlanTypeRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeletePlanTypeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<PlanType>>> FindPlanTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
