using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitGymApp.Repository.Services
{
    public class DailyRepository : IDailyRepository
    {
        private readonly FitGymAppContext _context;
        public DailyRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<Daily> CreateDailyAsync(Daily entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.Dailies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Daily?> GetDailyByIdAsync(Guid id)
        {
            return await _context.Dailies
                .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<Daily>> GetAllDailiesAsync()
        {
            return await _context.Dailies
                .Where(e => e.IsActive)
                .ToListAsync();
        }

        public async Task<bool> UpdateDailyAsync(Daily entity)
        {
            var existing = await _context.Dailies
                .FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDailyAsync(Guid id)
        {
            var entity = await _context.Dailies
                .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Daily>> FindDailiesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Daily), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Daily.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(Daily).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<Daily, bool>>(predicate, parameter);
            return await _context.Dailies.Where(lambda).ToListAsync();
        }
    }
}
