using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.GymPlanSelectedType.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class GymPlanSelectedTypeService : IGymPlanSelectedTypeService
    {
        private readonly IGymPlanSelectedTypeRepository _gymPlanSelectedTypeRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public GymPlanSelectedTypeService(
            IGymPlanSelectedTypeRepository gymPlanSelectedTypeRepository,
            ILogChangeService logChangeService,
            ILogErrorService logErrorService)
        {
            _gymPlanSelectedTypeRepository = gymPlanSelectedTypeRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<GymPlanSelectedType>> CreateGymPlanSelectedTypeAsync(AddGymPlanSelectedTypeRequest request)
        {
            try
            {
                var entity = new GymPlanSelectedType
                {
                    Name = request.Name,
                    Ip = request.Ip
                };
                var created = await _gymPlanSelectedTypeRepository.CreateGymPlanSelectedTypeAsync(entity);
                return new ApplicationResponse<GymPlanSelectedType>
                {
                    Success = true,
                    Message = "Tipo de plan seleccionado de gimnasio creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<GymPlanSelectedType>
                {
                    Success = false,
                    Message = "Error técnico al crear el tipo de plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<GymPlanSelectedType>> GetGymPlanSelectedTypeByIdAsync(Guid id)
        {
            var entity = await _gymPlanSelectedTypeRepository.GetGymPlanSelectedTypeByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<GymPlanSelectedType>
                {
                    Success = false,
                    Message = "Tipo de plan seleccionado de gimnasio no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<GymPlanSelectedType>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<GymPlanSelectedType>>> GetAllGymPlanSelectedTypesAsync()
        {
            var entities = await _gymPlanSelectedTypeRepository.GetAllGymPlanSelectedTypesAsync();
            return new ApplicationResponse<IEnumerable<GymPlanSelectedType>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateGymPlanSelectedTypeAsync(UpdateGymPlanSelectedTypeRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _gymPlanSelectedTypeRepository.GetGymPlanSelectedTypeByIdAsync(request.Id);
                var entity = new GymPlanSelectedType
                {
                    Id = request.Id,
                    Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _gymPlanSelectedTypeRepository.UpdateGymPlanSelectedTypeAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("GymPlanSelectedType", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de plan seleccionado de gimnasio actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el tipo de plan seleccionado de gimnasio (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el tipo de plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteGymPlanSelectedTypeAsync(Guid id)
        {
            try
            {
                var deleted = await _gymPlanSelectedTypeRepository.DeleteGymPlanSelectedTypeAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de plan seleccionado de gimnasio eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Tipo de plan seleccionado de gimnasio no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el tipo de plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<GymPlanSelectedType>>> FindGymPlanSelectedTypesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _gymPlanSelectedTypeRepository.FindGymPlanSelectedTypesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<GymPlanSelectedType>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
