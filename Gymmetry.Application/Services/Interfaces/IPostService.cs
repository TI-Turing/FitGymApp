using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.DTO.Post.Request;
using Gymmetry.Domain.DTO.Post.Response;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IPostService
    {
        Task<ApplicationResponse<PostResponseDto>> CreatePostAsync(PostCreateRequestDto request);
        Task<ApplicationResponse<bool>> UpdatePostAsync(PostUpdateRequestDto request);
        Task<ApplicationResponse<bool>> DeletePostAsync(Guid postId);
        Task<ApplicationResponse<PostResponseDto>> GetPostByIdAsync(Guid postId);
        Task<ApplicationResponse<IEnumerable<PostResponseDto>>> GetPostsByUserAsync(Guid userId);
        Task<ApplicationResponse<IEnumerable<PostResponseDto>>> GetAllPostsAsync();
    }
}
