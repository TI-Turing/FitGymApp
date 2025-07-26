using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.Comment.Request;
using Gymmetry.Domain.DTO.Comment.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<CommentResponseDto>> CreateCommentAsync(CommentCreateRequestDto request)
        {
            var comment = _mapper.Map<Comment>(request);
            comment.Id = Guid.NewGuid();
            comment.CreatedAt = DateTime.UtcNow;
            var created = await _commentRepository.AddAsync(comment);
            var dto = _mapper.Map<CommentResponseDto>(created);
            return ApplicationResponse<CommentResponseDto>.SuccessResponse(dto, "Comentario creado correctamente.");
        }

        public async Task<ApplicationResponse<bool>> UpdateCommentAsync(CommentUpdateRequestDto request)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            if (comment == null || comment.IsDeleted)
                return ApplicationResponse<bool>.ErrorResponse("Comentario no encontrado.");
            if (!string.IsNullOrWhiteSpace(request.Content))
                comment.Content = request.Content;
            comment.UpdatedAt = DateTime.UtcNow;
            var updated = await _commentRepository.UpdateAsync(comment);
            return updated
                ? ApplicationResponse<bool>.SuccessResponse(true, "Comentario actualizado correctamente.")
                : ApplicationResponse<bool>.ErrorResponse("No se pudo actualizar el comentario.");
        }

        public async Task<ApplicationResponse<bool>> DeleteCommentAsync(Guid commentId)
        {
            var deleted = await _commentRepository.DeleteAsync(commentId);
            return deleted
                ? ApplicationResponse<bool>.SuccessResponse(true, "Comentario eliminado correctamente.")
                : ApplicationResponse<bool>.ErrorResponse("No se pudo eliminar el comentario.");
        }

        public async Task<ApplicationResponse<CommentResponseDto>> GetCommentByIdAsync(Guid commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            if (comment == null || comment.IsDeleted)
                return ApplicationResponse<CommentResponseDto>.ErrorResponse("Comentario no encontrado.");
            var dto = _mapper.Map<CommentResponseDto>(comment);
            return ApplicationResponse<CommentResponseDto>.SuccessResponse(dto);
        }

        public async Task<ApplicationResponse<IEnumerable<CommentResponseDto>>> GetCommentsByPostAsync(Guid postId)
        {
            var comments = await _commentRepository.GetByPostIdAsync(postId);
            var dtos = comments.Select(_mapper.Map<CommentResponseDto>);
            return ApplicationResponse<IEnumerable<CommentResponseDto>>.SuccessResponse(dtos);
        }

        public async Task<ApplicationResponse<IEnumerable<CommentResponseDto>>> GetCommentsByUserAsync(Guid userId)
        {
            var comments = await _commentRepository.GetByUserIdAsync(userId);
            var dtos = comments.Select(_mapper.Map<CommentResponseDto>);
            return ApplicationResponse<IEnumerable<CommentResponseDto>>.SuccessResponse(dtos);
        }

        public async Task<ApplicationResponse<IEnumerable<CommentResponseDto>>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            var dtos = comments.Select(_mapper.Map<CommentResponseDto>);
            return ApplicationResponse<IEnumerable<CommentResponseDto>>.SuccessResponse(dtos);
        }
    }
}
