using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.GymPlanSelectedModule.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;
using AutoMapper;

namespace FitGymApp.Application.Services
{
    public class GymPlanSelectedModuleService : IGymPlanSelectedModuleService
    {
        private readonly IGymPlanSelectedModuleRepository _gymPlanSelectedModuleRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public GymPlanSelectedModuleService(IGymPlanSelectedModuleRepository gymPlanSelectedModuleRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _gymPlanSelectedModuleRepository = gymPlanSelectedModuleRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<GymPlanSelectedModule>> CreateGymPlanSelectedModuleAsync(AddGymPlanSelectedModuleRequest request)
        {
            try
            {
                var entity = _mapper.Map<GymPlanSelectedModule>(request);
                var created = await _gymPlanSelectedModuleRepository.CreateGymPlanSelectedModuleAsync(entity);
                return new ApplicationResponse<GymPlanSelectedModule>
                {
                    Success = true,
                    Message = "Módulo de plan seleccionado de gimnasio creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<GymPlanSelectedModule>
                {
                    Success = false,
                    Message = "Error técnico al crear el módulo de plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<GymPlanSelectedModule>> GetGymPlanSelectedModuleByIdAsync(Guid id)
        {
            var entity = await _gymPlanSelectedModuleRepository.GetGymPlanSelectedModuleByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<GymPlanSelectedModule>
                {
                    Success = false,
                    Message = "Módulo de plan seleccionado de gimnasio no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<GymPlanSelectedModule>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<GymPlanSelectedModule>>> GetAllGymPlanSelectedModulesAsync()
        {
            var entities = await _gymPlanSelectedModuleRepository.GetAllGymPlanSelectedModulesAsync();
            return new ApplicationResponse<IEnumerable<GymPlanSelectedModule>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateGymPlanSelectedModuleAsync(UpdateGymPlanSelectedModuleRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _gymPlanSelectedModuleRepository.GetGymPlanSelectedModuleByIdAsync(request.Id);
                var entity = _mapper.Map<GymPlanSelectedModule>(request);
                var updated = await _gymPlanSelectedModuleRepository.UpdateGymPlanSelectedModuleAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("GymPlanSelectedModule", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Módulo de plan seleccionado de gimnasio actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el módulo de plan seleccionado de gimnasio (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el módulo de plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteGymPlanSelectedModuleAsync(Guid id)
        {
            try
            {
                var deleted = await _gymPlanSelectedModuleRepository.DeleteGymPlanSelectedModuleAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Módulo de plan seleccionado de gimnasio eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Módulo de plan seleccionado de gimnasio no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el módulo de plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<GymPlanSelectedModule>>> FindGymPlanSelectedModulesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _gymPlanSelectedModuleRepository.FindGymPlanSelectedModulesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<GymPlanSelectedModule>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
