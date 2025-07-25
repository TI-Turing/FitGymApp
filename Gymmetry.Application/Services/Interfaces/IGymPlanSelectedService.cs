using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.GymPlanSelected.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IGymPlanSelectedService
    {
        Task<ApplicationResponse<GymPlanSelected>> CreateGymPlanSelectedAsync(AddGymPlanSelectedRequest request);
        Task<ApplicationResponse<GymPlanSelected>> GetGymPlanSelectedByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelected>>> GetAllGymPlanSelectedsAsync();
        Task<ApplicationResponse<bool>> UpdateGymPlanSelectedAsync(UpdateGymPlanSelectedRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteGymPlanSelectedAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymPlanSelected>>> FindGymPlanSelectedsByFieldsAsync(Dictionary<string, object> filters);
    }
}
