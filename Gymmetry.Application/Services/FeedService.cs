using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.Feed.Request;
using Gymmetry.Domain.DTO.Feed.Response;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Application.Services
{
    public class FeedService : IFeedService
    {
        private readonly IFeedRepository _feedRepository;
        private readonly ILogger<FeedService> _logger;

        public FeedService(IFeedRepository feedRepository, ILogger<FeedService> logger)
        {
            _feedRepository = feedRepository;
            _logger = logger;
        }

        public async Task<ApplicationResponse<FeedResponseDto>> CreateFeedAsync(FeedCreateRequestDto request)
        {
            try
            {
                var feed = new Feed
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };
                var created = await _feedRepository.AddFeedAsync(feed, request.Media, request.FileName, request.MediaType);
                var dto = ToResponseDto(created);
                return ApplicationResponse<FeedResponseDto>.SuccessResponse(dto, "Feed creado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el feed");
                return ApplicationResponse<FeedResponseDto>.ErrorResponse("Error técnico al crear el feed.");
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateFeedAsync(FeedUpdateRequestDto request)
        {
            try
            {
                var feed = new Feed
                {
                    Id = request.Id,
                    Title = request.Title ?? string.Empty,
                    Description = request.Description ?? string.Empty
                };
                var updated = await _feedRepository.UpdateFeedAsync(feed, request.Media, request.FileName, request.MediaType);
                if (!updated)
                    return ApplicationResponse<bool>.ErrorResponse("No se pudo actualizar el feed (no encontrado o inactivo).");
                return ApplicationResponse<bool>.SuccessResponse(true, "Feed actualizado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el feed");
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al actualizar el feed.");
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteFeedAsync(Guid feedId)
        {
            try
            {
                var deleted = await _feedRepository.DeleteFeedAsync(feedId);
                if (!deleted)
                    return ApplicationResponse<bool>.ErrorResponse("No se pudo eliminar el feed (no encontrado o inactivo).");
                return ApplicationResponse<bool>.SuccessResponse(true, "Feed eliminado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el feed");
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al eliminar el feed.");
            }
        }

        public async Task<ApplicationResponse<FeedResponseDto>> GetFeedByIdAsync(Guid feedId)
        {
            try
            {
                var feed = await _feedRepository.GetFeedByIdAsync(feedId);
                if (feed == null)
                    return ApplicationResponse<FeedResponseDto>.ErrorResponse("Feed no encontrado.");
                var dto = ToResponseDto(feed);
                return ApplicationResponse<FeedResponseDto>.SuccessResponse(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el feed");
                return ApplicationResponse<FeedResponseDto>.ErrorResponse("Error técnico al obtener el feed.");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<FeedResponseDto>>> GetFeedsByUserAsync(Guid userId)
        {
            try
            {
                var feeds = await _feedRepository.GetFeedsByUserAsync(userId);
                var dtos = feeds.Select(ToResponseDto);
                return ApplicationResponse<IEnumerable<FeedResponseDto>>.SuccessResponse(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los feeds del usuario");
                return ApplicationResponse<IEnumerable<FeedResponseDto>>.ErrorResponse("Error técnico al obtener los feeds del usuario.");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<FeedResponseDto>>> GetAllFeedsAsync()
        {
            try
            {
                var feeds = await _feedRepository.GetAllFeedsAsync();
                var dtos = feeds.Select(ToResponseDto);
                return ApplicationResponse<IEnumerable<FeedResponseDto>>.SuccessResponse(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los feeds");
                return ApplicationResponse<IEnumerable<FeedResponseDto>>.ErrorResponse("Error técnico al obtener los feeds.");
            }
        }

        public async Task<ApplicationResponse<string>> UploadFeedMediaAsync(UploadFeedMediaRequest request)
        {
            try
            {
                var url = await _feedRepository.UploadFeedMediaToBlobAsync(request.FeedId, request.Media, request.FileName, request.ContentType);
                return new ApplicationResponse<string>
                {
                    Success = true,
                    Data = url,
                    Message = "Media subida correctamente."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al subir el archivo multimedia para FeedId: {FeedId}", request.FeedId);
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "Error técnico al subir el archivo multimedia.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<FeedResponseDto>>> SearchFeedsAsync(SearchFeedRequest request)
        {
            try
            {
                var feeds = await _feedRepository.SearchFeedsAsync(request);
                var dtos = feeds.Select(ToResponseDto);
                return ApplicationResponse<IEnumerable<FeedResponseDto>>.SuccessResponse(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar feeds");
                return ApplicationResponse<IEnumerable<FeedResponseDto>>.ErrorResponse("Error técnico al buscar feeds.");
            }
        }

        private static FeedResponseDto ToResponseDto(Feed feed)
        {
            return new FeedResponseDto
            {
                Id = feed.Id,
                UserId = feed.UserId,
                Title = feed.Title,
                Description = feed.Description,
                MediaUrl = feed.MediaUrl,
                MediaType = feed.MediaType,
                CreatedAt = feed.CreatedAt,
                UpdatedAt = feed.UpdatedAt
            };
        }
    }
}
