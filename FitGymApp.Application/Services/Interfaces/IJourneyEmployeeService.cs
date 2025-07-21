using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.JourneyEmployee.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IJourneyEmployeeService
    {
        Task<ApplicationResponse<JourneyEmployee>> CreateJourneyEmployeeAsync(AddJourneyEmployeeRequest request);
        Task<ApplicationResponse<JourneyEmployee>> GetJourneyEmployeeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<JourneyEmployee>>> GetAllJourneyEmployeesAsync();
        Task<ApplicationResponse<bool>> UpdateJourneyEmployeeAsync(UpdateJourneyEmployeeRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteJourneyEmployeeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<JourneyEmployee>>> FindJourneyEmployeesByFieldsAsync(Dictionary<string, object> filters);
    }
}
