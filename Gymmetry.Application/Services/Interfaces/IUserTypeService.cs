using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.UserType.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IUserTypeService
    {
        Task<ApplicationResponse<UserType>> CreateUserTypeAsync(AddUserTypeRequest request);
        Task<ApplicationResponse<UserType>> GetUserTypeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<UserType>>> GetAllUserTypesAsync();
        Task<ApplicationResponse<bool>> UpdateUserTypeAsync(UpdateUserTypeRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteUserTypeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<UserType>>> FindUserTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
