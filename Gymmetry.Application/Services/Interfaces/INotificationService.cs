using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.DTO.Notification.Request;
using Gymmetry.Domain.DTO.Notification.Response;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<ApplicationResponse<NotificationResponseDto>> CreateNotificationAsync(NotificationCreateRequestDto request);
        Task<ApplicationResponse<NotificationResponseDto>> GetNotificationByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<NotificationResponseDto>>> GetAllNotificationsAsync();
        Task<ApplicationResponse<bool>> UpdateNotificationAsync(NotificationUpdateRequestDto request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteNotificationAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<NotificationResponseDto>>> FindNotificationsByFieldsAsync(Dictionary<string, object> filters);
    }
}
