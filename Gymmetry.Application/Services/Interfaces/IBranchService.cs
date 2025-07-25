using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Branch.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IBranchService
    {
        Task<ApplicationResponse<Branch>> CreateBranchAsync(AddBranchRequest request);
        Task<ApplicationResponse<Branch>> GetBranchByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Branch>>> GetAllBranchesAsync();
        Task<ApplicationResponse<bool>> UpdateBranchAsync(UpdateBranchRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteBranchAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Branch>>> FindBranchesByFieldsAsync(Dictionary<string, object> filters);
        Task<ApplicationResponse<bool>> DeleteBranchesByGymIdAsync(Guid gymId);
    }
}
