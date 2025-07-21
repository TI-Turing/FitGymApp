using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Notification.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<ApplicationResponse<Notification>> CreateNotificationAsync(AddNotificationRequest request);
        Task<ApplicationResponse<Notification>> GetNotificationByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Notification>>> GetAllNotificationsAsync();
        Task<ApplicationResponse<bool>> UpdateNotificationAsync(UpdateNotificationRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteNotificationAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Notification>>> FindNotificationsByFieldsAsync(Dictionary<string, object> filters);
    }
}
