using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.CategoryExercise.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class CategoryExerciseService : ICategoryExerciseService
    {
        private readonly ICategoryExerciseRepository _categoryExerciseRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public CategoryExerciseService(ICategoryExerciseRepository categoryExerciseRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _categoryExerciseRepository = categoryExerciseRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<CategoryExercise>> CreateCategoryExerciseAsync(AddCategoryExerciseRequest request)
        {
            try
            {
                var entity = _mapper.Map<CategoryExercise>(request);
                var created = await _categoryExerciseRepository.CreateCategoryExerciseAsync(entity);
                return new ApplicationResponse<CategoryExercise>
                {
                    Success = true,
                    Message = "Categoría de ejercicio creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<CategoryExercise>
                {
                    Success = false,
                    Message = "Error técnico al crear la categoría de ejercicio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<CategoryExercise>> GetCategoryExerciseByIdAsync(Guid id)
        {
            var entity = await _categoryExerciseRepository.GetCategoryExerciseByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<CategoryExercise>
                {
                    Success = false,
                    Message = "Categoría de ejercicio no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<CategoryExercise>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<CategoryExercise>>> GetAllCategoryExercisesAsync()
        {
            var entities = await _categoryExerciseRepository.GetAllCategoryExercisesAsync();
            return new ApplicationResponse<IEnumerable<CategoryExercise>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateCategoryExerciseAsync(UpdateCategoryExerciseRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _categoryExerciseRepository.GetCategoryExerciseByIdAsync(request.Id);
                var entity = _mapper.Map<CategoryExercise>(request);
                var updated = await _categoryExerciseRepository.UpdateCategoryExerciseAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("CategoryExercise", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Categoría de ejercicio actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la categoría de ejercicio (no encontrada o inactiva).",
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
                    Message = "Error técnico al actualizar la categoría de ejercicio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteCategoryExerciseAsync(Guid id)
        {
            try
            {
                var deleted = await _categoryExerciseRepository.DeleteCategoryExerciseAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Categoría de ejercicio eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Categoría de ejercicio no encontrada o ya eliminada.",
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
                    Message = "Error técnico al eliminar la categoría de ejercicio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<CategoryExercise>>> FindCategoryExercisesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _categoryExerciseRepository.FindCategoryExercisesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<CategoryExercise>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
