using AutoMapper;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.DTO.EmployeeUser.Request;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitGymApp.Application.Services
{
    public class EmployeeUserService : IEmployeeUserService
    {
        private readonly IEmployeeUserRepository _employeeUserRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public EmployeeUserService(IEmployeeUserRepository employeeUserRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _employeeUserRepository = employeeUserRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<EmployeeUser>> CreateEmployeeUserAsync(AddEmployeeUserRequest request)
        {
            try
            {
                var entity = _mapper.Map<EmployeeUser>(request);
                var created = await _employeeUserRepository.CreateEmployeeUserAsync(entity);
                return new ApplicationResponse<EmployeeUser>
                {
                    Success = true,
                    Message = "Empleado usuario creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<EmployeeUser>
                {
                    Success = false,
                    Message = "Error técnico al crear el empleado usuario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<EmployeeUser>> GetEmployeeUserByIdAsync(Guid id)
        {
            var entity = await _employeeUserRepository.GetEmployeeUserByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<EmployeeUser>
                {
                    Success = false,
                    Message = "Empleado usuario no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<EmployeeUser>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<EmployeeUser>>> GetAllEmployeeUsersAsync()
        {
            var entities = await _employeeUserRepository.GetAllEmployeeUsersAsync();
            return new ApplicationResponse<IEnumerable<EmployeeUser>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateEmployeeUserAsync(UpdateEmployeeUserRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _employeeUserRepository.GetEmployeeUserByIdAsync(request.Id);
                var entity = _mapper.Map<EmployeeUser>(request);
                var updated = await _employeeUserRepository.UpdateEmployeeUserAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("EmployeeUser", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Empleado usuario actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el empleado usuario (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el empleado usuario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteEmployeeUserAsync(Guid id)
        {
            try
            {
                var deleted = await _employeeUserRepository.DeleteEmployeeUserAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Empleado usuario eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Empleado usuario no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el empleado usuario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<EmployeeUser>>> FindEmployeeUsersByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _employeeUserRepository.FindEmployeeUsersByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<EmployeeUser>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
