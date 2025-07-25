using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.RoutineTemplate.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IRoutineTemplateService
    {
        Task<ApplicationResponse<RoutineTemplate>> CreateRoutineTemplateAsync(AddRoutineTemplateRequest request);
        Task<ApplicationResponse<RoutineTemplate>> GetRoutineTemplateByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<RoutineTemplate>>> GetAllRoutineTemplatesAsync();
        Task<ApplicationResponse<bool>> UpdateRoutineTemplateAsync(UpdateRoutineTemplateRequest request, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteRoutineTemplateAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<RoutineTemplate>>> FindRoutineTemplatesByFieldsAsync(Dictionary<string, object> filters);
        Task<ApplicationResponse<bool>> DeleteRoutineTemplatesByGymIdAsync(Guid gymId);
        Task<ApplicationResponse<Guid>> DuplicateRoutineTemplateAsync(Guid routineTemplateId, Guid gymId);
    }
}
