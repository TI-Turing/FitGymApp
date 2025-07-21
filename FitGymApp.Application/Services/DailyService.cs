using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Daily.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;
using AutoMapper;

namespace FitGymApp.Application.Services
{
    public class DailyService : IDailyService
    {
        private readonly IDailyRepository _dailyRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public DailyService(IDailyRepository dailyRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _dailyRepository = dailyRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<Daily>> CreateDailyAsync(AddDailyRequest request)
        {
            try
            {
                var daily = _mapper.Map<Daily>(request);
                var created = await _dailyRepository.CreateDailyAsync(daily);
                return new ApplicationResponse<Daily>
                {
                    Success = true,
                    Message = "Registro diario creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Daily>
                {
                    Success = false,
                    Message = "Error técnico al crear el registro diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Daily>> GetDailyByIdAsync(Guid id)
        {
            var daily = await _dailyRepository.GetDailyByIdAsync(id);
            if (daily == null)
            {
                return new ApplicationResponse<Daily>
                {
                    Success = false,
                    Message = "Registro diario no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Daily>
            {
                Success = true,
                Data = daily
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Daily>>> GetAllDailiesAsync()
        {
            var dailies = await _dailyRepository.GetAllDailiesAsync();
            return new ApplicationResponse<IEnumerable<Daily>>
            {
                Success = true,
                Data = dailies
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateDailyAsync(UpdateDailyRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var dailyBefore = await _dailyRepository.GetDailyByIdAsync(request.Id);
                var daily = _mapper.Map<Daily>(request);
                var updated = await _dailyRepository.UpdateDailyAsync(daily);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Daily", dailyBefore, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Registro diario actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el registro diario (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el registro diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteDailyAsync(Guid id)
        {
            try
            {
                var deleted = await _dailyRepository.DeleteDailyAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Registro diario eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Registro diario no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el registro diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Daily>>> FindDailiesByFieldsAsync(Dictionary<string, object> filters)
        {
            var dailies = await _dailyRepository.FindDailiesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Daily>>
            {
                Success = true,
                Data = dailies
            };
        }
    }
}
