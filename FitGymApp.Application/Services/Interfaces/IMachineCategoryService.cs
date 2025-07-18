using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.MachineCategory.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IMachineCategoryService
    {
        Task<ApplicationResponse<MachineCategory>> CreateMachineCategoryAsync(AddMachineCategoryRequest request);
        Task<ApplicationResponse<MachineCategory>> GetMachineCategoryByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<MachineCategory>>> GetAllMachineCategoriesAsync();
        Task<ApplicationResponse<bool>> UpdateMachineCategoryAsync(UpdateMachineCategoryRequest request);
        Task<ApplicationResponse<bool>> DeleteMachineCategoryAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<MachineCategory>>> FindMachineCategoriesByFieldsAsync(Dictionary<string, object> filters);
    }
}
