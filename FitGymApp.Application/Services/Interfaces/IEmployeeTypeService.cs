using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.EmployeeType.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IEmployeeTypeService
    {
        Task<ApplicationResponse<EmployeeType>> CreateEmployeeTypeAsync(AddEmployeeTypeRequest request);
        Task<ApplicationResponse<EmployeeType>> GetEmployeeTypeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<EmployeeType>>> GetAllEmployeeTypesAsync();
        Task<ApplicationResponse<bool>> UpdateEmployeeTypeAsync(UpdateEmployeeTypeRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteEmployeeTypeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<EmployeeType>>> FindEmployeeTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
