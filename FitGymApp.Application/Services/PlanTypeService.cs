using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.PlanType.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class PlanTypeService : IPlanTypeService
    {
        private readonly IPlanTypeRepository _planTypeRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public PlanTypeService(IPlanTypeRepository planTypeRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _planTypeRepository = planTypeRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<PlanType>> CreatePlanTypeAsync(AddPlanTypeRequest request)
        {
            try
            {
                var entity = new PlanType
                {
                    Name = request.Name,
                    Ip = request.Ip
                };
                var created = await _planTypeRepository.CreatePlanTypeAsync(entity);
                return new ApplicationResponse<PlanType>
                {
                    Success = true,
                    Message = "Tipo de plan creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<PlanType>
                {
                    Success = false,
                    Message = "Error técnico al crear el tipo de plan.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<PlanType>> GetPlanTypeByIdAsync(Guid id)
        {
            var entity = await _planTypeRepository.GetPlanTypeByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<PlanType>
                {
                    Success = false,
                    Message = "Tipo de plan no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<PlanType>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<PlanType>>> GetAllPlanTypesAsync()
        {
            var entities = await _planTypeRepository.GetAllPlanTypesAsync();
            return new ApplicationResponse<IEnumerable<PlanType>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdatePlanTypeAsync(UpdatePlanTypeRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _planTypeRepository.GetPlanTypeByIdAsync(request.Id);
                var entity = new PlanType
                {
                    Id = request.Id,
                    Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _planTypeRepository.UpdatePlanTypeAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("PlanType", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de plan actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el tipo de plan (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el tipo de plan.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeletePlanTypeAsync(Guid id)
        {
            try
            {
                var deleted = await _planTypeRepository.DeletePlanTypeAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de plan eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Tipo de plan no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el tipo de plan.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<PlanType>>> FindPlanTypesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _planTypeRepository.FindPlanTypesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<PlanType>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
