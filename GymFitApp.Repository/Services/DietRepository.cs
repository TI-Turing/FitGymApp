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
    public class DietRepository : IDietRepository
    {
        private readonly FitGymAppContext _context;
        public DietRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<Diet> CreateDietAsync(Diet diet)
        {
            diet.Id = Guid.NewGuid();
            diet.CreatedAt = DateTime.UtcNow;
            diet.IsActive = true;
            _context.Diets.Add(diet);
            await _context.SaveChangesAsync();
            return diet;
        }

        public async Task<Diet?> GetDietByIdAsync(Guid id)
        {
            return await _context.Diets.FirstOrDefaultAsync(d => d.Id == id && d.IsActive);
        }

        public async Task<IEnumerable<Diet>> GetAllDietsAsync()
        {
            return await _context.Diets.Where(d => d.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateDietAsync(Diet diet)
        {
            var existing = await _context.Diets.FirstOrDefaultAsync(d => d.Id == diet.Id && d.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(diet);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDietAsync(Guid id)
        {
            var entity = await _context.Diets.FirstOrDefaultAsync(d => d.Id == id && d.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Diet>> FindDietsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Diet), "d");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Diet.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(Diet).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<Diet, bool>>(predicate, parameter);
            return await _context.Diets.Where(lambda).ToListAsync();
        }
    }
}
