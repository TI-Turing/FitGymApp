using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IEmployeeUserRepository
    {
        Task<EmployeeUser> CreateEmployeeUserAsync(EmployeeUser entity);
        Task<EmployeeUser?> GetEmployeeUserByIdAsync(Guid id);
        Task<IEnumerable<EmployeeUser>> GetAllEmployeeUsersAsync();
        Task<bool> UpdateEmployeeUserAsync(EmployeeUser entity);
        Task<bool> DeleteEmployeeUserAsync(Guid id);
        Task<IEnumerable<EmployeeUser>> FindEmployeeUsersByFieldsAsync(Dictionary<string, object> filters);
    }
}
