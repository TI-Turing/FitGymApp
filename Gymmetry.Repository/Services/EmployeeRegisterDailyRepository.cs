using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class EmployeeRegisterDailyRepository : IEmployeeRegisterDailyRepository
    {
        private readonly GymmetryContext _context;

        public EmployeeRegisterDailyRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<EmployeeRegisterDaily> CreateEmployeeRegisterDailyAsync(EmployeeRegisterDaily entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.EmployeeRegisterDailies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<EmployeeRegisterDaily?> GetEmployeeRegisterDailyByIdAsync(Guid id)
        {
            return await _context.EmployeeRegisterDailies
                .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<EmployeeRegisterDaily>> GetAllEmployeeRegisterDailiesAsync()
        {
            return await _context.EmployeeRegisterDailies
                .Where(e => e.IsActive)
                .ToListAsync();
        }

        public async Task<bool> UpdateEmployeeRegisterDailyAsync(EmployeeRegisterDaily entity)
        {
            var existing = await _context.EmployeeRegisterDailies
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

        public async Task<bool> DeleteEmployeeRegisterDailyAsync(Guid id)
        {
            var entity = await _context.EmployeeRegisterDailies
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

        public async Task<IEnumerable<EmployeeRegisterDaily>> FindEmployeeRegisterDailiesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(EmployeeRegisterDaily), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(EmployeeRegisterDaily.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(EmployeeRegisterDaily).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<EmployeeRegisterDaily, bool>>(predicate, parameter);
            return await _context.EmployeeRegisterDailies.Where(lambda).ToListAsync();
        }
    }
}
