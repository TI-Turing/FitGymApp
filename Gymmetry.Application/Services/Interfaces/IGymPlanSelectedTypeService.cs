using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.GymPlanSelectedType.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IGymPlanSelectedTypeService
    {
        Task<ApplicationResponse<GymPlanSelectedType>> CreateGymPlanSelectedTypeAsync(AddGymPlanSelectedTypeRequest request);
        Task<ApplicationResponse<GymPlanSelectedType>> GetGymPlanSelectedTypeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelectedType>>> GetAllGymPlanSelectedTypesAsync();
        Task<ApplicationResponse<bool>> UpdateGymPlanSelectedTypeAsync(UpdateGymPlanSelectedTypeRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteGymPlanSelectedTypeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelectedType>>> FindGymPlanSelectedTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
