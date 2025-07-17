using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitGymApp.Repository.Services
{
    public class NotificationOptionRepository : INotificationOptionRepository
    {
        private readonly FitGymAppContext _context;
        public NotificationOptionRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<NotificationOption> CreateNotificationOptionAsync(NotificationOption entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            _context.NotificationOptions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<NotificationOption?> GetNotificationOptionByIdAsync(Guid id)
        {
            return await _context.NotificationOptions.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<NotificationOption>> GetAllNotificationOptionsAsync()
        {
            return await _context.NotificationOptions.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateNotificationOptionAsync(NotificationOption entity)
        {
            var existing = await _context.NotificationOptions.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteNotificationOptionAsync(Guid id)
        {
            var entity = await _context.NotificationOptions.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<NotificationOption>> FindNotificationOptionsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(NotificationOption), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(NotificationOption.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(NotificationOption).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<NotificationOption, bool>>(predicate, parameter);
            return await _context.NotificationOptions.Where(lambda).ToListAsync();
        }
    }
}
