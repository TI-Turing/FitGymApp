using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Module.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IModuleService
    {
        Task<ApplicationResponse<Module>> CreateModuleAsync(AddModuleRequest request);
        Task<ApplicationResponse<Module>> GetModuleByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Module>>> GetAllModulesAsync();
        Task<ApplicationResponse<bool>> UpdateModuleAsync(UpdateModuleRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteModuleAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Module>>> FindModulesByFieldsAsync(Dictionary<string, object> filters);
    }
}
