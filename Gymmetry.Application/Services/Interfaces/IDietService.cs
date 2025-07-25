using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Diet.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IDietService
    {
        Task<ApplicationResponse<Diet>> CreateDietAsync(AddDietRequest request);
        Task<ApplicationResponse<Diet>> GetDietByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Diet>>> GetAllDietsAsync();
        Task<ApplicationResponse<bool>> UpdateDietAsync(UpdateDietRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteDietAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Diet>>> FindDietsByFieldsAsync(Dictionary<string, object> filters);
    }
}
