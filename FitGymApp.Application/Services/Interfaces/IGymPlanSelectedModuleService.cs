using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.GymPlanSelectedModule.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IGymPlanSelectedModuleService
    {
        Task<ApplicationResponse<GymPlanSelectedModule>> CreateGymPlanSelectedModuleAsync(AddGymPlanSelectedModuleRequest request);
        Task<ApplicationResponse<GymPlanSelectedModule>> GetGymPlanSelectedModuleByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelectedModule>>> GetAllGymPlanSelectedModulesAsync();
        Task<ApplicationResponse<bool>> UpdateGymPlanSelectedModuleAsync(UpdateGymPlanSelectedModuleRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteGymPlanSelectedModuleAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelectedModule>>> FindGymPlanSelectedModulesByFieldsAsync(Dictionary<string, object> filters);
    }
}
