using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IRoutineAssignedRepository
    {
        Task<RoutineAssigned> CreateRoutineAssignedAsync(RoutineAssigned entity);
        Task<RoutineAssigned?> GetRoutineAssignedByIdAsync(Guid id);
        Task<IEnumerable<RoutineAssigned>> GetAllRoutineAssignedsAsync();
        Task<bool> UpdateRoutineAssignedAsync(RoutineAssigned entity);
        Task<bool> DeleteRoutineAssignedAsync(Guid id);
        Task<IEnumerable<RoutineAssigned>> FindRoutineAssignedsByFieldsAsync(Dictionary<string, object> filters);
    }
}
