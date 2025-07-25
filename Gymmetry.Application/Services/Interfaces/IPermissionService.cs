using System;
using System.Collections.Generic;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Permission.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<ApplicationResponse<Permission>> CreatePermissionAsync(AddPermissionRequest request);
        Task<ApplicationResponse<Permission>> GetPermissionByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Permission>>> GetAllPermissionsAsync();
        Task<ApplicationResponse<bool>> UpdatePermissionAsync(UpdatePermissionRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeletePermissionAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Permission>>> FindPermissionsByFieldsAsync(Dictionary<string, object> filters);
    }
}
