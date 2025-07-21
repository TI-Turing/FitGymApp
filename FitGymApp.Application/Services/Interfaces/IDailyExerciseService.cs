using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.DailyExercise.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IDailyExerciseService
    {
        Task<ApplicationResponse<DailyExercise>> CreateDailyExerciseAsync(AddDailyExerciseRequest request);
        Task<ApplicationResponse<DailyExercise>> GetDailyExerciseByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<DailyExercise>>> GetAllDailyExercisesAsync();
        Task<ApplicationResponse<bool>> UpdateDailyExerciseAsync(UpdateDailyExerciseRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteDailyExerciseAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<DailyExercise>>> FindDailyExercisesByFieldsAsync(Dictionary<string, object> filters);
    }
}
