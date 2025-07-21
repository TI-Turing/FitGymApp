using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.DailyExerciseHistory.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IDailyExerciseHistoryService
    {
        Task<ApplicationResponse<DailyExerciseHistory>> CreateDailyExerciseHistoryAsync(AddDailyExerciseHistoryRequest request);
        Task<ApplicationResponse<DailyExerciseHistory>> GetDailyExerciseHistoryByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<DailyExerciseHistory>>> GetAllDailyExerciseHistoriesAsync();
        Task<ApplicationResponse<bool>> UpdateDailyExerciseHistoryAsync(UpdateDailyExerciseHistoryRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteDailyExerciseHistoryAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<DailyExerciseHistory>>> FindDailyExerciseHistoriesByFieldsAsync(Dictionary<string, object> filters);
    }
}
