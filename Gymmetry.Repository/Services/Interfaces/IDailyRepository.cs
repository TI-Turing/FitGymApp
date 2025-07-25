using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IDailyRepository
    {
        Task<Daily> CreateDailyAsync(Daily entity);
        Task<Daily?> GetDailyByIdAsync(Guid id);
        Task<IEnumerable<Daily>> GetAllDailiesAsync();
        Task<bool> UpdateDailyAsync(Daily entity);
        Task<bool> DeleteDailyAsync(Guid id);
        Task<IEnumerable<Daily>> FindDailiesByFieldsAsync(Dictionary<string, object> filters);
    }
}
