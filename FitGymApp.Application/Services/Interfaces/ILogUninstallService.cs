using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.LogUninstall.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface ILogUninstallService
    {
        Task<ApplicationResponse<LogUninstall>> CreateLogUninstallAsync(AddLogUninstallRequest request);
        Task<ApplicationResponse<LogUninstall>> GetLogUninstallByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<LogUninstall>>> GetAllLogUninstallsAsync();
        Task<ApplicationResponse<bool>> UpdateLogUninstallAsync(UpdateLogUninstallRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteLogUninstallAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<LogUninstall>>> FindLogUninstallsByFieldsAsync(Dictionary<string, object> filters);
    }
}
