using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class VerificationTypeRepository : IVerificationTypeRepository
    {
        private readonly GymmetryContext _context;
        public VerificationTypeRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<VerificationType> CreateVerificationTypeAsync(VerificationType entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.VerificationTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<VerificationType> GetVerificationTypeByIdAsync(Guid id)
        {
            return await _context.VerificationTypes.FirstOrDefaultAsync(e => e.Id == id && e.IsActive == true);
        }

        public async Task<IEnumerable<VerificationType>> GetAllVerificationTypesAsync()
        {
            return await _context.VerificationTypes.Where(e => e.IsActive == true).ToListAsync();
        }

        public async Task<bool> UpdateVerificationTypeAsync(VerificationType entity)
        {
            var existing = await _context.VerificationTypes.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive == true);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteVerificationTypeAsync(Guid id)
        {
            var entity = await _context.VerificationTypes.FirstOrDefaultAsync(e => e.Id == id && e.IsActive == true);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<VerificationType>> FindVerificationTypesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(VerificationType), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(VerificationType.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(VerificationType).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<VerificationType, bool>>(predicate, parameter);
            return await _context.VerificationTypes.Where(lambda).ToListAsync();
        }
    }
}
