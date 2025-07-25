using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.RoutineAssigned.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IRoutineAssignedService
    {
        Task<ApplicationResponse<RoutineAssigned>> CreateRoutineAssignedAsync(AddRoutineAssignedRequest request);
        Task<ApplicationResponse<RoutineAssigned>> GetRoutineAssignedByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<RoutineAssigned>>> GetAllRoutineAssignedsAsync();
        Task<ApplicationResponse<bool>> UpdateRoutineAssignedAsync(UpdateRoutineAssignedRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteRoutineAssignedAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<RoutineAssigned>>> FindRoutineAssignedsByFieldsAsync(Dictionary<string, object> filters);
    }
}
