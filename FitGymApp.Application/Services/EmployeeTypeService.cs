using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.EmployeeType.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public EmployeeTypeService(IEmployeeTypeRepository employeeTypeRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<EmployeeType>> CreateEmployeeTypeAsync(AddEmployeeTypeRequest request)
        {
            try
            {
                var entity = new EmployeeType
                {
                    Name = request.Name,
                    Ip = request.Ip
                };
                var created = await _employeeTypeRepository.CreateEmployeeTypeAsync(entity);
                return new ApplicationResponse<EmployeeType>
                {
                    Success = true,
                    Message = "Tipo de empleado creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<EmployeeType>
                {
                    Success = false,
                    Message = "Error técnico al crear el tipo de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<EmployeeType>> GetEmployeeTypeByIdAsync(Guid id)
        {
            var entity = await _employeeTypeRepository.GetEmployeeTypeByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<EmployeeType>
                {
                    Success = false,
                    Message = "Tipo de empleado no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<EmployeeType>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<EmployeeType>>> GetAllEmployeeTypesAsync()
        {
            var entities = await _employeeTypeRepository.GetAllEmployeeTypesAsync();
            return new ApplicationResponse<IEnumerable<EmployeeType>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateEmployeeTypeAsync(UpdateEmployeeTypeRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _employeeTypeRepository.GetEmployeeTypeByIdAsync(request.Id);
                var entity = new EmployeeType
                {
                    Id = request.Id,
                    Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _employeeTypeRepository.UpdateEmployeeTypeAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("EmployeeType", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de empleado actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el tipo de empleado (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el tipo de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteEmployeeTypeAsync(Guid id)
        {
            try
            {
                var deleted = await _employeeTypeRepository.DeleteEmployeeTypeAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de empleado eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Tipo de empleado no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el tipo de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<EmployeeType>>> FindEmployeeTypesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _employeeTypeRepository.FindEmployeeTypesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<EmployeeType>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
