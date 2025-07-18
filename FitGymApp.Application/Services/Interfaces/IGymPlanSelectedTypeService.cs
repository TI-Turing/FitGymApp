using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.GymPlanSelectedType.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IGymPlanSelectedTypeService
    {
        Task<ApplicationResponse<GymPlanSelectedType>> CreateGymPlanSelectedTypeAsync(AddGymPlanSelectedTypeRequest request);
        Task<ApplicationResponse<GymPlanSelectedType>> GetGymPlanSelectedTypeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelectedType>>> GetAllGymPlanSelectedTypesAsync();
        Task<ApplicationResponse<bool>> UpdateGymPlanSelectedTypeAsync(UpdateGymPlanSelectedTypeRequest request);
        Task<ApplicationResponse<bool>> DeleteGymPlanSelectedTypeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelectedType>>> FindGymPlanSelectedTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
