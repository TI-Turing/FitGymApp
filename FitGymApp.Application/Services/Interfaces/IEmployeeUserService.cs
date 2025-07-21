using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.EmployeeUser.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IEmployeeUserService
    {
        Task<ApplicationResponse<EmployeeUser>> CreateEmployeeUserAsync(AddEmployeeUserRequest request);
        Task<ApplicationResponse<EmployeeUser>> GetEmployeeUserByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<EmployeeUser>>> GetAllEmployeeUsersAsync();
        Task<ApplicationResponse<bool>> UpdateEmployeeUserAsync(UpdateEmployeeUserRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteEmployeeUserAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<EmployeeUser>>> FindEmployeeUsersByFieldsAsync(Dictionary<string, object> filters);
    }
}
