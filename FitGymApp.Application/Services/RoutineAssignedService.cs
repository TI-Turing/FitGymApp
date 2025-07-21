using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.RoutineAssigned.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class RoutineAssignedService : IRoutineAssignedService
    {
        private readonly IRoutineAssignedRepository _routineAssignedRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public RoutineAssignedService(IRoutineAssignedRepository routineAssignedRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _routineAssignedRepository = routineAssignedRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<RoutineAssigned>> CreateRoutineAssignedAsync(AddRoutineAssignedRequest request)
        {
            try
            {
                var entity = new RoutineAssigned
                {
                    Comments = request.Comments,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    UserId = request.UserId
                };
                var created = await _routineAssignedRepository.CreateRoutineAssignedAsync(entity);
                return new ApplicationResponse<RoutineAssigned>
                {
                    Success = true,
                    Message = "Rutina asignada creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<RoutineAssigned>
                {
                    Success = false,
                    Message = "Error técnico al crear la rutina asignada.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<RoutineAssigned>> GetRoutineAssignedByIdAsync(Guid id)
        {
            var entity = await _routineAssignedRepository.GetRoutineAssignedByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<RoutineAssigned>
                {
                    Success = false,
                    Message = "Rutina asignada no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<RoutineAssigned>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineAssigned>>> GetAllRoutineAssignedsAsync()
        {
            var entities = await _routineAssignedRepository.GetAllRoutineAssignedsAsync();
            return new ApplicationResponse<IEnumerable<RoutineAssigned>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateRoutineAssignedAsync(UpdateRoutineAssignedRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _routineAssignedRepository.GetRoutineAssignedByIdAsync(request.Id);
                var entity = new RoutineAssigned
                {
                    Id = request.Id,
                    Comments = request.Comments,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    UserId = request.UserId
                };
                var updated = await _routineAssignedRepository.UpdateRoutineAssignedAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("RoutineAssigned", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Rutina asignada actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la rutina asignada (no encontrada o inactiva).",
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
                    Message = "Error técnico al actualizar la rutina asignada.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteRoutineAssignedAsync(Guid id)
        {
            try
            {
                var deleted = await _routineAssignedRepository.DeleteRoutineAssignedAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Rutina asignada eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Rutina asignada no encontrada o ya eliminada.",
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
                    Message = "Error técnico al eliminar la rutina asignada.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineAssigned>>> FindRoutineAssignedsByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _routineAssignedRepository.FindRoutineAssignedsByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<RoutineAssigned>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
