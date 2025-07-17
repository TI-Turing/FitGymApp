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
    public class GymPlanSelectedRepository : IGymPlanSelectedRepository
    {
        private readonly FitGymAppContext _context;
        public GymPlanSelectedRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<GymPlanSelected> CreateGymPlanSelectedAsync(GymPlanSelected entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            _context.GymPlanSelecteds.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<GymPlanSelected?> GetGymPlanSelectedByIdAsync(Guid id)
        {
            return await _context.GymPlanSelecteds.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<GymPlanSelected>> GetAllGymPlanSelectedsAsync()
        {
            return await _context.GymPlanSelecteds.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateGymPlanSelectedAsync(GymPlanSelected entity)
        {
            var existing = await _context.GymPlanSelecteds.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteGymPlanSelectedAsync(Guid id)
        {
            var entity = await _context.GymPlanSelecteds.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<GymPlanSelected>> FindGymPlanSelectedsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(GymPlanSelected), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(GymPlanSelected.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(GymPlanSelected).GetProperty(filter.Key);
                if (property == null) continue;

                var left = Expression.Property(parameter, property);
                if (property.PropertyType == typeof(Guid?))
                    left = Expression.Property(left, "Value");

                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                predicate = Expression.AndAlso(predicate, Expression.Equal(left, right));
            }
            var lambda = Expression.Lambda<Func<GymPlanSelected, bool>>(predicate, parameter);
            return await _context.GymPlanSelecteds.Where(lambda).ToListAsync();
        }
    }
}
