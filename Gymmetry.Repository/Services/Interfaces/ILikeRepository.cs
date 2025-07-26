using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface ILikeRepository
    {
        Task<Like> AddAsync(Like like);
        Task<Like?> GetByIdAsync(Guid id);
        Task<IEnumerable<Like>> GetByPostIdAsync(Guid postId);
        Task<IEnumerable<Like>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<Like>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<Like?> GetByPostAndUserAsync(Guid postId, Guid userId);
    }
}
