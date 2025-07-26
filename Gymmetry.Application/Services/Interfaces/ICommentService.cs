using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.DTO.Comment.Request;
using Gymmetry.Domain.DTO.Comment.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<ApplicationResponse<CommentResponseDto>> CreateCommentAsync(CommentCreateRequestDto request);
        Task<ApplicationResponse<bool>> UpdateCommentAsync(CommentUpdateRequestDto request);
        Task<ApplicationResponse<bool>> DeleteCommentAsync(Guid commentId);
        Task<ApplicationResponse<CommentResponseDto>> GetCommentByIdAsync(Guid commentId);
        Task<ApplicationResponse<IEnumerable<CommentResponseDto>>> GetCommentsByPostAsync(Guid postId);
        Task<ApplicationResponse<IEnumerable<CommentResponseDto>>> GetCommentsByUserAsync(Guid userId);
        Task<ApplicationResponse<IEnumerable<CommentResponseDto>>> GetAllCommentsAsync();
    }
}
