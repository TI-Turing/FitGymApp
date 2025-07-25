using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IExerciseRepository
    {
        Task<Exercise> CreateExerciseAsync(Exercise entity);
        Task<Exercise?> GetExerciseByIdAsync(Guid id);
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();
        Task<bool> UpdateExerciseAsync(Exercise entity);
        Task<bool> DeleteExerciseAsync(Guid id);
        Task<IEnumerable<Exercise>> FindExercisesByFieldsAsync(Dictionary<string, object> filters);
    }
}
