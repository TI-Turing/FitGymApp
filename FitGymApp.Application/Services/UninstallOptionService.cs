using System;
using System.Collections.Generic;
using System.Linq;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.UninstallOption.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class UninstallOptionService : IUninstallOptionService
    {
        private readonly IUninstallOptionRepository _uninstallOptionRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public UninstallOptionService(IUninstallOptionRepository uninstallOptionRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _uninstallOptionRepository = uninstallOptionRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public ApplicationResponse<UninstallOption> CreateUninstallOption(AddUninstallOptionRequest request)
        {
            try
            {
                var entity = new UninstallOption
                {
                    Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var created = _uninstallOptionRepository.CreateUninstallOption(entity);
                return new ApplicationResponse<UninstallOption>
                {
                    Success = true,
                    Message = "Opci�n de desinstalaci�n creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                _logErrorService.LogError(ex);
                return new ApplicationResponse<UninstallOption>
                {
                    Success = false,
                    Message = "Error t�cnico al crear la opci�n de desinstalaci�n.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public ApplicationResponse<UninstallOption> GetUninstallOptionById(Guid id)
        {
            var entity = _uninstallOptionRepository.GetUninstallOptionById(id);
            if (entity == null)
            {
                return new ApplicationResponse<UninstallOption>
                {
                    Success = false,
                    Message = "Opci�n de desinstalaci�n no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<UninstallOption>
            {
                Success = true,
                Data = entity
            };
        }

        public ApplicationResponse<IEnumerable<UninstallOption>> GetAllUninstallOptions()
        {
            var entities = _uninstallOptionRepository.GetAllUninstallOptions();
            return new ApplicationResponse<IEnumerable<UninstallOption>>
            {
                Success = true,
                Data = entities
            };
        }

        public ApplicationResponse<bool> UpdateUninstallOption(UpdateUninstallOptionRequest request)
        {
            try
            {
                var before = _uninstallOptionRepository.GetUninstallOptionById(request.Id);
                var entity = new UninstallOption
                {
                    Id = request.Id,
                    Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = _uninstallOptionRepository.UpdateUninstallOption(entity);
                if (updated)
                {
                    _logChangeService.LogChange("UninstallOption", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Opci�n de desinstalaci�n actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la opci�n de desinstalaci�n (no encontrada o inactiva).",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                _logErrorService.LogError(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error t�cnico al actualizar la opci�n de desinstalaci�n.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public ApplicationResponse<bool> DeleteUninstallOption(Guid id)
        {
            try
            {
                var deleted = _uninstallOptionRepository.DeleteUninstallOption(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Opci�n de desinstalaci�n eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Opci�n de desinstalaci�n no encontrada o ya eliminada.",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                _logErrorService.LogError(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error t�cnico al eliminar la opci�n de desinstalaci�n.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public ApplicationResponse<IEnumerable<UninstallOption>> FindUninstallOptionsByFields(Dictionary<string, object> filters)
        {
            var entities = _uninstallOptionRepository.FindUninstallOptionsByFields(filters);
            return new ApplicationResponse<IEnumerable<UninstallOption>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
