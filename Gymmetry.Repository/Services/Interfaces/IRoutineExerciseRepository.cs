using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IRoutineExerciseRepository
    {
        Task<RoutineExercise> CreateRoutineExerciseAsync(RoutineExercise entity);
        Task<RoutineExercise> GetRoutineExerciseByIdAsync(Guid id);
        Task<IEnumerable<RoutineExercise>> GetAllRoutineExercisesAsync();
        Task<bool> UpdateRoutineExerciseAsync(RoutineExercise entity);
        Task<bool> DeleteRoutineExerciseAsync(Guid id);
        Task<IEnumerable<RoutineExercise>> FindRoutineExercisesByFieldsAsync(Dictionary<string, object> filters);
    }
}
