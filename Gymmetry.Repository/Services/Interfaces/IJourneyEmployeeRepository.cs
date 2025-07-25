using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IJourneyEmployeeRepository
    {
        Task<JourneyEmployee> CreateJourneyEmployeeAsync(JourneyEmployee entity);
        Task<JourneyEmployee?> GetJourneyEmployeeByIdAsync(Guid id);
        Task<IEnumerable<JourneyEmployee>> GetAllJourneyEmployeesAsync();
        Task<bool> UpdateJourneyEmployeeAsync(JourneyEmployee entity);
        Task<bool> DeleteJourneyEmployeeAsync(Guid id);
        Task<IEnumerable<JourneyEmployee>> FindJourneyEmployeesByFieldsAsync(Dictionary<string, object> filters);
    }
}
