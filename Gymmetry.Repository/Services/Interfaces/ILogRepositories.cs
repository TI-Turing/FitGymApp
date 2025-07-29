using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using System.Collections.Generic;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface ILogErrorRepository
    {
        Task<bool> AddAsync(LogError log);
    }
    public interface ILogLoginRepository
    {
        Task<bool> AddAsync(LogLogin log);
        Task<LogLogin> GetByUserIdAsync(Guid userId);
        Task<bool> UpdateAsync(LogLogin log);
    }
    public interface ILogChangeRepository
    {
        Task<bool> AddAsync(LogChange log);
        Task<bool> AddRangeAsync(IEnumerable<LogChange> logs);
    }
}
