using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.GymType.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IGymTypeService
    {
        Task<ApplicationResponse<GymType>> CreateGymTypeAsync(AddGymTypeRequest request);
        Task<ApplicationResponse<GymType>> GetGymTypeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymType>>> GetAllGymTypesAsync();
        Task<ApplicationResponse<bool>> UpdateGymTypeAsync(UpdateGymTypeRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteGymTypeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymType>>> FindGymTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
