using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Gym.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.Gym.Response;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IGymService
    {
        Task<ApplicationResponse<Gym>> CreateGymAsync(AddGymRequest request);
        Task<ApplicationResponse<Gym>> GetGymByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Gym>>> GetAllGymsAsync();
        Task<ApplicationResponse<bool>> UpdateGymAsync(UpdateGymRequest request, Guid? userId, string ip="", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteGymAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Gym>>> FindGymsByFieldsAsync(Dictionary<string, object> filters);
        Task<ApplicationResponse<byte[]>> GenerateGymQrAsync(Guid gymId);
        Task<ApplicationResponse<GenerateGymQrResponse>> GenerateGymQrWithPlanTypeAsync(Guid gymId, string baseUrl);
        Task<ApplicationResponse<string>> UploadGymLogoAsync(UploadGymLogoRequest request);
        Task<ApplicationResponse<IEnumerable<Gym>>> FindGymsByNameAsync(string name);
    }
}
