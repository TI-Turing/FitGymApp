using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IScheduleRepository
    {
        Task<Schedule> CreateScheduleAsync(Schedule entity);
        Task<Schedule?> GetScheduleByIdAsync(Guid id);
        Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
        Task<bool> UpdateScheduleAsync(Schedule entity);
        Task<bool> DeleteScheduleAsync(Guid id);
        Task<IEnumerable<Schedule>> FindSchedulesByFieldsAsync(Dictionary<string, object> filters);
    }
}
