using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.AccessMethodType.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
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
