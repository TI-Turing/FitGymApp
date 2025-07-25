using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.DailyExercise.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class DailyExerciseService : IDailyExerciseService
    {
        private readonly IDailyExerciseRepository _dailyExerciseRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public DailyExerciseService(IDailyExerciseRepository dailyExerciseRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _dailyExerciseRepository = dailyExerciseRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<DailyExercise>> CreateDailyExerciseAsync(AddDailyExerciseRequest request)
        {
            try
            {
                var entity = _mapper.Map<DailyExercise>(request);
                var created = await _dailyExerciseRepository.CreateDailyExerciseAsync(entity);
                return new ApplicationResponse<DailyExercise>
                {
                    Success = true,
                    Message = "Ejercicio diario creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<DailyExercise>
                {
                    Success = false,
                    Message = "Error técnico al crear el ejercicio diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<DailyExercise>> GetDailyExerciseByIdAsync(Guid id)
        {
            var entity = await _dailyExerciseRepository.GetDailyExerciseByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<DailyExercise>
                {
                    Success = false,
                    Message = "Ejercicio diario no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<DailyExercise>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<DailyExercise>>> GetAllDailyExercisesAsync()
        {
            var entities = await _dailyExerciseRepository.GetAllDailyExercisesAsync();
            return new ApplicationResponse<IEnumerable<DailyExercise>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateDailyExerciseAsync(UpdateDailyExerciseRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _dailyExerciseRepository.GetDailyExerciseByIdAsync(request.Id);
                var entity = _mapper.Map<DailyExercise>(request);
                var updated = await _dailyExerciseRepository.UpdateDailyExerciseAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("DailyExercise", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Ejercicio diario actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el ejercicio diario (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el ejercicio diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteDailyExerciseAsync(Guid id)
        {
            try
            {
                var deleted = await _dailyExerciseRepository.DeleteDailyExerciseAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Ejercicio diario eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Ejercicio diario no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el ejercicio diario.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<DailyExercise>>> FindDailyExercisesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _dailyExerciseRepository.FindDailyExercisesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<DailyExercise>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
