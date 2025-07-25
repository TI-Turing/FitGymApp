using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.DailyExercise.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
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
