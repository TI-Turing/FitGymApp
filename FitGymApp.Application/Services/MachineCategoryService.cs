using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.MachineCategory.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class MachineCategoryService : IMachineCategoryService
    {
        private readonly IMachineCategoryRepository _machineCategoryRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public MachineCategoryService(IMachineCategoryRepository machineCategoryRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _machineCategoryRepository = machineCategoryRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<MachineCategory>> CreateMachineCategoryAsync(AddMachineCategoryRequest request)
        {
            try
            {
                var entity = new MachineCategory
                {
                    //Name = request.Name,
                    Ip = request.Ip
                };
                var created = await _machineCategoryRepository.CreateMachineCategoryAsync(entity);
                return new ApplicationResponse<MachineCategory>
                {
                    Success = true,
                    Message = "Categoría de máquina creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<MachineCategory>
                {
                    Success = false,
                    Message = "Error técnico al crear la categoría de máquina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<MachineCategory>> GetMachineCategoryByIdAsync(Guid id)
        {
            var entity = await _machineCategoryRepository.GetMachineCategoryByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<MachineCategory>
                {
                    Success = false,
                    Message = "Categoría de máquina no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<MachineCategory>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<MachineCategory>>> GetAllMachineCategoriesAsync()
        {
            var entities = await _machineCategoryRepository.GetAllMachineCategoriesAsync();
            return new ApplicationResponse<IEnumerable<MachineCategory>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateMachineCategoryAsync(UpdateMachineCategoryRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _machineCategoryRepository.GetMachineCategoryByIdAsync(request.Id);
                var entity = new MachineCategory
                {
                    Id = request.Id,
                    //Name = request.Name,
                    Ip = request.Ip,
                    IsActive = request.IsActive
                };
                var updated = await _machineCategoryRepository.UpdateMachineCategoryAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("MachineCategory", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Categoría de máquina actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la categoría de máquina (no encontrada o inactiva).",
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
                    Message = "Error técnico al actualizar la categoría de máquina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteMachineCategoryAsync(Guid id)
        {
            try
            {
                var deleted = await _machineCategoryRepository.DeleteMachineCategoryAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Categoría de máquina eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Categoría de máquina no encontrada o ya eliminada.",
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
                    Message = "Error técnico al eliminar la categoría de máquina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<MachineCategory>>> FindMachineCategoriesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _machineCategoryRepository.FindMachineCategoriesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<MachineCategory>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
