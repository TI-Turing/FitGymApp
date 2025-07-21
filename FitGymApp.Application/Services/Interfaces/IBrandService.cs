using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Brand.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IBrandService
    {
        Task<ApplicationResponse<Brand>> CreateBrandAsync(AddBrandRequest request);
        Task<ApplicationResponse<Brand>> GetBrandByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Brand>>> GetAllBrandsAsync();
        Task<ApplicationResponse<bool>> UpdateBrandAsync(UpdateBrandRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteBrandAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Brand>>> FindBrandsByFieldsAsync(Dictionary<string, object> filters);
    }
}
