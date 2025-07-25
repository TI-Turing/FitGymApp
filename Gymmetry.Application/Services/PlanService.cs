using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Plan.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public PlanService(IPlanRepository planRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _planRepository = planRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<Plan>> CreatePlanAsync(AddPlanRequest request)
        {
            try
            {
                var entity = _mapper.Map<Plan>(request);
                var created = await _planRepository.CreatePlanAsync(entity);
                return new ApplicationResponse<Plan>
                {
                    Success = true,
                    Message = "Plan creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Plan>
                {
                    Success = false,
                    Message = "Error técnico al crear el plan.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Plan>> GetPlanByIdAsync(Guid id)
        {
            var entity = await _planRepository.GetPlanByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<Plan>
                {
                    Success = false,
                    Message = "Plan no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Plan>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Plan>>> GetAllPlansAsync()
        {
            var entities = await _planRepository.GetAllPlansAsync();
            return new ApplicationResponse<IEnumerable<Plan>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdatePlanAsync(UpdatePlanRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _planRepository.GetPlanByIdAsync(request.Id);
                var entity = _mapper.Map<Plan>(request);
                var updated = await _planRepository.UpdatePlanAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Plan", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Plan actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el plan (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el plan.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeletePlanAsync(Guid id)
        {
            try
            {
                var deleted = await _planRepository.DeletePlanAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Plan eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Plan no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el plan.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Plan>>> FindPlansByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _planRepository.FindPlansByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Plan>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
