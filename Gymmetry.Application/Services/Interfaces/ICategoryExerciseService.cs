using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.CategoryExercise.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface ICategoryExerciseService
    {
        Task<ApplicationResponse<CategoryExercise>> CreateCategoryExerciseAsync(AddCategoryExerciseRequest request);
        Task<ApplicationResponse<CategoryExercise>> GetCategoryExerciseByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<CategoryExercise>>> GetAllCategoryExercisesAsync();
        Task<ApplicationResponse<bool>> UpdateCategoryExerciseAsync(UpdateCategoryExerciseRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteCategoryExerciseAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<CategoryExercise>>> FindCategoryExercisesByFieldsAsync(Dictionary<string, object> filters);
    }
}
