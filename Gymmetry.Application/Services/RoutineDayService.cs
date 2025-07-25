using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.RoutineDay.Request;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.ViewModels;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Application.Services
{
    public class RoutineDayService : IRoutineDayService
    {
        private readonly IRoutineDayRepository _routineDayRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;
        private readonly ILogger<RoutineDayService> _logger;

        public RoutineDayService(
            IRoutineDayRepository routineDayRepository,
            ILogChangeService logChangeService,
            ILogErrorService logErrorService,
            IMapper mapper,
            ILogger<RoutineDayService> logger)
        {
            _routineDayRepository = routineDayRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApplicationResponse<RoutineDay>> CreateRoutineDayAsync(AddRoutineDayRequest request)
        {
            _logger.LogInformation("Starting CreateRoutineDayAsync method.");
            try
            {
                var routineDay = _mapper.Map<RoutineDay>(request);
                var created = await _routineDayRepository.CreateRoutineDayAsync(routineDay).ConfigureAwait(false);
                _logger.LogInformation("RoutineDay created successfully with ID: {RoutineDayId}", created.Id);
                return ApplicationResponse<RoutineDay>.SuccessResponse(created, "RoutineDay creada correctamente.");
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, "Error técnico al crear la RoutineDay.");
                return ApplicationResponse<RoutineDay>.ErrorResponse("Error técnico al crear la RoutineDay.", "TechnicalError");
            }
        }

        public async Task<ApplicationResponse<RoutineDay>> GetRoutineDayByIdAsync(Guid id)
        {
            _logger.LogInformation("Starting GetRoutineDayByIdAsync method for RoutineDayId: {RoutineDayId}", id);
            try
            {
                var routineDay = await _routineDayRepository.GetRoutineDayByIdAsync(id).ConfigureAwait(false);
                if (routineDay == null)
                {
                    _logger.LogWarning("RoutineDay not found for RoutineDayId: {RoutineDayId}", id);
                    return ApplicationResponse<RoutineDay>.ErrorResponse("RoutineDay no encontrada.", "NotFound");
                }
                _logger.LogInformation("RoutineDay retrieved successfully for RoutineDayId: {RoutineDayId}", id);
                return ApplicationResponse<RoutineDay>.SuccessResponse(routineDay);
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, "Error técnico al obtener la RoutineDay.");
                return ApplicationResponse<RoutineDay>.ErrorResponse("Error técnico al obtener la RoutineDay.", "TechnicalError");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineDay>>> GetAllRoutineDaysAsync()
        {
            _logger.LogInformation("Starting GetAllRoutineDaysAsync method.");
            try
            {
                var routineDays = await _routineDayRepository.GetAllRoutineDaysAsync().ConfigureAwait(false);
                _logger.LogInformation("Retrieved {RoutineDayCount} routineDays successfully.", routineDays.Count());
                return ApplicationResponse<IEnumerable<RoutineDay>>.SuccessResponse(routineDays);
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, "Error técnico al obtener las routineDays.");
                return ApplicationResponse<IEnumerable<RoutineDay>>.ErrorResponse("Error técnico al obtener las routineDays.", "TechnicalError");
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateRoutineDayAsync(UpdateRoutineDayRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateRoutineDayAsync method for RoutineDayId: {RoutineDayId}", request.Id);
            try
            {
                var routineDayBefore = await _routineDayRepository.GetRoutineDayByIdAsync(request.Id).ConfigureAwait(false);
                if (routineDayBefore == null)
                {
                    _logger.LogWarning("RoutineDay not found for RoutineDayId: {RoutineDayId}", request.Id);
                    return ApplicationResponse<bool>.ErrorResponse("RoutineDay no encontrada.", "NotFound");
                }

                var routineDay = _mapper.Map<RoutineDay>(request);
                var updated = await _routineDayRepository.UpdateRoutineDayAsync(routineDay).ConfigureAwait(false);
                if (updated)
                {
                    _logger.LogInformation("RoutineDay updated successfully for RoutineDayId: {RoutineDayId}", request.Id);
                    await _logChangeService.LogChangeAsync("RoutineDay", routineDayBefore, userId, ip, invocationId).ConfigureAwait(false);
                    return ApplicationResponse<bool>.SuccessResponse(true, "RoutineDay actualizada correctamente.");
                }
                _logger.LogWarning("Could not update RoutineDay for RoutineDayId: {RoutineDayId}", request.Id);
                return ApplicationResponse<bool>.ErrorResponse("No se pudo actualizar la RoutineDay.", "UpdateFailed");
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, "Error técnico al actualizar la RoutineDay.");
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al actualizar la RoutineDay.", "TechnicalError");
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteRoutineDayAsync(Guid id)
        {
            _logger.LogInformation("Starting DeleteRoutineDayAsync method for RoutineDayId: {RoutineDayId}", id);
            try
            {
                var deleted = await _routineDayRepository.DeleteRoutineDayAsync(id).ConfigureAwait(false);
                if (deleted)
                {
                    _logger.LogInformation("RoutineDay deleted successfully for RoutineDayId: {RoutineDayId}", id);
                    return ApplicationResponse<bool>.SuccessResponse(true, "RoutineDay eliminada correctamente.");
                }
                _logger.LogWarning("RoutineDay not found or already deleted for RoutineDayId: {RoutineDayId}", id);
                return ApplicationResponse<bool>.ErrorResponse("RoutineDay no encontrada o ya eliminada.", "NotFound");
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, "Error técnico al eliminar la RoutineDay.");
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al eliminar la RoutineDay.", "TechnicalError");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineDay>>> FindRoutineDaysByFieldsAsync(Dictionary<string, object> filters)
        {
            _logger.LogInformation("Starting FindRoutineDaysByFieldsAsync method with filters: {Filters}", filters);
            try
            {
                var routineDays = await _routineDayRepository.FindRoutineDaysByFieldsAsync(filters).ConfigureAwait(false);
                _logger.LogInformation("Retrieved {RoutineDayCount} routineDays successfully with filters.", routineDays.Count());
                return ApplicationResponse<IEnumerable<RoutineDay>>.SuccessResponse(routineDays);
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, "Error técnico al buscar las routineDays.");
                return ApplicationResponse<IEnumerable<RoutineDay>>.ErrorResponse("Error técnico al buscar las routineDays.", "TechnicalError");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<RoutineDayDetailViewModel>>> GetRoutineDayDetailsAsync()
        {
            _logger.LogInformation("Starting GetRoutineDayDetailsAsync method.");
            try
            {
                var details = await _routineDayRepository.GetRoutineDayDetailsAsync().ConfigureAwait(false);
                _logger.LogInformation("Retrieved {Count} routine day details successfully.", details.Count());
                return ApplicationResponse<IEnumerable<RoutineDayDetailViewModel>>.SuccessResponse(details);
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, "Error técnico al obtener los detalles de RoutineDay.");
                return ApplicationResponse<IEnumerable<RoutineDayDetailViewModel>>.ErrorResponse("Error técnico al obtener los detalles de RoutineDay.", "TechnicalError");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Guid>>> CreateRoutineDaysAsync(AddRoutineDaysRequest request)
        {
            _logger.LogInformation("Starting CreateRoutineDaysAsync method.");
            try
            {
                var routineDays = request.RoutineDays.Select(rd => _mapper.Map<RoutineDay>(rd)).ToList();
                var ids = await _routineDayRepository.CreateRoutineDaysAsync(routineDays).ConfigureAwait(false);
                _logger.LogInformation("RoutineDays created successfully. Count: {Count}", ids.Count());
                return ApplicationResponse<IEnumerable<Guid>>.SuccessResponse(ids, "RoutineDays creadas correctamente.");
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex, "Error técnico al crear las RoutineDays.");
                return ApplicationResponse<IEnumerable<Guid>>.ErrorResponse("Error técnico al crear las RoutineDays.", "TechnicalError");
            }
        }

        private async Task LogErrorAsync(Exception ex, string message)
        {
            _logger.LogError(ex, message);
            await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
        }
    }
}
