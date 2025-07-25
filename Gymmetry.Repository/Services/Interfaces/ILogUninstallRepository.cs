using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface ILogUninstallRepository
    {
        Task<LogUninstall> CreateLogUninstallAsync(LogUninstall entity);
        Task<LogUninstall> GetLogUninstallByIdAsync(Guid id);
        Task<IEnumerable<LogUninstall>> GetAllLogUninstallsAsync();
        Task<bool> UpdateLogUninstallAsync(LogUninstall entity);
        Task<bool> DeleteLogUninstallAsync(Guid id);
        Task<IEnumerable<LogUninstall>> FindLogUninstallsByFieldsAsync(Dictionary<string, object> filters);
    }
}
