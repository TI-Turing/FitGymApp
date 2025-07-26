using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> AddAsync(Comment comment);
        Task<Comment?> GetByIdAsync(Guid id);
        Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId);
        Task<IEnumerable<Comment>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<bool> UpdateAsync(Comment comment);
        Task<bool> DeleteAsync(Guid id);
    }
}
