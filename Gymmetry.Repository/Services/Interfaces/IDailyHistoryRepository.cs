using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IDailyHistoryRepository
    {
        Task<DailyHistory> CreateDailyHistoryAsync(DailyHistory entity);
        Task<DailyHistory?> GetDailyHistoryByIdAsync(Guid id);
        Task<IEnumerable<DailyHistory>> GetAllDailyHistoriesAsync();
        Task<bool> UpdateDailyHistoryAsync(DailyHistory entity);
        Task<bool> DeleteDailyHistoryAsync(Guid id);
        Task<IEnumerable<DailyHistory>> FindDailyHistoriesByFieldsAsync(Dictionary<string, object> filters);
    }
}
