using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Diet.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IDietService
    {
        Task<ApplicationResponse<Diet>> CreateDietAsync(AddDietRequest request);
        Task<ApplicationResponse<Diet>> GetDietByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Diet>>> GetAllDietsAsync();
        Task<ApplicationResponse<bool>> UpdateDietAsync(UpdateDietRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteDietAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Diet>>> FindDietsByFieldsAsync(Dictionary<string, object> filters);
    }
}
