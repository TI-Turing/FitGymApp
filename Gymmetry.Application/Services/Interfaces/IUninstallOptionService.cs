using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.UninstallOption.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IUninstallOptionService
    {
        Task<ApplicationResponse<UninstallOption>> CreateUninstallOptionAsync(AddUninstallOptionRequest request);
        Task<ApplicationResponse<UninstallOption>> GetUninstallOptionByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<UninstallOption>>> GetAllUninstallOptionsAsync();
        Task<ApplicationResponse<bool>> UpdateUninstallOptionAsync(UpdateUninstallOptionRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteUninstallOptionAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<UninstallOption>>> FindUninstallOptionsByFieldsAsync(Dictionary<string, object> filters);
    }
}
