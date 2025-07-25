using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.GymType.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class GymTypeService : IGymTypeService
    {
        private readonly IGymTypeRepository _gymTypeRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public GymTypeService(IGymTypeRepository gymTypeRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _gymTypeRepository = gymTypeRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<GymType>> CreateGymTypeAsync(AddGymTypeRequest request)
        {
            try
            {
                var entity = new GymType
                {
                    Name = request.Name,
                    Ip = request.Ip
                };
                var created = await _gymTypeRepository.CreateGymTypeAsync(entity);
                return new ApplicationResponse<GymType>
                {
                    Success = true,
                    Message = "Tipo de gimnasio creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<GymType>
                {
                    Success = false,
                    Message = "Error técnico al crear el tipo de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<GymType>> GetGymTypeByIdAsync(Guid id)
        {
            var entity = await _gymTypeRepository.GetGymTypeByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<GymType>
                {
                    Success = false,
                    Message = "Tipo de gimnasio no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<GymType>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<GymType>>> GetAllGymTypesAsync()
        {
            var entities = await _gymTypeRepository.GetAllGymTypesAsync();
            return new ApplicationResponse<IEnumerable<GymType>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateGymTypeAsync(UpdateGymTypeRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _gymTypeRepository.GetGymTypeByIdAsync(request.Id);
                var entity = new GymType
                {
                    Id = request.Id,
                    Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _gymTypeRepository.UpdateGymTypeAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("GymType", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de gimnasio actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el tipo de gimnasio (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el tipo de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteGymTypeAsync(Guid id)
        {
            try
            {
                var deleted = await _gymTypeRepository.DeleteGymTypeAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Tipo de gimnasio eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Tipo de gimnasio no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el tipo de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<GymType>>> FindGymTypesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _gymTypeRepository.FindGymTypesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<GymType>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
