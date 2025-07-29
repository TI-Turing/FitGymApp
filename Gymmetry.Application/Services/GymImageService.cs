using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.GymImage;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class GymImageService : IGymImageService
    {
        private readonly IGymImageRepository _gymImageRepository;
        private readonly ILogErrorService _logErrorService;

        public GymImageService(IGymImageRepository gymImageRepository, ILogErrorService logErrorService)
        {
            _gymImageRepository = gymImageRepository;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<GymImageResponse>> AddGymImageAsync(AddGymImageRequest request)
        {
            try
            {
                string imageUrl = string.Empty;
                if (request.Image != null)
                {
                    imageUrl = await _gymImageRepository.UploadGymImageToBlobAsync(request.Image, request.GymId, request.BranchId);
                }
                var entity = await _gymImageRepository.AddGymImageAsync(request, imageUrl);
                var response = new GymImageResponse
                {
                    Id = entity.Id,
                    Url = entity.Url,
                    Description = entity.Description,
                    GymId = entity.GymId,
                    BranchId = entity.BranchId,
                    CreatedAt = entity.CreatedAt,
                    UpdatedAt = entity.UpdatedAt,
                    IsActive = entity.IsActive
                };
                return new ApplicationResponse<GymImageResponse>
                {
                    Success = true,
                    Data = response,
                    Message = "Imagen de gimnasio creada correctamente."
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<GymImageResponse>
                {
                    Success = false,
                    Message = "Error técnico al crear la imagen de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<GymImageResponse>> GetGymImageByIdAsync(Guid id)
        {
            var entity = await _gymImageRepository.GetGymImageByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<GymImageResponse>
                {
                    Success = false,
                    Message = "Imagen de gimnasio no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            var response = new GymImageResponse
            {
                Id = entity.Id,
                Url = entity.Url,
                Description = entity.Description,
                GymId = entity.GymId,
                BranchId = entity.BranchId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive
            };
            return new ApplicationResponse<GymImageResponse>
            {
                Success = true,
                Data = response
            };
        }

        public async Task<ApplicationResponse<IEnumerable<GymImageResponse>>> GetAllGymImagesAsync()
        {
            var entities = await _gymImageRepository.GetAllGymImagesAsync();
            var responses = entities.Select(entity => new GymImageResponse
            {
                Id = entity.Id,
                Url = entity.Url,
                Description = entity.Description,
                GymId = entity.GymId,
                BranchId = entity.BranchId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive
            });
            return new ApplicationResponse<IEnumerable<GymImageResponse>>
            {
                Success = true,
                Data = responses
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateGymImageAsync(UpdateGymImageRequest request)
        {
            try
            {
                var updated = await _gymImageRepository.UpdateGymImageAsync(request);
                return new ApplicationResponse<bool>
                {
                    Success = updated,
                    Data = updated,
                    Message = updated ? "Imagen actualizada correctamente." : "No se pudo actualizar la imagen."
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar la imagen.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteGymImageAsync(Guid id)
        {
            try
            {
                var deleted = await _gymImageRepository.DeleteGymImageAsync(id);
                return new ApplicationResponse<bool>
                {
                    Success = deleted,
                    Data = deleted,
                    Message = deleted ? "Imagen eliminada correctamente." : "No se pudo eliminar la imagen."
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al eliminar la imagen.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<string>> UploadGymImageAsync(UploadGymImageRequest request)
        {
            try
            {
                var url = await _gymImageRepository.UploadGymImageToBlobAsync(request.Image, request.GymId, request.BranchId);
                return new ApplicationResponse<string>
                {
                    Success = true,
                    Data = url,
                    Message = "Imagen subida correctamente."
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "Error técnico al subir la imagen.",
                    ErrorCode = "TechnicalError"
                };
            }
        }
    }
}
