using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> AddPostAsync(Post post, byte[]? media = null, string? fileName = null, string? mediaType = null);
        Task<bool> UpdatePostAsync(Post post, byte[]? media = null, string? fileName = null, string? mediaType = null);
        Task<bool> DeletePostAsync(Guid postId);
        Task<Post?> GetPostByIdAsync(Guid postId);
        Task<IEnumerable<Post>> GetPostsByUserAsync(Guid userId);
        Task<IEnumerable<Post>> GetAllPostsAsync();
    }
}
