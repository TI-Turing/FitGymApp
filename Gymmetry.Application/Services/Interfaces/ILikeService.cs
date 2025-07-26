using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.DTO.Like.Request;
using Gymmetry.Domain.DTO.Like.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface ILikeService
    {
        Task<ApplicationResponse<LikeResponseDto>> CreateLikeAsync(LikeCreateRequestDto request);
        Task<ApplicationResponse<bool>> DeleteLikeAsync(Guid likeId);
        Task<ApplicationResponse<LikeResponseDto>> GetLikeByIdAsync(Guid likeId);
        Task<ApplicationResponse<IEnumerable<LikeResponseDto>>> GetLikesByPostAsync(Guid postId);
        Task<ApplicationResponse<IEnumerable<LikeResponseDto>>> GetLikesByUserAsync(Guid userId);
        Task<ApplicationResponse<IEnumerable<LikeResponseDto>>> GetAllLikesAsync();
        Task<ApplicationResponse<LikeResponseDto>> GetLikeByPostAndUserAsync(Guid postId, Guid userId);
    }
}
