using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.DTO.BranchService.Request;
using Gymmetry.Domain.DTO.BranchService.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IBranchServiceService
    {
        Task<ApplicationResponse<BranchServiceResponse>> CreateBranchServiceAsync(AddBranchServiceRequest request);
        Task<ApplicationResponse<BranchServiceResponse>> GetBranchServiceByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<BranchServiceResponse>>> GetAllBranchServicesAsync();
        Task<ApplicationResponse<bool>> UpdateBranchServiceAsync(UpdateBranchServiceRequest request);
        Task<ApplicationResponse<bool>> DeleteBranchServiceAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<BranchServiceResponse>>> FindBranchServicesByFieldsAsync(Dictionary<string, object> filters);
    }
}
