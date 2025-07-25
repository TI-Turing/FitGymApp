using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Exercise.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<ApplicationResponse<Exercise>> CreateExerciseAsync(AddExerciseRequest request);
        Task<ApplicationResponse<Exercise>> GetExerciseByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Exercise>>> GetAllExercisesAsync();
        Task<ApplicationResponse<bool>> UpdateExerciseAsync(UpdateExerciseRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteExerciseAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Exercise>>> FindExercisesByFieldsAsync(Dictionary<string, object> filters);
    }
}
