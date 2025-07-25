using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IDailyExerciseRepository
    {
        Task<DailyExercise> CreateDailyExerciseAsync(DailyExercise entity);
        Task<DailyExercise?> GetDailyExerciseByIdAsync(Guid id);
        Task<IEnumerable<DailyExercise>> GetAllDailyExercisesAsync();
        Task<bool> UpdateDailyExerciseAsync(DailyExercise entity);
        Task<bool> DeleteDailyExerciseAsync(Guid id);
        Task<IEnumerable<DailyExercise>> FindDailyExercisesByFieldsAsync(Dictionary<string, object> filters);
    }
}
