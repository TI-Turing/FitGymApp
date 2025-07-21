using System;
using System.Collections.Generic;
using System.Linq;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Permission.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public PermissionService(IPermissionRepository permissionRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _permissionRepository = permissionRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<Permission>> CreatePermissionAsync(AddPermissionRequest request)
        {
            try
            {
                var entity = new Permission
                {
                    See = request.See,
                    Create = request.Create,
                    Read = request.Read,
                    Update = request.Update,
                    Delete = request.Delete,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    UserTypeId = request.UserTypeId,
                    UserId = request.UserId
                };
                var created = await _permissionRepository.CreatePermissionAsync(entity);
                return new ApplicationResponse<Permission>
                {
                    Success = true,
                    Message = "Permiso creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Permission>
                {
                    Success = false,
                    Message = "Error técnico al crear el permiso.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Permission>> GetPermissionByIdAsync(Guid id)
        {
            var entity = await _permissionRepository.GetPermissionByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<Permission>
                {
                    Success = false,
                    Message = "Permiso no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Permission>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Permission>>> GetAllPermissionsAsync()
        {
            var entities = await _permissionRepository.GetAllPermissionsAsync();
            return new ApplicationResponse<IEnumerable<Permission>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdatePermissionAsync(UpdatePermissionRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _permissionRepository.GetPermissionByIdAsync(request.Id);
                var entity = new Permission
                {
                    Id = request.Id,
                    See = request.See,
                    Create = request.Create,
                    Read = request.Read,
                    Update = request.Update,
                    Delete = request.Delete,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    UserTypeId = request.UserTypeId,
                    UserId = request.UserId
                };
                var updated = await _permissionRepository.UpdatePermissionAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Permission", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Permiso actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el permiso (no encontrado o inactivo).",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar el permiso.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeletePermissionAsync(Guid id)
        {
            try
            {
                var deleted = await _permissionRepository.DeletePermissionAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Permiso eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Permiso no encontrado o ya eliminado.",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al eliminar el permiso.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Permission>>> FindPermissionsByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _permissionRepository.FindPermissionsByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Permission>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
