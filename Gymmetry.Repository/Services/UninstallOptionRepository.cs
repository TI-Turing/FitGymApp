using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class UninstallOptionRepository : IUninstallOptionRepository
    {
        private readonly GymmetryContext _context;
        public UninstallOptionRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<UninstallOption> CreateUninstallOptionAsync(UninstallOption entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.UninstallOptions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UninstallOption> GetUninstallOptionByIdAsync(Guid id)
        {
            return await _context.UninstallOptions.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<UninstallOption>> GetAllUninstallOptionsAsync()
        {
            return await _context.UninstallOptions.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateUninstallOptionAsync(UninstallOption entity)
        {
            var existing = await _context.UninstallOptions.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUninstallOptionAsync(Guid id)
        {
            var entity = await _context.UninstallOptions.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<UninstallOption>> FindUninstallOptionsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(UninstallOption), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(UninstallOption.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(UninstallOption).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<UninstallOption, bool>>(predicate, parameter);
            return await _context.UninstallOptions.Where(lambda).ToListAsync();
        }
    }
}
