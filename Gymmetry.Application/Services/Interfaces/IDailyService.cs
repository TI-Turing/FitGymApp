using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Daily.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IDailyService
    {
        Task<ApplicationResponse<Daily>> CreateDailyAsync(AddDailyRequest request);
        Task<ApplicationResponse<Daily>> GetDailyByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Daily>>> GetAllDailiesAsync();
        Task<ApplicationResponse<bool>> UpdateDailyAsync(UpdateDailyRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteDailyAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Daily>>> FindDailiesByFieldsAsync(Dictionary<string, object> filters);
    }
}
