using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Exercise.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<Exercise>> CreateExerciseAsync(AddExerciseRequest request)
        {
            try
            {
                var entity = _mapper.Map<Exercise>(request);
                var created = await _exerciseRepository.CreateExerciseAsync(entity);
                return new ApplicationResponse<Exercise>
                {
                    Success = true,
                    Message = "Ejercicio creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Exercise>
                {
                    Success = false,
                    Message = "Error técnico al crear el ejercicio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Exercise>> GetExerciseByIdAsync(Guid id)
        {
            var entity = await _exerciseRepository.GetExerciseByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<Exercise>
                {
                    Success = false,
                    Message = "Ejercicio no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Exercise>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Exercise>>> GetAllExercisesAsync()
        {
            var entities = await _exerciseRepository.GetAllExercisesAsync();
            return new ApplicationResponse<IEnumerable<Exercise>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateExerciseAsync(UpdateExerciseRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _exerciseRepository.GetExerciseByIdAsync(request.Id);
                var entity = _mapper.Map<Exercise>(request);
                var updated = await _exerciseRepository.UpdateExerciseAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Exercise", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Ejercicio actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el ejercicio (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el ejercicio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteExerciseAsync(Guid id)
        {
            try
            {
                var deleted = await _exerciseRepository.DeleteExerciseAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Ejercicio eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Ejercicio no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el ejercicio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Exercise>>> FindExercisesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _exerciseRepository.FindExercisesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Exercise>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
