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
    public class PhysicalAssessmentRepository : IPhysicalAssessmentRepository
    {
        private readonly FitGymAppContext _context;
        public PhysicalAssessmentRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<PhysicalAssessment> CreatePhysicalAssessmentAsync(PhysicalAssessment assessment)
        {
            assessment.Id = Guid.NewGuid();
            assessment.CreatedAt = DateTime.UtcNow;
            assessment.IsActive = true;
            _context.PhysicalAssessments.Add(assessment);
            await _context.SaveChangesAsync();
            return assessment;
        }

        public async Task<PhysicalAssessment?> GetPhysicalAssessmentByIdAsync(Guid id)
        {
            return await _context.PhysicalAssessments.FirstOrDefaultAsync(a => a.Id == id && a.IsActive);
        }

        public async Task<IEnumerable<PhysicalAssessment>> GetAllPhysicalAssessmentsAsync()
        {
            return await _context.PhysicalAssessments.Where(a => a.IsActive).ToListAsync();
        }

        public async Task<bool> UpdatePhysicalAssessmentAsync(PhysicalAssessment assessment)
        {
            var existing = await _context.PhysicalAssessments.FirstOrDefaultAsync(a => a.Id == assessment.Id && a.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(assessment);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePhysicalAssessmentAsync(Guid id)
        {
            var entity = await _context.PhysicalAssessments.FirstOrDefaultAsync(a => a.Id == id && a.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<PhysicalAssessment>> FindPhysicalAssessmentsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(PhysicalAssessment), "a");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(PhysicalAssessment.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(PhysicalAssessment).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<PhysicalAssessment, bool>>(predicate, parameter);
            return await _context.PhysicalAssessments.Where(lambda).ToListAsync();
        }
    }
}
