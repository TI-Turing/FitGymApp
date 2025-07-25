using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;

namespace FitGymApp.Repository.Services.Interfaces
{
    public interface IRoutineTemplateRepository
    {
        Task<RoutineTemplate> CreateRoutineTemplateAsync(RoutineTemplate entity);
        Task<RoutineTemplate?> GetRoutineTemplateByIdAsync(Guid id);
        Task<IEnumerable<RoutineTemplate>> GetAllRoutineTemplatesAsync();
        Task<bool> UpdateRoutineTemplateAsync(RoutineTemplate entity);
        Task<bool> DeleteRoutineTemplateAsync(Guid id);
        Task<IEnumerable<RoutineTemplate>> FindRoutineTemplatesByFieldsAsync(Dictionary<string, object> filters);
        Task<bool> DeleteRoutineTemplatesByGymIdAsync(Guid gymId);
        Task<Guid> DuplicateRoutineTemplateAsync(Guid routineTemplateId, Guid gymId);
    }
}
