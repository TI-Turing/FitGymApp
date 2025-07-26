using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.Post.Request;
using Gymmetry.Domain.DTO.Post.Response;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ILogger<PostService> _logger;

        public PostService(IPostRepository postRepository, ILogger<PostService> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        public async Task<ApplicationResponse<PostResponseDto>> CreatePostAsync(PostCreateRequestDto request)
        {
            try
            {
                var post = new Post
                {
                    UserId = request.UserId,
                    Content = request.Content,
                };
                var created = await _postRepository.AddPostAsync(post, request.Media, request.FileName, request.MediaType);
                var dto = ToResponseDto(created);
                return ApplicationResponse<PostResponseDto>.SuccessResponse(dto, "Post creado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el post");
                return ApplicationResponse<PostResponseDto>.ErrorResponse("Error técnico al crear el post.");
            }
        }

        public async Task<ApplicationResponse<bool>> UpdatePostAsync(PostUpdateRequestDto request)
        {
            try
            {
                var post = new Post
                {
                    Id = request.Id,
                    Content = request.Content ?? string.Empty
                };
                var updated = await _postRepository.UpdatePostAsync(post, request.Media, request.FileName, request.MediaType);
                if (!updated)
                    return ApplicationResponse<bool>.ErrorResponse("No se pudo actualizar el post (no encontrado o inactivo).");
                return ApplicationResponse<bool>.SuccessResponse(true, "Post actualizado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el post");
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al actualizar el post.");
            }
        }

        public async Task<ApplicationResponse<bool>> DeletePostAsync(Guid postId)
        {
            try
            {
                var deleted = await _postRepository.DeletePostAsync(postId);
                if (!deleted)
                    return ApplicationResponse<bool>.ErrorResponse("No se pudo eliminar el post (no encontrado o inactivo).");
                return ApplicationResponse<bool>.SuccessResponse(true, "Post eliminado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el post");
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al eliminar el post.");
            }
        }

        public async Task<ApplicationResponse<PostResponseDto>> GetPostByIdAsync(Guid postId)
        {
            try
            {
                var post = await _postRepository.GetPostByIdAsync(postId);
                if (post == null)
                    return ApplicationResponse<PostResponseDto>.ErrorResponse("Post no encontrado.");
                var dto = ToResponseDto(post);
                return ApplicationResponse<PostResponseDto>.SuccessResponse(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el post");
                return ApplicationResponse<PostResponseDto>.ErrorResponse("Error técnico al obtener el post.");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<PostResponseDto>>> GetPostsByUserAsync(Guid userId)
        {
            try
            {
                var posts = await _postRepository.GetPostsByUserAsync(userId);
                var dtos = posts.Select(ToResponseDto);
                return ApplicationResponse<IEnumerable<PostResponseDto>>.SuccessResponse(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los posts del usuario");
                return ApplicationResponse<IEnumerable<PostResponseDto>>.ErrorResponse("Error técnico al obtener los posts del usuario.");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<PostResponseDto>>> GetAllPostsAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllPostsAsync();
                var dtos = posts.Select(ToResponseDto);
                return ApplicationResponse<IEnumerable<PostResponseDto>>.SuccessResponse(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los posts");
                return ApplicationResponse<IEnumerable<PostResponseDto>>.ErrorResponse("Error técnico al obtener los posts.");
            }
        }

        private static PostResponseDto ToResponseDto(Post post)
        {
            return new PostResponseDto
            {
                Id = post.Id,
                UserId = post.UserId,
                Content = post.Content,
                MediaUrl = post.MediaUrl,
                MediaType = post.MediaType,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
        }
    }
}
