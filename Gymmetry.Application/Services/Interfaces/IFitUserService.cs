using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.FitUser.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IFitUserService
    {
        Task<ApplicationResponse<FitUser>> CreateFitUserAsync(AddFitUserRequest request);
        Task<ApplicationResponse<FitUser>> GetFitUserByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<FitUser>>> GetAllFitUsersAsync();
        Task<ApplicationResponse<bool>> UpdateFitUserAsync(UpdateFitUserRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteFitUserAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<FitUser>>> FindFitUsersByFieldsAsync(Dictionary<string, object> filters);
    }
}
