using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.GymImage;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IGymImageService
    {
        Task<ApplicationResponse<GymImageResponse>> AddGymImageAsync(AddGymImageRequest request);
        Task<ApplicationResponse<GymImageResponse>> GetGymImageByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<GymImageResponse>>> GetAllGymImagesAsync();
        Task<ApplicationResponse<bool>> UpdateGymImageAsync(UpdateGymImageRequest request);
        Task<ApplicationResponse<bool>> DeleteGymImageAsync(Guid id);
        Task<ApplicationResponse<string>> UploadGymImageAsync(UploadGymImageRequest request);
    }
}
