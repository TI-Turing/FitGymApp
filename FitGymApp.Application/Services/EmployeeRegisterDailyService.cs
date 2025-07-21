using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.EmployeeRegisterDaily.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class EmployeeRegisterDailyService : IEmployeeRegisterDailyService
    {
        private readonly IEmployeeRegisterDailyRepository _employeeRegisterDailyRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public EmployeeRegisterDailyService(IEmployeeRegisterDailyRepository employeeRegisterDailyRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _employeeRegisterDailyRepository = employeeRegisterDailyRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<EmployeeRegisterDaily>> CreateEmployeeRegisterDailyAsync(AddEmployeeRegisterDailyRequest request)
        {
            try
            {
                var entity = new EmployeeRegisterDaily
                {
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Ip = request.Ip
                };
                var created = await _employeeRegisterDailyRepository.CreateEmployeeRegisterDailyAsync(entity);
                return new ApplicationResponse<EmployeeRegisterDaily>
                {
                    Success = true,
                    Message = "Registro diario de empleado creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<EmployeeRegisterDaily>
                {
                    Success = false,
                    Message = "Error técnico al crear el registro diario de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<EmployeeRegisterDaily>> GetEmployeeRegisterDailyByIdAsync(Guid id)
        {
            var entity = await _employeeRegisterDailyRepository.GetEmployeeRegisterDailyByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<EmployeeRegisterDaily>
                {
                    Success = false,
                    Message = "Registro diario de empleado no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<EmployeeRegisterDaily>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<EmployeeRegisterDaily>>> GetAllEmployeeRegisterDailiesAsync()
        {
            var entities = await _employeeRegisterDailyRepository.GetAllEmployeeRegisterDailiesAsync();
            return new ApplicationResponse<IEnumerable<EmployeeRegisterDaily>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateEmployeeRegisterDailyAsync(UpdateEmployeeRegisterDailyRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _employeeRegisterDailyRepository.GetEmployeeRegisterDailyByIdAsync(request.Id);
                var entity = new EmployeeRegisterDaily
                {
                    Id = request.Id,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _employeeRegisterDailyRepository.UpdateEmployeeRegisterDailyAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("EmployeeRegisterDaily", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Registro diario de empleado actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el registro diario de empleado (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el registro diario de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteEmployeeRegisterDailyAsync(Guid id)
        {
            try
            {
                var deleted = await _employeeRegisterDailyRepository.DeleteEmployeeRegisterDailyAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Registro diario de empleado eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Registro diario de empleado no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el registro diario de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<EmployeeRegisterDaily>>> FindEmployeeRegisterDailiesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _employeeRegisterDailyRepository.FindEmployeeRegisterDailiesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<EmployeeRegisterDaily>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
