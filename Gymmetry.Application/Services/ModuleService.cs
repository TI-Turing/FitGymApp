using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Module.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public ModuleService(IModuleRepository moduleRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _moduleRepository = moduleRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<Module>> CreateModuleAsync(AddModuleRequest request)
        {
            try
            {
                var entity = new Module
                {
                    Name = request.Name,
                    Ip = request.Ip
                };
                var created = await _moduleRepository.CreateModuleAsync(entity);
                return new ApplicationResponse<Module>
                {
                    Success = true,
                    Message = "Módulo creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Module>
                {
                    Success = false,
                    Message = "Error técnico al crear el módulo.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Module>> GetModuleByIdAsync(Guid id)
        {
            var entity = await _moduleRepository.GetModuleByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<Module>
                {
                    Success = false,
                    Message = "Módulo no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Module>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Module>>> GetAllModulesAsync()
        {
            var entities = await _moduleRepository.GetAllModulesAsync();
            return new ApplicationResponse<IEnumerable<Module>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateModuleAsync(UpdateModuleRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _moduleRepository.GetModuleByIdAsync(request.Id);
                var entity = new Module
                {
                    Id = request.Id,
                    Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _moduleRepository.UpdateModuleAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Module", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Módulo actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el módulo (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el módulo.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteModuleAsync(Guid id)
        {
            try
            {
                var deleted = await _moduleRepository.DeleteModuleAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Módulo eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Módulo no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el módulo.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Module>>> FindModulesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _moduleRepository.FindModulesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Module>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
