using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.LogUninstall.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
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
