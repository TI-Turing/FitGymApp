using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.DTO.GymPlanSelected.Request;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FitGymApp.Application.Services
{
    public class GymPlanSelectedService : IGymPlanSelectedService
    {
        private readonly IGymPlanSelectedRepository _gymPlanSelectedRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;
        private readonly ILogger<GymPlanSelectedService> _logger;
        private readonly IGymRepository _gymRepository;

        public GymPlanSelectedService(
            IGymPlanSelectedRepository gymPlanSelectedRepository,
            ILogChangeService logChangeService,
            ILogErrorService logErrorService,
            IMapper mapper,
            ILogger<GymPlanSelectedService> logger,
            IGymRepository gymRepository)
        {
            _gymPlanSelectedRepository = gymPlanSelectedRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
            _logger = logger;
            _gymRepository = gymRepository;
        }

        public async Task<ApplicationResponse<GymPlanSelected>> CreateGymPlanSelectedAsync(AddGymPlanSelectedRequest request)
        {
            _logger.LogInformation("Starting CreateGymPlanSelectedAsync method.");
            try
            {
                var validationResponse = await ValidateGymPlanSelectedCreationAsync(request.GymId).ConfigureAwait(false);
                if (!validationResponse.Success)
                {
                    _logger.LogWarning("Validation failed for GymId: {GymId}. Reason: {Message}", request.GymId, validationResponse.Message);
                    return new ApplicationResponse<GymPlanSelected>
                    {
                        Success = false,
                        Message = validationResponse.Message,
                        ErrorCode = "ValidationFailed"
                    };
                }
                var entity = _mapper.Map<GymPlanSelected>(request);
                var created = await _gymPlanSelectedRepository.CreateGymPlanSelectedAsync(entity).ConfigureAwait(false);
                _logger.LogInformation("GymPlanSelected created successfully with ID: {GymPlanSelectedId}", created.Id);
                return new ApplicationResponse<GymPlanSelected>
                {
                    Success = true,
                    Message = "Plan seleccionado de gimnasio creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a GymPlanSelected.");
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<GymPlanSelected>
                {
                    Success = false,
                    Message = "Error técnico al crear el plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<GymPlanSelected>> GetGymPlanSelectedByIdAsync(Guid id)
        {
            _logger.LogInformation("Starting GetGymPlanSelectedByIdAsync method for GymPlanSelectedId: {GymPlanSelectedId}", id);
            try
            {
                var entity = await _gymPlanSelectedRepository.GetGymPlanSelectedByIdAsync(id).ConfigureAwait(false);
                if (entity == null)
                {
                    _logger.LogWarning("GymPlanSelected not found for GymPlanSelectedId: {GymPlanSelectedId}", id);
                    return new ApplicationResponse<GymPlanSelected>
                    {
                        Success = false,
                        Message = "Plan seleccionado de gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                _logger.LogInformation("GymPlanSelected retrieved successfully for GymPlanSelectedId: {GymPlanSelectedId}", id);
                return new ApplicationResponse<GymPlanSelected>
                {
                    Success = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving GymPlanSelected with GymPlanSelectedId: {GymPlanSelectedId}", id);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<GymPlanSelected>
                {
                    Success = false,
                    Message = "Error técnico al obtener el plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<GymPlanSelected>>> GetAllGymPlanSelectedsAsync()
        {
            _logger.LogInformation("Starting GetAllGymPlanSelectedsAsync method.");
            try
            {
                var entities = await _gymPlanSelectedRepository.GetAllGymPlanSelectedsAsync().ConfigureAwait(false);
                _logger.LogInformation("Retrieved {GymPlanSelectedCount} GymPlanSelecteds successfully.", entities.Count());
                return new ApplicationResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = true,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all GymPlanSelecteds.");
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = false,
                    Message = "Error técnico al obtener los planes seleccionados de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateGymPlanSelectedAsync(UpdateGymPlanSelectedRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateGymPlanSelectedAsync method for GymPlanSelectedId: {GymPlanSelectedId}", request.Id);
            try
            {
                var before = await _gymPlanSelectedRepository.GetGymPlanSelectedByIdAsync(request.Id).ConfigureAwait(false);
                if (before == null)
                {
                    _logger.LogWarning("GymPlanSelected not found for GymPlanSelectedId: {GymPlanSelectedId}", request.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Plan seleccionado de gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                var entity = _mapper.Map<GymPlanSelected>(request);
                var updated = await _gymPlanSelectedRepository.UpdateGymPlanSelectedAsync(entity).ConfigureAwait(false);
                if (updated)
                {
                    _logger.LogInformation("GymPlanSelected updated successfully for GymPlanSelectedId: {GymPlanSelectedId}", request.Id);
                    await _logChangeService.LogChangeAsync("GymPlanSelected", before, userId, ip, invocationId).ConfigureAwait(false);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Plan seleccionado de gimnasio actualizado correctamente."
                    };
                }
                _logger.LogWarning("Could not update GymPlanSelected for GymPlanSelectedId: {GymPlanSelectedId}", request.Id);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "No se pudo actualizar el plan seleccionado de gimnasio.",
                    ErrorCode = "UpdateFailed"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating GymPlanSelected with GymPlanSelectedId: {GymPlanSelectedId}", request.Id);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar el plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateGymPlanSelectedAsync(UpdateGymPlanSelectedRequest request)
        {
            return await UpdateGymPlanSelectedAsync(request, null, string.Empty, string.Empty).ConfigureAwait(false);
        }

        public async Task<ApplicationResponse<bool>> DeleteGymPlanSelectedAsync(Guid id)
        {
            _logger.LogInformation("Starting DeleteGymPlanSelectedAsync method for GymPlanSelectedId: {GymPlanSelectedId}", id);
            try
            {
                var deleted = await _gymPlanSelectedRepository.DeleteGymPlanSelectedAsync(id).ConfigureAwait(false);
                if (deleted)
                {
                    _logger.LogInformation("GymPlanSelected deleted successfully for GymPlanSelectedId: {GymPlanSelectedId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Plan seleccionado de gimnasio eliminado correctamente."
                    };
                }
                _logger.LogWarning("GymPlanSelected not found or already deleted for GymPlanSelectedId: {GymPlanSelectedId}", id);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Plan seleccionado de gimnasio no encontrado o ya eliminado.",
                    ErrorCode = "NotFound"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting GymPlanSelected with GymPlanSelectedId: {GymPlanSelectedId}", id);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al eliminar el plan seleccionado de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<GymPlanSelected>>> FindGymPlanSelectedsByFieldsAsync(Dictionary<string, object> filters)
        {
            _logger.LogInformation("Starting FindGymPlanSelectedsByFieldsAsync method with filters: {Filters}", filters);
            try
            {
                var entities = await _gymPlanSelectedRepository.FindGymPlanSelectedsByFieldsAsync(filters).ConfigureAwait(false);
                _logger.LogInformation("Retrieved {GymPlanSelectedCount} GymPlanSelecteds successfully with filters.", entities.Count());
                return new ApplicationResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = true,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while finding GymPlanSelecteds with filters: {Filters}", filters);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = false,
                    Message = "Error técnico al buscar los planes seleccionados de gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> ValidateGymPlanSelectedCreationAsync(Guid gymId)
        {
            _logger.LogInformation("Starting ValidateGymPlanSelectedCreationAsync method for GymId: {GymId}", gymId);
            try
            {
                var gymResponse = await _gymRepository.GetGymByIdAsync(gymId).ConfigureAwait(false);
                if (gymResponse == null || !gymResponse.IsActive)
                {
                    _logger.LogWarning("Validation failed: Gym is inactive or does not exist for GymId: {GymId}", gymId);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "El gimnasio está inactivo o no existe."
                    };
                }
                var filters = new Dictionary<string, object>
                {
                    { "GymId", gymId },
                    { "IsActive", true }
                };
                var existingPlans = await FindGymPlanSelectedsByFieldsAsync(filters).ConfigureAwait(false);
                if (existingPlans.Data != null && existingPlans.Data.Any())
                {
                    _logger.LogWarning("Validation failed: Gym already has an active plan for GymId: {GymId}", gymId);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "El gimnasio ya tiene un plan activo."
                    };
                }
                _logger.LogInformation("Validation successful for GymId: {GymId}", gymId);
                return new ApplicationResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Validación exitosa."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during validation for GymId: {GymId}", gymId);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico durante la validación.",
                    ErrorCode = "TechnicalError"
                };
            }
        }
    }
}
