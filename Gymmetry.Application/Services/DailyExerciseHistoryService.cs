using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.DailyExerciseHistory.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class DailyExerciseHistoryService : IDailyExerciseHistoryService
    {
        private readonly IDailyExerciseHistoryRepository _dailyExerciseHistoryRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public DailyExerciseHistoryService(IDailyExerciseHistoryRepository dailyExerciseHistoryRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _dailyExerciseHistoryRepository = dailyExerciseHistoryRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<DailyExerciseHistory>> CreateDailyExerciseHistoryAsync(AddDailyExerciseHistoryRequest request)
        {
            try
            {
                var entity = _mapper.Map<DailyExerciseHistory>(request);
                var created = await _dailyExerciseHistoryRepository.CreateDailyExerciseHistoryAsync(entity);
                return new ApplicationResponse<DailyExerciseHistory>
                {
                    Success = true,
                    Message = "Historial de ejercicio diario creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<DailyExerciseHistory>
                {
                    Success = false,
                    Message = "Error técnico al crear el historial de ejercicio diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<DailyExerciseHistory>> GetDailyExerciseHistoryByIdAsync(Guid id)
        {
            var entity = await _dailyExerciseHistoryRepository.GetDailyExerciseHistoryByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<DailyExerciseHistory>
                {
                    Success = false,
                    Message = "Historial de ejercicio diario no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<DailyExerciseHistory>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<DailyExerciseHistory>>> GetAllDailyExerciseHistoriesAsync()
        {
            var entities = await _dailyExerciseHistoryRepository.GetAllDailyExerciseHistoriesAsync();
            return new ApplicationResponse<IEnumerable<DailyExerciseHistory>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateDailyExerciseHistoryAsync(UpdateDailyExerciseHistoryRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _dailyExerciseHistoryRepository.GetDailyExerciseHistoryByIdAsync(request.Id);
                var entity = _mapper.Map<DailyExerciseHistory>(request);
                var updated = await _dailyExerciseHistoryRepository.UpdateDailyExerciseHistoryAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("DailyExerciseHistory", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Historial de ejercicio diario actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el historial de ejercicio diario (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el historial de ejercicio diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteDailyExerciseHistoryAsync(Guid id)
        {
            try
            {
                var deleted = await _dailyExerciseHistoryRepository.DeleteDailyExerciseHistoryAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Historial de ejercicio diario eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Historial de ejercicio diario no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el historial de ejercicio diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<DailyExerciseHistory>>> FindDailyExerciseHistoriesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _dailyExerciseHistoryRepository.FindDailyExerciseHistoriesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<DailyExerciseHistory>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
