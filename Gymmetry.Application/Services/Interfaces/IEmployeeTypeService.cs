using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.EmployeeType.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
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
