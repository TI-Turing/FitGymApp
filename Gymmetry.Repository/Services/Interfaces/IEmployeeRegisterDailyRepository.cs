using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IEmployeeRegisterDailyRepository
    {
        Task<EmployeeRegisterDaily> CreateEmployeeRegisterDailyAsync(EmployeeRegisterDaily entity);
        Task<EmployeeRegisterDaily?> GetEmployeeRegisterDailyByIdAsync(Guid id);
        Task<IEnumerable<EmployeeRegisterDaily>> GetAllEmployeeRegisterDailiesAsync();
        Task<bool> UpdateEmployeeRegisterDailyAsync(EmployeeRegisterDaily entity);
        Task<bool> DeleteEmployeeRegisterDailyAsync(Guid id);
        Task<IEnumerable<EmployeeRegisterDaily>> FindEmployeeRegisterDailiesByFieldsAsync(Dictionary<string, object> filters);
    }
}
