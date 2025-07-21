using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Schedule.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public ScheduleService(IScheduleRepository scheduleRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _scheduleRepository = scheduleRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<Schedule>> CreateScheduleAsync(AddScheduleRequest request)
        {
            try
            {
                var entity = new Schedule
                {
                    // Map properties from request to entity here
                    // Example:
                    // Name = request.Name,
                    // StartTime = request.StartTime,
                    // EndTime = request.EndTime,
                    // ...
                };
                var created = await _scheduleRepository.CreateScheduleAsync(entity);
                return new ApplicationResponse<Schedule>
                {
                    Success = true,
                    Message = "Horario creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Schedule>
                {
                    Success = false,
                    Message = "Error técnico al crear el horario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Schedule>> GetScheduleByIdAsync(Guid id)
        {
            var entity = await _scheduleRepository.GetScheduleByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<Schedule>
                {
                    Success = false,
                    Message = "Horario no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Schedule>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Schedule>>> GetAllSchedulesAsync()
        {
            var entities = await _scheduleRepository.GetAllSchedulesAsync();
            return new ApplicationResponse<IEnumerable<Schedule>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateScheduleAsync(UpdateScheduleRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _scheduleRepository.GetScheduleByIdAsync(request.Id);
                var entity = new Schedule
                {
                    Id = request.Id,
                    // Map other properties from request to entity here
                    // ...
                };
                var updated = await _scheduleRepository.UpdateScheduleAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Schedule", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Horario actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el horario (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el horario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteScheduleAsync(Guid id)
        {
            try
            {
                var deleted = await _scheduleRepository.DeleteScheduleAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Horario eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Horario no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el horario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Schedule>>> FindSchedulesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _scheduleRepository.FindSchedulesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Schedule>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
