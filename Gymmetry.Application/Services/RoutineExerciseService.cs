using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.RoutineExercise.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class RoutineExerciseService : IRoutineExerciseService
    {
        private readonly IRoutineExerciseRepository _routineExerciseRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public RoutineExerciseService(IRoutineExerciseRepository routineExerciseRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _routineExerciseRepository = routineExerciseRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<RoutineExercise>> CreateRoutineExerciseAsync(AddRoutineExerciseRequest request)
        {
            try
            {
                var entity = _mapper.Map<RoutineExercise>(request);
                var created = await _routineExerciseRepository.CreateRoutineExerciseAsync(entity);
                return new ApplicationResponse<RoutineExercise>
                {
                    Success = true,
                    Message = "Ejercicio de rutina creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<RoutineExercise>
                {
                    Success = false,
                    Message = "Error técnico al crear el ejercicio de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<RoutineExercise>> GetRoutineExerciseByIdAsync(Guid id)
        {
            var entity = await _routineExerciseRepository.GetRoutineExerciseByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<RoutineExercise>
                {
                    Success = false,
                    Message = "Ejercicio de rutina no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<RoutineExercise>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineExercise>>> GetAllRoutineExercisesAsync()
        {
            var entities = await _routineExerciseRepository.GetAllRoutineExercisesAsync();
            return new ApplicationResponse<IEnumerable<RoutineExercise>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateRoutineExerciseAsync(UpdateRoutineExerciseRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _routineExerciseRepository.GetRoutineExerciseByIdAsync(request.Id);
                var entity = _mapper.Map<RoutineExercise>(request);
                var updated = await _routineExerciseRepository.UpdateRoutineExerciseAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("RoutineExercise", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Ejercicio de rutina actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el ejercicio de rutina (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el ejercicio de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteRoutineExerciseAsync(Guid id)
        {
            try
            {
                var deleted = await _routineExerciseRepository.DeleteRoutineExerciseAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Ejercicio de rutina eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Ejercicio de rutina no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el ejercicio de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineExercise>>> FindRoutineExercisesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _routineExerciseRepository.FindRoutineExercisesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<RoutineExercise>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
