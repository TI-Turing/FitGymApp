using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IBranchMediaRepository
    {
        Task<BranchMedia> CreateBranchMediaAsync(BranchMedia entity);
        Task<BranchMedia?> GetBranchMediaByIdAsync(Guid id);
        Task<IEnumerable<BranchMedia>> GetAllBranchMediasAsync();
        Task<bool> UpdateBranchMediaAsync(BranchMedia entity);
        Task<bool> DeleteBranchMediaAsync(Guid id);
        Task<IEnumerable<BranchMedia>> FindBranchMediasByFieldsAsync(Dictionary<string, object> filters);
    }

    public interface ICurrentOccupancyRepository
    {
        Task<CurrentOccupancy> CreateCurrentOccupancyAsync(CurrentOccupancy entity);
        Task<CurrentOccupancy?> GetCurrentOccupancyByIdAsync(Guid id);
        Task<IEnumerable<CurrentOccupancy>> GetAllCurrentOccupanciesAsync();
        Task<bool> UpdateCurrentOccupancyAsync(CurrentOccupancy entity);
        Task<bool> DeleteCurrentOccupancyAsync(Guid id);
        Task<IEnumerable<CurrentOccupancy>> FindCurrentOccupanciesByFieldsAsync(Dictionary<string, object> filters);
    }
}
