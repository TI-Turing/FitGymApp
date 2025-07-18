using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.GymPlanSelected.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IGymPlanSelectedService
    {
        Task<ApplicationResponse<GymPlanSelected>> CreateGymPlanSelectedAsync(AddGymPlanSelectedRequest request);
        Task<ApplicationResponse<GymPlanSelected>> GetGymPlanSelectedByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelected>>> GetAllGymPlanSelectedsAsync();
        Task<ApplicationResponse<bool>> UpdateGymPlanSelectedAsync(UpdateGymPlanSelectedRequest request);
        Task<ApplicationResponse<bool>> DeleteGymPlanSelectedAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelected>>> FindGymPlanSelectedsByFieldsAsync(Dictionary<string, object> filters);
    }
}
