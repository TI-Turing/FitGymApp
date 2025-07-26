using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.Notification.Request;
using Gymmetry.Domain.DTO.Notification.Response;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;
using AutoMapper;

namespace Gymmetry.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<NotificationResponseDto>> CreateNotificationAsync(NotificationCreateRequestDto request)
        {
            try
            {
                var entity = _mapper.Map<Domain.Models.Notification>(request);
                var created = await _notificationRepository.CreateNotificationAsync(entity);
                var dto = _mapper.Map<NotificationResponseDto>(created);
                return ApplicationResponse<NotificationResponseDto>.SuccessResponse(dto, "Notificación creada correctamente.");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<NotificationResponseDto>.ErrorResponse("Error técnico al crear la notificación.");
            }
        }

        public async Task<ApplicationResponse<NotificationResponseDto>> GetNotificationByIdAsync(Guid id)
        {
            var entity = await _notificationRepository.GetNotificationByIdAsync(id);
            if (entity == null)
                return ApplicationResponse<NotificationResponseDto>.ErrorResponse("Notificación no encontrada.");
            var dto = _mapper.Map<NotificationResponseDto>(entity);
            return ApplicationResponse<NotificationResponseDto>.SuccessResponse(dto);
        }

        public async Task<ApplicationResponse<IEnumerable<NotificationResponseDto>>> GetAllNotificationsAsync()
        {
            var entities = await _notificationRepository.GetAllNotificationsAsync();
            var dtos = _mapper.Map<IEnumerable<NotificationResponseDto>>(entities);
            return ApplicationResponse<IEnumerable<NotificationResponseDto>>.SuccessResponse(dtos);
        }

        public async Task<ApplicationResponse<bool>> UpdateNotificationAsync(NotificationUpdateRequestDto request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _notificationRepository.GetNotificationByIdAsync(request.Id);
                var entity = _mapper.Map<Domain.Models.Notification>(request);
                var updated = await _notificationRepository.UpdateNotificationAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Notification", before, userId, ip, invocationId);
                    return ApplicationResponse<bool>.SuccessResponse(true, "Notificación actualizada correctamente.");
                }
                else
                {
                    return ApplicationResponse<bool>.ErrorResponse("No se pudo actualizar la notificación (no encontrada o inactiva).");
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al actualizar la notificación.");
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteNotificationAsync(Guid id)
        {
            try
            {
                var deleted = await _notificationRepository.DeleteNotificationAsync(id);
                return deleted
                    ? ApplicationResponse<bool>.SuccessResponse(true, "Notificación eliminada correctamente.")
                    : ApplicationResponse<bool>.ErrorResponse("Notificación no encontrada o ya eliminada.");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al eliminar la notificación.");
            }
        }

        public async Task<ApplicationResponse<IEnumerable<NotificationResponseDto>>> FindNotificationsByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _notificationRepository.FindNotificationsByFieldsAsync(filters);
            var dtos = _mapper.Map<IEnumerable<NotificationResponseDto>>(entities);
            return ApplicationResponse<IEnumerable<NotificationResponseDto>>.SuccessResponse(dtos);
        }
    }
}
