using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IUninstallOptionRepository
    {
        Task<UninstallOption> CreateUninstallOptionAsync(UninstallOption entity);
        Task<UninstallOption> GetUninstallOptionByIdAsync(Guid id);
        Task<IEnumerable<UninstallOption>> GetAllUninstallOptionsAsync();
        Task<bool> UpdateUninstallOptionAsync(UninstallOption entity);
        Task<bool> DeleteUninstallOptionAsync(Guid id);
        Task<IEnumerable<UninstallOption>> FindUninstallOptionsByFieldsAsync(Dictionary<string, object> filters);
    }
}
