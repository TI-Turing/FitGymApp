using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.DailyHistory.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IDailyHistoryService
    {
        Task<ApplicationResponse<DailyHistory>> CreateDailyHistoryAsync(AddDailyHistoryRequest request);
        Task<ApplicationResponse<DailyHistory>> GetDailyHistoryByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<DailyHistory>>> GetAllDailyHistoriesAsync();
        Task<ApplicationResponse<bool>> UpdateDailyHistoryAsync(UpdateDailyHistoryRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteDailyHistoryAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<DailyHistory>>> FindDailyHistoriesByFieldsAsync(Dictionary<string, object> filters);
    }
}
