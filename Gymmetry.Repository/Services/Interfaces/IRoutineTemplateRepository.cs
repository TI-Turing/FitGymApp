using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IRoutineTemplateRepository
    {
        Task<RoutineTemplate> CreateRoutineTemplateAsync(RoutineTemplate entity);
        Task<RoutineTemplate> GetRoutineTemplateByIdAsync(Guid id);
        Task<IEnumerable<RoutineTemplate>> GetAllRoutineTemplatesAsync();
        Task<bool> UpdateRoutineTemplateAsync(RoutineTemplate entity);
        Task<bool> DeleteRoutineTemplateAsync(Guid id);
        Task<IEnumerable<RoutineTemplate>> FindRoutineTemplatesByFieldsAsync(Dictionary<string, object> filters);
        Task<Guid> DuplicateRoutineTemplateAsync(Guid routineTemplateId, Guid gymId);
    }
}
