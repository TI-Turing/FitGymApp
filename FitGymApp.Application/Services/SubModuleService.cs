using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.SubModule.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class SubModuleService : ISubModuleService
    {
        private readonly ISubModuleRepository _subModuleRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public SubModuleService(ISubModuleRepository subModuleRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _subModuleRepository = subModuleRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<SubModule>> CreateSubModuleAsync(AddSubModuleRequest request)
        {
            try
            {
                var entity = new SubModule
                {
                    BranchId = request.BranchId,
                    Ip = request.Ip
                };
                var created = await _subModuleRepository.CreateSubModuleAsync(entity);
                return new ApplicationResponse<SubModule>
                {
                    Success = true,
                    Message = "Submódulo creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<SubModule>
                {
                    Success = false,
                    Message = "Error técnico al crear el submódulo.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<SubModule>> GetSubModuleByIdAsync(Guid id)
        {
            var entity = await _subModuleRepository.GetSubModuleByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<SubModule>
                {
                    Success = false,
                    Message = "Submódulo no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<SubModule>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<SubModule>>> GetAllSubModulesAsync()
        {
            var entities = await _subModuleRepository.GetAllSubModulesAsync();
            return new ApplicationResponse<IEnumerable<SubModule>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateSubModuleAsync(UpdateSubModuleRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _subModuleRepository.GetSubModuleByIdAsync(request.Id);
                var entity = new SubModule
                {
                    Id = request.Id,
                    BranchId = request.BranchId,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _subModuleRepository.UpdateSubModuleAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("SubModule", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Submódulo actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el submódulo (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el submódulo.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteSubModuleAsync(Guid id)
        {
            try
            {
                var deleted = await _subModuleRepository.DeleteSubModuleAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Submódulo eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Submódulo no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el submódulo.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<SubModule>>> FindSubModulesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _subModuleRepository.FindSubModulesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<SubModule>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
