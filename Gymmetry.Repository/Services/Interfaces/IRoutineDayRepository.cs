using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.ViewModels;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IRoutineDayRepository
    {
        Task<RoutineDay> CreateRoutineDayAsync(RoutineDay routineDay);
        Task<RoutineDay?> GetRoutineDayByIdAsync(Guid id);
        Task<IEnumerable<RoutineDay>> GetAllRoutineDaysAsync();
        Task<bool> UpdateRoutineDayAsync(RoutineDay routineDay);
        Task<bool> DeleteRoutineDayAsync(Guid id);
        Task<IEnumerable<RoutineDay>> FindRoutineDaysByFieldsAsync(Dictionary<string, object> filters);
        Task<IEnumerable<RoutineDayDetailViewModel>> GetRoutineDayDetailsAsync();
        Task<IEnumerable<Guid>> CreateRoutineDaysAsync(IEnumerable<RoutineDay> routineDays);
    }
}
