using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly GymmetryContext _context;
        public PermissionRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<Permission> CreatePermissionAsync(Permission entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.Permissions.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Permission> GetPermissionByIdAsync(Guid id)
        {
            return await _context.Permissions.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _context.Permissions.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdatePermissionAsync(Permission entity)
        {
            var existing = _context.Permissions.FirstOrDefault(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePermissionAsync(Guid id)
        {
            var entity = _context.Permissions.FirstOrDefault(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Permission>> FindPermissionsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Permission), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Permission.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(Permission).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<Permission, bool>>(predicate, parameter);
            return await _context.Permissions.Where(lambda).ToListAsync();
        }
    }
}
