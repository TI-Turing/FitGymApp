using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.AccessMethodType.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IAccessMethodTypeService
    {
        Task<ApplicationResponse<AccessMethodType>> CreateAccessMethodTypeAsync(AddAccessMethodTypeRequest request);
        Task<ApplicationResponse<AccessMethodType>> GetAccessMethodTypeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<AccessMethodType>>> GetAllAccessMethodTypesAsync();
        Task<ApplicationResponse<bool>> UpdateAccessMethodTypeAsync(UpdateAccessMethodTypeRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteAccessMethodTypeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<AccessMethodType>>> FindAccessMethodTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
