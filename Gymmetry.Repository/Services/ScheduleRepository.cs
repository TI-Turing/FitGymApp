using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly GymmetryContext _context;
        public ScheduleRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<Schedule> CreateScheduleAsync(Schedule entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            _context.Schedules.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Schedule?> GetScheduleByIdAsync(Guid id)
        {
            return await _context.Schedules.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _context.Schedules.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateScheduleAsync(Schedule entity)
        {
            var existing = await _context.Schedules.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteScheduleAsync(Guid id)
        {
            var entity = await _context.Schedules.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Schedule>> FindSchedulesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Schedule), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Schedule.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(Schedule).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<Schedule, bool>>(predicate, parameter);
            return await _context.Schedules.Where(lambda).ToListAsync();
        }
    }
}
