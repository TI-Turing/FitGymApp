using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Diet.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;
using AutoMapper;

namespace FitGymApp.Application.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public DietService(IDietRepository dietRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<Diet>> CreateDietAsync(AddDietRequest request)
        {
            try
            {
                var diet = _mapper.Map<Diet>(request);
                var created = await _dietRepository.CreateDietAsync(diet);
                return new ApplicationResponse<Diet>
                {
                    Success = true,
                    Message = "Dieta creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Diet>
                {
                    Success = false,
                    Message = "Error técnico al crear la dieta.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Diet>> GetDietByIdAsync(Guid id)
        {
            var diet = await _dietRepository.GetDietByIdAsync(id);
            if (diet == null)
            {
                return new ApplicationResponse<Diet>
                {
                    Success = false,
                    Message = "Dieta no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Diet>
            {
                Success = true,
                Data = diet
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Diet>>> GetAllDietsAsync()
        {
            var diets = await _dietRepository.GetAllDietsAsync();
            return new ApplicationResponse<IEnumerable<Diet>>
            {
                Success = true,
                Data = diets
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateDietAsync(UpdateDietRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var dietBefore = await _dietRepository.GetDietByIdAsync(request.Id);
                var diet = _mapper.Map<Diet>(request);
                var updated = await _dietRepository.UpdateDietAsync(diet);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Diet", dietBefore, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Dieta actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la dieta (no encontrada o inactiva).",
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
                    Message = "Error técnico al actualizar la dieta.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteDietAsync(Guid id)
        {
            try
            {
                var deleted = await _dietRepository.DeleteDietAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Dieta eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Dieta no encontrada o ya eliminada.",
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
                    Message = "Error técnico al eliminar la dieta.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Diet>>> FindDietsByFieldsAsync(Dictionary<string, object> filters)
        {
            var diets = await _dietRepository.FindDietsByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Diet>>
            {
                Success = true,
                Data = diets
            };
        }
    }
}
