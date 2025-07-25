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
    public class EmployeeUserRepository : IEmployeeUserRepository
    {
        private readonly GymmetryContext _context;
        public EmployeeUserRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<EmployeeUser> CreateEmployeeUserAsync(EmployeeUser entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            _context.EmployeeUsers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<EmployeeUser?> GetEmployeeUserByIdAsync(Guid id)
        {
            return await _context.EmployeeUsers.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<EmployeeUser>> GetAllEmployeeUsersAsync()
        {
            return await _context.EmployeeUsers.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateEmployeeUserAsync(EmployeeUser entity)
        {
            var existing = await _context.EmployeeUsers.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteEmployeeUserAsync(Guid id)
        {
            var entity = await _context.EmployeeUsers.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<EmployeeUser>> FindEmployeeUsersByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(EmployeeUser), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(EmployeeUser.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(EmployeeUser).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<EmployeeUser, bool>>(predicate, parameter);
            return await _context.EmployeeUsers.Where(lambda).ToListAsync();
        }
    }
}
