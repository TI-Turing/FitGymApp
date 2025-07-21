using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.UninstallOption.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
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
