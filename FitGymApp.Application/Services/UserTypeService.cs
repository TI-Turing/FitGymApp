using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.UserType.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public UserTypeService(IUserTypeRepository userTypeRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _userTypeRepository = userTypeRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<UserType>> CreateUserTypeAsync(AddUserTypeRequest request)
        {
            try
            {
                var entity = new UserType
                {
                    Name = request.Name,
                    Ip = request.Ip
                };
                var created = await _userTypeRepository.CreateUserTypeAsync(entity);
                return new ApplicationResponse<UserType>
                {
                    Success = true,
                    Message = "Tipo de usuario creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<UserType>
                {
                    Success = false,
                    Message = "Error técnico al crear el tipo de usuario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<UserType>> GetUserTypeByIdAsync(Guid id)
        {
            var entity = await _userTypeRepository.GetUserTypeByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<UserType>
                {
                    Success = false,
                    Message = "Tipo de usuario no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<UserType>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<UserType>>> GetAllUserTypesAsync()
        {
            var entities = await _userTypeRepository.GetAllUserTypesAsync();
            return new ApplicationResponse<IEnumerable<UserType>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateUserTypeAsync(UpdateUserTypeRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _userTypeRepository.GetUserTypeByIdAsync(request.Id);
                var entity = new UserType
                {
                    Id = request.Id,
                    Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _userTypeRepository.UpdateUserTypeAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("UserType", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de usuario actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el tipo de usuario (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el tipo de usuario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteUserTypeAsync(Guid id)
        {
            try
            {
                var deleted = await _userTypeRepository.DeleteUserTypeAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de usuario eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Tipo de usuario no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el tipo de usuario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<UserType>>> FindUserTypesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _userTypeRepository.FindUserTypesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<UserType>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
