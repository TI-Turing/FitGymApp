using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.FitUser.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class FitUserService : IFitUserService
    {
        private readonly IFitUserRepository _fitUserRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public FitUserService(IFitUserRepository fitUserRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _fitUserRepository = fitUserRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<FitUser>> CreateFitUserAsync(AddFitUserRequest request)
        {
            try
            {
                var entity = _mapper.Map<FitUser>(request);
                var created = await _fitUserRepository.CreateFitUserAsync(entity);
                return new ApplicationResponse<FitUser>
                {
                    Success = true,
                    Message = "FitUser creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<FitUser>
                {
                    Success = false,
                    Message = "Error técnico al crear el FitUser.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<FitUser>> GetFitUserByIdAsync(Guid id)
        {
            var entity = await _fitUserRepository.GetFitUserByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<FitUser>
                {
                    Success = false,
                    Message = "FitUser no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<FitUser>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<FitUser>>> GetAllFitUsersAsync()
        {
            var entities = await _fitUserRepository.GetAllFitUsersAsync();
            return new ApplicationResponse<IEnumerable<FitUser>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateFitUserAsync(UpdateFitUserRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _fitUserRepository.GetFitUserByIdAsync(request.Id);
                var entity = _mapper.Map<FitUser>(request);
                var updated = await _fitUserRepository.UpdateFitUserAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("FitUser", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "FitUser actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el FitUser (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el FitUser.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteFitUserAsync(Guid id)
        {
            try
            {
                var deleted = await _fitUserRepository.DeleteFitUserAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "FitUser eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "FitUser no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el FitUser.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<FitUser>>> FindFitUsersByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _fitUserRepository.FindFitUsersByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<FitUser>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
