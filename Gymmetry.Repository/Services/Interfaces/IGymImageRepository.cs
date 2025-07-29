using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.GymImage;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IGymImageRepository
    {
        Task<GymImage> AddGymImageAsync(AddGymImageRequest request, string imageUrl);
        Task<GymImage?> GetGymImageByIdAsync(Guid id);
        Task<IEnumerable<GymImage>> GetAllGymImagesAsync();
        Task<bool> UpdateGymImageAsync(UpdateGymImageRequest request);
        Task<bool> DeleteGymImageAsync(Guid id);
        Task<string> UploadGymImageToBlobAsync(byte[] image, Guid? gymId, Guid? branchId);
    }
}
