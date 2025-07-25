using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IBranchRepository
    {
        Task<Branch> CreateBranchAsync(Branch branch);
        Task<Branch?> GetBranchByIdAsync(Guid id);
        Task<IEnumerable<Branch>> GetAllBranchesAsync();
        Task<bool> UpdateBranchAsync(Branch branch);
        Task<bool> DeleteBranchAsync(Guid id);
        Task<IEnumerable<Branch>> FindBranchesByFieldsAsync(Dictionary<string, object> filters);
    }
}
