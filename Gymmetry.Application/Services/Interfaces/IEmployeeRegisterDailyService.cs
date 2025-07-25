using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.EmployeeRegisterDaily.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IEmployeeRegisterDailyService
    {
        Task<ApplicationResponse<EmployeeRegisterDaily>> CreateEmployeeRegisterDailyAsync(AddEmployeeRegisterDailyRequest request);
        Task<ApplicationResponse<EmployeeRegisterDaily>> GetEmployeeRegisterDailyByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<EmployeeRegisterDaily>>> GetAllEmployeeRegisterDailiesAsync();
        Task<ApplicationResponse<bool>> UpdateEmployeeRegisterDailyAsync(UpdateEmployeeRegisterDailyRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteEmployeeRegisterDailyAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<EmployeeRegisterDaily>>> FindEmployeeRegisterDailiesByFieldsAsync(Dictionary<string, object> filters);
    }
}
