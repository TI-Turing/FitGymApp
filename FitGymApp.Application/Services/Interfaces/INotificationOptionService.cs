using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.NotificationOption.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface INotificationOptionService
    {
        Task<ApplicationResponse<NotificationOption>> CreateNotificationOptionAsync(AddNotificationOptionRequest request);
        Task<ApplicationResponse<NotificationOption>> GetNotificationOptionByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<NotificationOption>>> GetAllNotificationOptionsAsync();
        Task<ApplicationResponse<bool>> UpdateNotificationOptionAsync(UpdateNotificationOptionRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteNotificationOptionAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<NotificationOption>>> FindNotificationOptionsByFieldsAsync(Dictionary<string, object> filters);
    }
}
