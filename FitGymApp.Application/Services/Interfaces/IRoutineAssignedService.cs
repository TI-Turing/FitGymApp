using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.RoutineAssigned.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
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
