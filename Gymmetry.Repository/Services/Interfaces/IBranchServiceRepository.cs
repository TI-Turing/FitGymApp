using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IBranchServiceRepository
    {
        Task<BranchService> CreateBranchServiceAsync(BranchService entity);
        Task<BranchService?> GetBranchServiceByIdAsync(Guid id);
        Task<IEnumerable<BranchService>> GetAllBranchServicesAsync();
        Task<bool> UpdateBranchServiceAsync(BranchService entity);
        Task<bool> DeleteBranchServiceAsync(Guid id);
        Task<IEnumerable<BranchService>> FindBranchServicesByFieldsAsync(Dictionary<string, object> filters);
    }
}
