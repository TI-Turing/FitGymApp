using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class LogUninstallRepository : ILogUninstallRepository
    {
        private readonly GymmetryContext _context;
        public LogUninstallRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<LogUninstall> CreateLogUninstallAsync(LogUninstall entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.LogUninstalls.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<LogUninstall> GetLogUninstallByIdAsync(Guid id)
        {
            return await _context.LogUninstalls.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<LogUninstall>> GetAllLogUninstallsAsync()
        {
            return await _context.LogUninstalls.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateLogUninstallAsync(LogUninstall entity)
        {
            var existing = await _context.LogUninstalls.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteLogUninstallAsync(Guid id)
        {
            var entity = await _context.LogUninstalls.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<LogUninstall>> FindLogUninstallsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(LogUninstall), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(LogUninstall.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(LogUninstall).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<LogUninstall, bool>>(predicate, parameter);
            return await _context.LogUninstalls.Where(lambda).ToListAsync();
        }
    }
}
