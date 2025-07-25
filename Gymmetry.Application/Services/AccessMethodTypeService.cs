using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.AccessMethodType.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class AccessMethodTypeService : IAccessMethodTypeService
    {
        private readonly IAccessMethodTypeRepository _accessMethodTypeRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public AccessMethodTypeService(IAccessMethodTypeRepository accessMethodTypeRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _accessMethodTypeRepository = accessMethodTypeRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<AccessMethodType>> CreateAccessMethodTypeAsync(AddAccessMethodTypeRequest request)
        {
            try
            {
                var entity = _mapper.Map<AccessMethodType>(request);
                var created = await _accessMethodTypeRepository.CreateAccessMethodTypeAsync(entity);
                return new ApplicationResponse<AccessMethodType>
                {
                    Success = true,
                    Message = "Método de acceso creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<AccessMethodType>
                {
                    Success = false,
                    Message = "Error técnico al crear el método de acceso.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<AccessMethodType>> GetAccessMethodTypeByIdAsync(Guid id)
        {
            var entity = await _accessMethodTypeRepository.GetAccessMethodTypeByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<AccessMethodType>
                {
                    Success = false,
                    Message = "Método de acceso no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<AccessMethodType>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<AccessMethodType>>> GetAllAccessMethodTypesAsync()
        {
            var entities = await _accessMethodTypeRepository.GetAllAccessMethodTypesAsync();
            return new ApplicationResponse<IEnumerable<AccessMethodType>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateAccessMethodTypeAsync(UpdateAccessMethodTypeRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _accessMethodTypeRepository.GetAccessMethodTypeByIdAsync(request.Id);
                var entity = _mapper.Map<AccessMethodType>(request);
                var updated = await _accessMethodTypeRepository.UpdateAccessMethodTypeAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("AccessMethodType", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Método de acceso actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el método de acceso (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el método de acceso.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteAccessMethodTypeAsync(Guid id)
        {
            try
            {
                var deleted = await _accessMethodTypeRepository.DeleteAccessMethodTypeAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Método de acceso eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Método de acceso no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el método de acceso.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<AccessMethodType>>> FindAccessMethodTypesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _accessMethodTypeRepository.FindAccessMethodTypesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<AccessMethodType>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
