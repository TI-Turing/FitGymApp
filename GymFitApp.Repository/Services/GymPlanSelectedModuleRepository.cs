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
    public class GymPlanSelectedModuleRepository : IGymPlanSelectedModuleRepository
    {
        private readonly FitGymAppContext _context;
        public GymPlanSelectedModuleRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<GymPlanSelectedModule> CreateGymPlanSelectedModuleAsync(GymPlanSelectedModule entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            _context.GymPlanSelectedModules.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<GymPlanSelectedModule?> GetGymPlanSelectedModuleByIdAsync(Guid id)
        {
            return await _context.GymPlanSelectedModules.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<GymPlanSelectedModule>> GetAllGymPlanSelectedModulesAsync()
        {
            return await _context.GymPlanSelectedModules.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateGymPlanSelectedModuleAsync(GymPlanSelectedModule entity)
        {
            var existing = await _context.GymPlanSelectedModules.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteGymPlanSelectedModuleAsync(Guid id)
        {
            var entity = await _context.GymPlanSelectedModules.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<GymPlanSelectedModule>> FindGymPlanSelectedModulesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(GymPlanSelectedModule), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(GymPlanSelectedModule.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(GymPlanSelectedModule).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<GymPlanSelectedModule, bool>>(predicate, parameter);
            return await _context.GymPlanSelectedModules.Where(lambda).ToListAsync();
        }
    }
}
