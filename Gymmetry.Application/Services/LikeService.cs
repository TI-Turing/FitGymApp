using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.Like.Request;
using Gymmetry.Domain.DTO.Like.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public LikeService(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<LikeResponseDto>> CreateLikeAsync(LikeCreateRequestDto request)
        {
            var existing = await _likeRepository.GetByPostAndUserAsync(request.PostId, request.UserId);
            if (existing != null && !existing.IsDeleted)
                return ApplicationResponse<LikeResponseDto>.ErrorResponse("Ya existe un like para este usuario y post.");
            var like = _mapper.Map<Like>(request);
            like.Id = Guid.NewGuid();
            like.CreatedAt = DateTime.UtcNow;
            var created = await _likeRepository.AddAsync(like);
            var dto = _mapper.Map<LikeResponseDto>(created);
            return ApplicationResponse<LikeResponseDto>.SuccessResponse(dto, "Like creado correctamente.");
        }

        public async Task<ApplicationResponse<bool>> DeleteLikeAsync(Guid likeId)
        {
            var deleted = await _likeRepository.DeleteAsync(likeId);
            return deleted
                ? ApplicationResponse<bool>.SuccessResponse(true, "Like eliminado correctamente.")
                : ApplicationResponse<bool>.ErrorResponse("No se pudo eliminar el like.");
        }

        public async Task<ApplicationResponse<LikeResponseDto>> GetLikeByIdAsync(Guid likeId)
        {
            var like = await _likeRepository.GetByIdAsync(likeId);
            if (like == null || like.IsDeleted)
                return ApplicationResponse<LikeResponseDto>.ErrorResponse("Like no encontrado.");
            var dto = _mapper.Map<LikeResponseDto>(like);
            return ApplicationResponse<LikeResponseDto>.SuccessResponse(dto);
        }

        public async Task<ApplicationResponse<IEnumerable<LikeResponseDto>>> GetLikesByPostAsync(Guid postId)
        {
            var likes = await _likeRepository.GetByPostIdAsync(postId);
            var dtos = likes.Select(_mapper.Map<LikeResponseDto>);
            return ApplicationResponse<IEnumerable<LikeResponseDto>>.SuccessResponse(dtos);
        }

        public async Task<ApplicationResponse<IEnumerable<LikeResponseDto>>> GetLikesByUserAsync(Guid userId)
        {
            var likes = await _likeRepository.GetByUserIdAsync(userId);
            var dtos = likes.Select(_mapper.Map<LikeResponseDto>);
            return ApplicationResponse<IEnumerable<LikeResponseDto>>.SuccessResponse(dtos);
        }

        public async Task<ApplicationResponse<IEnumerable<LikeResponseDto>>> GetAllLikesAsync()
        {
            var likes = await _likeRepository.GetAllAsync();
            var dtos = likes.Select(_mapper.Map<LikeResponseDto>);
            return ApplicationResponse<IEnumerable<LikeResponseDto>>.SuccessResponse(dtos);
        }

        public async Task<ApplicationResponse<LikeResponseDto>> GetLikeByPostAndUserAsync(Guid postId, Guid userId)
        {
            var like = await _likeRepository.GetByPostAndUserAsync(postId, userId);
            if (like == null || like.IsDeleted)
                return ApplicationResponse<LikeResponseDto>.ErrorResponse("Like no encontrado.");
            var dto = _mapper.Map<LikeResponseDto>(like);
            return ApplicationResponse<LikeResponseDto>.SuccessResponse(dto);
        }
    }
}
