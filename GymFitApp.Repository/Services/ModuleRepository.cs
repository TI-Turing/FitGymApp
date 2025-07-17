using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitGymApp.Repository.Services
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly FitGymAppContext _context;

        public ModuleRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<Module> CreateModuleAsync(Module entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.Modules.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Module?> GetModuleByIdAsync(Guid id)
        {
            return await _context.Modules.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            return await _context.Modules.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateModuleAsync(Module entity)
        {
            var existing = await _context.Modules.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteModuleAsync(Guid id)
        {
            var entity = await _context.Modules.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Module>> FindModulesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Module), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Module.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(Module).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<Module, bool>>(predicate, parameter);
            return await _context.Modules.Where(lambda).ToListAsync();
        }
    }
}
