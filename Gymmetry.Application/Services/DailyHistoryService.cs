using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.DailyHistory.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class DailyHistoryService : IDailyHistoryService
    {
        private readonly IDailyHistoryRepository _dailyHistoryRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public DailyHistoryService(IDailyHistoryRepository dailyHistoryRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _dailyHistoryRepository = dailyHistoryRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<DailyHistory>> CreateDailyHistoryAsync(AddDailyHistoryRequest request)
        {
            try
            {
                var entity = _mapper.Map<DailyHistory>(request);
                var created = await _dailyHistoryRepository.CreateDailyHistoryAsync(entity);
                return new ApplicationResponse<DailyHistory>
                {
                    Success = true,
                    Message = "Historial diario creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<DailyHistory>
                {
                    Success = false,
                    Message = "Error técnico al crear el historial diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<DailyHistory>> GetDailyHistoryByIdAsync(Guid id)
        {
            var entity = await _dailyHistoryRepository.GetDailyHistoryByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<DailyHistory>
                {
                    Success = false,
                    Message = "Historial diario no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<DailyHistory>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<DailyHistory>>> GetAllDailyHistoriesAsync()
        {
            var entities = await _dailyHistoryRepository.GetAllDailyHistoriesAsync();
            return new ApplicationResponse<IEnumerable<DailyHistory>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateDailyHistoryAsync(UpdateDailyHistoryRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _dailyHistoryRepository.GetDailyHistoryByIdAsync(request.Id);
                var entity = _mapper.Map<DailyHistory>(request);
                var updated = await _dailyHistoryRepository.UpdateDailyHistoryAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("DailyHistory", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Historial diario actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el historial diario (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el historial diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteDailyHistoryAsync(Guid id)
        {
            try
            {
                var deleted = await _dailyHistoryRepository.DeleteDailyHistoryAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Historial diario eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Historial diario no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el historial diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<DailyHistory>>> FindDailyHistoriesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _dailyHistoryRepository.FindDailyHistoriesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<DailyHistory>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
