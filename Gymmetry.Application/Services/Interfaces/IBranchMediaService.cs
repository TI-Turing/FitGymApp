using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IBranchMediaService
    {
        Task<ApplicationResponse<BranchMedia>> CreateBranchMediaAsync(BranchMedia entity);
        Task<ApplicationResponse<BranchMedia>> GetBranchMediaByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<BranchMedia>>> GetAllBranchMediasAsync();
        Task<ApplicationResponse<bool>> UpdateBranchMediaAsync(BranchMedia entity);
        Task<ApplicationResponse<bool>> DeleteBranchMediaAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<BranchMedia>>> FindBranchMediasByFieldsAsync(Dictionary<string, object> filters);
    }

    public interface ICurrentOccupancyService
    {
        Task<ApplicationResponse<CurrentOccupancy>> CreateCurrentOccupancyAsync(CurrentOccupancy entity);
        Task<ApplicationResponse<CurrentOccupancy>> GetCurrentOccupancyByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<CurrentOccupancy>>> GetAllCurrentOccupanciesAsync();
        Task<ApplicationResponse<bool>> UpdateCurrentOccupancyAsync(CurrentOccupancy entity);
        Task<ApplicationResponse<bool>> DeleteCurrentOccupancyAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<CurrentOccupancy>>> FindCurrentOccupanciesByFieldsAsync(Dictionary<string, object> filters);
    }
}
