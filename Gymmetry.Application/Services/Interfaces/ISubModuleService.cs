using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.SubModule.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface ISubModuleService
    {
        Task<ApplicationResponse<SubModule>> CreateSubModuleAsync(AddSubModuleRequest request);
        Task<ApplicationResponse<SubModule>> GetSubModuleByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<SubModule>>> GetAllSubModulesAsync();
        Task<ApplicationResponse<bool>> UpdateSubModuleAsync(UpdateSubModuleRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteSubModuleAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<SubModule>>> FindSubModulesByFieldsAsync(Dictionary<string, object> filters);
    }
}
