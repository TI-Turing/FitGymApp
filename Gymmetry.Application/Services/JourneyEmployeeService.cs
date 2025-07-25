using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.JourneyEmployee.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class JourneyEmployeeService : IJourneyEmployeeService
    {
        private readonly IJourneyEmployeeRepository _journeyEmployeeRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public JourneyEmployeeService(IJourneyEmployeeRepository journeyEmployeeRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _journeyEmployeeRepository = journeyEmployeeRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<JourneyEmployee>> CreateJourneyEmployeeAsync(AddJourneyEmployeeRequest request)
        {
            try
            {
                var entity = new JourneyEmployee
                {
                    Name = request.Name,
                    StartHour = request.StartHour,
                    EndHour = request.EndHour,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    EmployeeUserId = request.EmployeeUserId
                };
                var created = await _journeyEmployeeRepository.CreateJourneyEmployeeAsync(entity);
                return new ApplicationResponse<JourneyEmployee>
                {
                    Success = true,
                    Message = "Jornada de empleado creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<JourneyEmployee>
                {
                    Success = false,
                    Message = "Error técnico al crear la jornada de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<JourneyEmployee>> GetJourneyEmployeeByIdAsync(Guid id)
        {
            var entity = await _journeyEmployeeRepository.GetJourneyEmployeeByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<JourneyEmployee>
                {
                    Success = false,
                    Message = "Jornada de empleado no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<JourneyEmployee>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<JourneyEmployee>>> GetAllJourneyEmployeesAsync()
        {
            var entities = await _journeyEmployeeRepository.GetAllJourneyEmployeesAsync();
            return new ApplicationResponse<IEnumerable<JourneyEmployee>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateJourneyEmployeeAsync(UpdateJourneyEmployeeRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _journeyEmployeeRepository.GetJourneyEmployeeByIdAsync(request.Id);
                var entity = new JourneyEmployee
                {
                    Id = request.Id,
                    Name = request.Name,
                    StartHour = request.StartHour,
                    EndHour = request.EndHour,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    EmployeeUserId = request.EmployeeUserId
                };
                var updated = await _journeyEmployeeRepository.UpdateJourneyEmployeeAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("JourneyEmployee", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Jornada de empleado actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la jornada de empleado (no encontrada o inactiva).",
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
                    Message = "Error técnico al actualizar la jornada de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteJourneyEmployeeAsync(Guid id)
        {
            try
            {
                var deleted = await _journeyEmployeeRepository.DeleteJourneyEmployeeAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Jornada de empleado eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Jornada de empleado no encontrada o ya eliminada.",
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
                    Message = "Error técnico al eliminar la jornada de empleado.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<JourneyEmployee>>> FindJourneyEmployeesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _journeyEmployeeRepository.FindJourneyEmployeesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<JourneyEmployee>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
