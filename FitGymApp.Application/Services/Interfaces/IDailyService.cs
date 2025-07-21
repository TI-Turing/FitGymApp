using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Daily.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IDailyService
    {
        Task<ApplicationResponse<Daily>> CreateDailyAsync(AddDailyRequest request);
        Task<ApplicationResponse<Daily>> GetDailyByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Daily>>> GetAllDailiesAsync();
        Task<ApplicationResponse<bool>> UpdateDailyAsync(UpdateDailyRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteDailyAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Daily>>> FindDailiesByFieldsAsync(Dictionary<string, object> filters);
    }
}
