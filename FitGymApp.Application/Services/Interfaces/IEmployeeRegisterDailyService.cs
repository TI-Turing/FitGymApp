using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.EmployeeRegisterDaily.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IEmployeeRegisterDailyService
    {
        Task<ApplicationResponse<EmployeeRegisterDaily>> CreateEmployeeRegisterDailyAsync(AddEmployeeRegisterDailyRequest request);
        Task<ApplicationResponse<EmployeeRegisterDaily>> GetEmployeeRegisterDailyByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<EmployeeRegisterDaily>>> GetAllEmployeeRegisterDailiesAsync();
        Task<ApplicationResponse<bool>> UpdateEmployeeRegisterDailyAsync(UpdateEmployeeRegisterDailyRequest request);
        Task<ApplicationResponse<bool>> DeleteEmployeeRegisterDailyAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<EmployeeRegisterDaily>>> FindEmployeeRegisterDailiesByFieldsAsync(Dictionary<string, object> filters);
    }
}
