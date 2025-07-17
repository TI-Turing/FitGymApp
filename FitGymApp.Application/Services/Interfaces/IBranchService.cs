using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Branch.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IBranchService
    {
        Task<ApplicationResponse<Branch>> CreateBranchAsync(AddBranchRequest request);
        Task<ApplicationResponse<Branch>> GetBranchByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Branch>>> GetAllBranchesAsync();
        Task<ApplicationResponse<bool>> UpdateBranchAsync(UpdateBranchRequest request, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteBranchAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Branch>>> FindBranchesByFieldsAsync(Dictionary<string, object> filters);
        Task<ApplicationResponse<bool>> DeleteBranchesByGymIdAsync(Guid gymId);
    }
}
