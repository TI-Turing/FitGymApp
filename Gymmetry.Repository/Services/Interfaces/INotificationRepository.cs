using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification> CreateNotificationAsync(Notification entity);
        Task<Notification?> GetNotificationByIdAsync(Guid id);
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task<bool> UpdateNotificationAsync(Notification entity);
        Task<bool> DeleteNotificationAsync(Guid id);
        Task<IEnumerable<Notification>> FindNotificationsByFieldsAsync(Dictionary<string, object> filters);
    }
}
