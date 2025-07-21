using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.RoutineExercise.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IRoutineExerciseService
    {
        Task<ApplicationResponse<RoutineExercise>> CreateRoutineExerciseAsync(AddRoutineExerciseRequest request);
        Task<ApplicationResponse<RoutineExercise>> GetRoutineExerciseByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<RoutineExercise>>> GetAllRoutineExercisesAsync();
        Task<ApplicationResponse<bool>> UpdateRoutineExerciseAsync(UpdateRoutineExerciseRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteRoutineExerciseAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<RoutineExercise>>> FindRoutineExercisesByFieldsAsync(Dictionary<string, object> filters);
    }
}
