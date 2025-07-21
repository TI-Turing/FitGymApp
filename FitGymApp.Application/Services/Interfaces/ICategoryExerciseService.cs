using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.CategoryExercise.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
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
