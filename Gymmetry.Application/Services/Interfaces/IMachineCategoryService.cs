using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.MachineCategory.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IMachineCategoryService
    {
        Task<ApplicationResponse<MachineCategory>> CreateMachineCategoryAsync(AddMachineCategoryRequest request);
        Task<ApplicationResponse<MachineCategory>> GetMachineCategoryByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<MachineCategory>>> GetAllMachineCategoriesAsync();
        Task<ApplicationResponse<bool>> UpdateMachineCategoryAsync(UpdateMachineCategoryRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteMachineCategoryAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<MachineCategory>>> FindMachineCategoriesByFieldsAsync(Dictionary<string, object> filters);
    }
}
