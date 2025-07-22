using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Machine.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public MachineService(IMachineRepository machineRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _machineRepository = machineRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<Machine>> CreateMachineAsync(AddMachineRequest request)
        {
            try
            {
                var entity = new Machine
                {
                    Name = request.Name,
                    Ip = request.Ip
                };

                var created = await _machineRepository.CreateMachineAsync(entity);

                // Add MachineCategory relationships if provided
                if (request.MachineCategoryIds != null && request.MachineCategoryIds.Any())
                {
                    foreach (var categoryId in request.MachineCategoryIds)
                    {
                        var machineCategory = new MachineCategory
                        {
                            MachineId = created.Id,
                            MachineCategoryTypeId = categoryId
                        };
                        await _machineRepository.AddMachineCategoryAsync(machineCategory);
                    }
                }

                return new ApplicationResponse<Machine>
                {
                    Success = true,
                    Message = "Máquina creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Machine>
                {
                    Success = false,
                    Message = "Error técnico al crear la máquina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Machine>> GetMachineByIdAsync(Guid id)
        {
            var entity = await _machineRepository.GetMachineByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<Machine>
                {
                    Success = false,
                    Message = "Máquina no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Machine>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Machine>>> GetAllMachinesAsync()
        {
            var entities = await _machineRepository.GetAllMachinesAsync();
            return new ApplicationResponse<IEnumerable<Machine>>
            {
                Success = true,
                Data = entities
            };
        }

        // Updated the UpdateMachineAsync method to handle the many-to-many relationship.
        public async Task<ApplicationResponse<bool>> UpdateMachineAsync(UpdateMachineRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _machineRepository.GetMachineByIdAsync(request.Id);
                if (before == null)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Máquina no encontrada.",
                        ErrorCode = "NotFound"
                    };
                }

                // Only update fields that are not null in the request
                var entity = new Machine
                {
                    Id = request.Id,
                    Name = !string.IsNullOrEmpty(request.Name) ? request.Name : before.Name,
                    Status = !string.IsNullOrEmpty(request.Status) ? request.Status : before.Status,
                    Observations = request.Observations ?? before.Observations,
                    BrandId = request.BrandId.HasValue && request.BrandId.Value != Guid.Empty ? request.BrandId.Value : before.BrandId,
                    Ip = before.Ip,
                    IsActive = before.IsActive,
                    CreatedAt = before.CreatedAt,
                    UpdatedAt = DateTime.UtcNow
                };

                var updated = await _machineRepository.UpdateMachineAsync(entity);
                if (updated)
                {
                    // Update MachineCategory relationships if provided
                    if (request.MachineCategoryIds != null && request.MachineCategoryIds.Any())
                    {
                        await _machineRepository.ClearMachineCategoriesAsync(request.Id);
                        foreach (var categoryId in request.MachineCategoryIds)
                        {
                            var machineCategory = new MachineCategory
                            {
                                MachineId = request.Id,
                                MachineCategoryTypeId = categoryId
                            };
                            await _machineRepository.AddMachineCategoryAsync(machineCategory);
                        }
                    }

                    await _logChangeService.LogChangeAsync("Machine", before, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Máquina actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la máquina (no encontrada o inactiva).",
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
                    Message = "Error técnico al actualizar la máquina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteMachineAsync(Guid id)
        {
            try
            {
                var deleted = await _machineRepository.DeleteMachineAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Máquina eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Máquina no encontrada o ya eliminada.",
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
                    Message = "Error técnico al eliminar la máquina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Machine>>> FindMachinesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _machineRepository.FindMachinesByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Machine>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> CreateMachinesAsync(IEnumerable<AddMachineRequest> requests)
        {
            try
            {
                var machines = requests.Select(request => new Machine
                {
                    Name = request.Name,
                    Status = request.Status,
                    Observations = request.Observations,
                    BrandId = request.BrandId,
                    Ip = request.Ip,
                    IsActive = true
                }).ToList();

                var createdMachines = machines;
                await _machineRepository.CreateMachinesAsync(machines);

                // Add MachineCategory relationships if provided
                foreach (var request in requests)
                {
                    if (request.MachineCategoryIds != null && request.MachineCategoryIds.Any())
                    {
                        foreach (var categoryId in request.MachineCategoryIds)
                        {
                            var machineCategory = new MachineCategory
                            {
                                MachineId = createdMachines.First(m => m.Name == request.Name).Id,
                                MachineCategoryTypeId = categoryId
                            };
                            await _machineRepository.AddMachineCategoryAsync(machineCategory);
                        }
                    }
                }

                return new ApplicationResponse<bool>
                {
                    Success = true,
                    Message = "Máquinas creadas correctamente.",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Message = "Error técnico al crear las máquinas.",
                    ErrorCode = "TechnicalError"
                };
            }
        }
    }
}
