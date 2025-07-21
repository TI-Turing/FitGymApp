using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.LogUninstall.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;
using AutoMapper;

namespace FitGymApp.Application.Services
{
    public class LogUninstallService : ILogUninstallService
    {
        private readonly ILogUninstallRepository _logUninstallRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public LogUninstallService(ILogUninstallRepository logUninstallRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _logUninstallRepository = logUninstallRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<LogUninstall>> CreateLogUninstallAsync(AddLogUninstallRequest request)
        {
            try
            {
                var entity = _mapper.Map<LogUninstall>(request);
                var created = await _logUninstallRepository.CreateLogUninstallAsync(entity);
                return new ApplicationResponse<LogUninstall>
                {
                    Success = true,
                    Message = "Log de desinstalación creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<LogUninstall>
                {
                    Success = false,
                    Message = "Error técnico al crear el log de desinstalación.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<LogUninstall>> GetLogUninstallByIdAsync(Guid id)
        {
            var entity = await _logUninstallRepository.GetLogUninstallByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<LogUninstall>
                {
                    Success = false,
                    Message = "Log de desinstalación no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<LogUninstall>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<LogUninstall>>> GetAllLogUninstallsAsync()
        {
            var entities = await _logUninstallRepository.GetAllLogUninstallsAsync();
            return new ApplicationResponse<IEnumerable<LogUninstall>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateLogUninstallAsync(UpdateLogUninstallRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _logUninstallRepository.GetLogUninstallByIdAsync(request.Id);
                var entity = _mapper.Map<LogUninstall>(request);
                var updated = await _logUninstallRepository.UpdateLogUninstallAsync(entity);
                if (updated)
                {
                    _logChangeService.LogChangeAsync("LogUninstall", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Log de desinstalación actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el log de desinstalación (no encontrado o inactivo).",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar el log de desinstalación.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteLogUninstallAsync(Guid id)
        {
            try
            {
                var deleted = await _logUninstallRepository.DeleteLogUninstallAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Log de desinstalación eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Log de desinstalación no encontrado o ya eliminado.",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al eliminar el log de desinstalación.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<LogUninstall>>> FindLogUninstallsByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _logUninstallRepository.FindLogUninstallsByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<LogUninstall>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
