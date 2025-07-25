using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IFitUserRepository
    {
        Task<FitUser> CreateFitUserAsync(FitUser entity);
        Task<FitUser?> GetFitUserByIdAsync(Guid id);
        Task<IEnumerable<FitUser>> GetAllFitUsersAsync();
        Task<bool> UpdateFitUserAsync(FitUser entity);
        Task<bool> DeleteFitUserAsync(Guid id);
        Task<IEnumerable<FitUser>> FindFitUsersByFieldsAsync(Dictionary<string, object> filters);
    }
}
