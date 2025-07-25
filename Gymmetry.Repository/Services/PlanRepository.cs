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
    public class PlanRepository : IPlanRepository
    {
        private readonly GymmetryContext _context;
        public PlanRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<Plan> CreatePlanAsync(Plan plan)
        {
            plan.Id = Guid.NewGuid();
            plan.CreatedAt = DateTime.UtcNow;
            plan.IsActive = true;
            await _context.Plans.AddAsync(plan);
            await _context.SaveChangesAsync();
            return plan;
        }

        public async Task<Plan> GetPlanByIdAsync(Guid id)
        {
            return await _context.Plans.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<IEnumerable<Plan>> GetAllPlansAsync()
        {
            return await _context.Plans.Where(p => p.IsActive).ToListAsync();
        }

        public async Task<bool> UpdatePlanAsync(Plan plan)
        {
            var existing = await _context.Plans.FirstOrDefaultAsync(p => p.Id == plan.Id && p.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(plan);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePlanAsync(Guid id)
        {
            var entity = await _context.Plans.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Plan>> FindPlansByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Plan), "p");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Plan.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(Plan).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<Plan, bool>>(predicate, parameter);
            return await _context.Plans.Where(lambda).ToListAsync();
        }

        public async Task<IEnumerable<Plan>> GetPlansByGymIdAsync(Guid gymId)
        {
            return await _context.Plans.Where(p => p.GymId == gymId && p.IsActive).ToListAsync();
        }
    }
}
