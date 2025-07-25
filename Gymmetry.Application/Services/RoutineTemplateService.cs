using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.RoutineTemplate.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Application.Services
{
    public class RoutineTemplateService : IRoutineTemplateService
    {
        private readonly IRoutineTemplateRepository _routineTemplateRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly ILogger<RoutineTemplateService> _logger;

        public RoutineTemplateService(IRoutineTemplateRepository routineTemplateRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, ILogger<RoutineTemplateService> logger)
        {
            _routineTemplateRepository = routineTemplateRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _logger = logger;
        }

        public async Task<ApplicationResponse<RoutineTemplate>> CreateRoutineTemplateAsync(AddRoutineTemplateRequest request)
        {
            _logger.LogInformation("Starting CreateRoutineTemplateAsync method.");
            try
            {
                var entity = new RoutineTemplate
                {
                    Name = request.Name,
                    Comments = request.Comments,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    GymId = request.GymId,
                    RoutineUserRoutineId = request.RoutineUserRoutineId,
                    RoutineAssignedId = request.RoutineAssignedId
                };
                var created = await _routineTemplateRepository.CreateRoutineTemplateAsync(entity);
                _logger.LogInformation("Routine template created successfully with ID: {RoutineTemplateId}", created.Id);
                return new ApplicationResponse<RoutineTemplate>
                {
                    Success = true,
                    Message = "Plantilla de rutina creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a routine template.");
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<RoutineTemplate>
                {
                    Success = false,
                    Message = "Error técnico al crear la plantilla de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<RoutineTemplate>> GetRoutineTemplateByIdAsync(Guid id)
        {
            _logger.LogInformation("Starting GetRoutineTemplateByIdAsync method for RoutineTemplateId: {RoutineTemplateId}", id);
            try
            {
                var entity = await _routineTemplateRepository.GetRoutineTemplateByIdAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning("Routine template not found for RoutineTemplateId: {RoutineTemplateId}", id);
                    return new ApplicationResponse<RoutineTemplate>
                    {
                        Success = false,
                        Message = "Plantilla de rutina no encontrada.",
                        ErrorCode = "NotFound"
                    };
                }
                _logger.LogInformation("Routine template retrieved successfully for RoutineTemplateId: {RoutineTemplateId}", id);
                return new ApplicationResponse<RoutineTemplate>
                {
                    Success = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving routine template with RoutineTemplateId: {RoutineTemplateId}", id);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<RoutineTemplate>
                {
                    Success = false,
                    Message = "Error técnico al obtener la plantilla de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineTemplate>>> GetAllRoutineTemplatesAsync()
        {
            _logger.LogInformation("Starting GetAllRoutineTemplatesAsync method.");
            try
            {
                var entities = await _routineTemplateRepository.GetAllRoutineTemplatesAsync();
                _logger.LogInformation("Retrieved {RoutineTemplateCount} routine templates successfully.", entities.Count());
                return new ApplicationResponse<IEnumerable<RoutineTemplate>>
                {
                    Success = true,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all routine templates.");
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<IEnumerable<RoutineTemplate>>
                {
                    Success = false,
                    Message = "Error técnico al obtener las plantillas de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateRoutineTemplateAsync(UpdateRoutineTemplateRequest request, string ip = "", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateRoutineTemplateAsync method for RoutineTemplateId: {RoutineTemplateId}", request.Id);
            try
            {
                var before = await _routineTemplateRepository.GetRoutineTemplateByIdAsync(request.Id);
                if (before == null)
                {
                    _logger.LogWarning("Routine template not found for RoutineTemplateId: {RoutineTemplateId}", request.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Plantilla de rutina no encontrada.",
                        ErrorCode = "NotFound"
                    };
                }

                var entity = new RoutineTemplate
                {
                    Id = request.Id,
                    Name = request.Name,
                    Comments = request.Comments,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    GymId = request.GymId,
                    RoutineUserRoutineId = request.RoutineUserRoutineId,
                    RoutineAssignedId = request.RoutineAssignedId
                };
                var updated = await _routineTemplateRepository.UpdateRoutineTemplateAsync(entity);
                if (updated)
                {
                    _logger.LogInformation("Routine template updated successfully for RoutineTemplateId: {RoutineTemplateId}", request.Id);
                    await _logChangeService.LogChangeAsync("RoutineTemplate", before, entity.Id, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Plantilla de rutina actualizada correctamente."
                    };
                }
                else
                {
                    _logger.LogWarning("Could not update routine template for RoutineTemplateId: {RoutineTemplateId}", request.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la plantilla de rutina.",
                        ErrorCode = "UpdateFailed"
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating routine template with RoutineTemplateId: {RoutineTemplateId}", request.Id);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar la plantilla de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteRoutineTemplateAsync(Guid id)
        {
            _logger.LogInformation("Starting DeleteRoutineTemplateAsync method for RoutineTemplateId: {RoutineTemplateId}", id);
            try
            {
                var deleted = await _routineTemplateRepository.DeleteRoutineTemplateAsync(id);
                if (deleted)
                {
                    _logger.LogInformation("Routine template deleted successfully for RoutineTemplateId: {RoutineTemplateId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Plantilla de rutina eliminada correctamente."
                    };
                }
                else
                {
                    _logger.LogWarning("Routine template not found or already deleted for RoutineTemplateId: {RoutineTemplateId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Plantilla de rutina no encontrada o ya eliminada.",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting routine template with RoutineTemplateId: {RoutineTemplateId}", id);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al eliminar la plantilla de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineTemplate>>> FindRoutineTemplatesByFieldsAsync(Dictionary<string, object> filters)
        {
            _logger.LogInformation("Starting FindRoutineTemplatesByFieldsAsync method with filters: {Filters}", filters);
            try
            {
                var entities = await _routineTemplateRepository.FindRoutineTemplatesByFieldsAsync(filters);
                _logger.LogInformation("Retrieved {RoutineTemplateCount} routine templates successfully with filters.", entities.Count());
                return new ApplicationResponse<IEnumerable<RoutineTemplate>>
                {
                    Success = true,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while finding routine templates with filters: {Filters}", filters);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<IEnumerable<RoutineTemplate>>
                {
                    Success = false,
                    Message = "Error técnico al buscar las plantillas de rutina.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteRoutineTemplatesByGymIdAsync(Guid gymId)
        {
            _logger.LogInformation("Starting DeleteRoutineTemplatesByGymIdAsync method for GymId: {GymId}", gymId);
            try
            {
                var filters = new Dictionary<string, object> { { "GymId", gymId } };
                var templates = await FindRoutineTemplatesByFieldsAsync(filters);
                foreach (var template in templates.Data)
                {
                    await _routineTemplateRepository.DeleteRoutineTemplateAsync(template.Id);
                }
                _logger.LogInformation("Deleted {RoutineTemplateCount} routine templates successfully for GymId: {GymId}", templates.Data.Count(), gymId);
                return new ApplicationResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Routine templates deleted successfully."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting routine templates for GymId: {GymId}", gymId);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error while deleting routine templates by GymId.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Guid>> DuplicateRoutineTemplateAsync(Guid routineTemplateId, Guid gymId)
        {
            _logger.LogInformation("Starting DuplicateRoutineTemplateAsync for RoutineTemplateId: {RoutineTemplateId} and GymId: {GymId}", routineTemplateId, gymId);
            try
            {
                var newId = await _routineTemplateRepository.DuplicateRoutineTemplateAsync(routineTemplateId, gymId).ConfigureAwait(false);
                _logger.LogInformation("RoutineTemplate duplicated successfully. New Id: {NewId}", newId);
                return ApplicationResponse<Guid>.SuccessResponse(newId, "Plantilla de rutina duplicada correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while duplicating RoutineTemplate with RoutineTemplateId: {RoutineTemplateId}", routineTemplateId);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return ApplicationResponse<Guid>.ErrorResponse("Error técnico al duplicar la plantilla de rutina.", "TechnicalError");
            }
        }
    }
}
