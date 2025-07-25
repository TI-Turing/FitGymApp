using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IEmployeeTypeRepository
    {
        Task<EmployeeType> CreateEmployeeTypeAsync(EmployeeType entity);
        Task<EmployeeType?> GetEmployeeTypeByIdAsync(Guid id);
        Task<IEnumerable<EmployeeType>> GetAllEmployeeTypesAsync();
        Task<bool> UpdateEmployeeTypeAsync(EmployeeType entity);
        Task<bool> DeleteEmployeeTypeAsync(Guid id);
        Task<IEnumerable<EmployeeType>> FindEmployeeTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
