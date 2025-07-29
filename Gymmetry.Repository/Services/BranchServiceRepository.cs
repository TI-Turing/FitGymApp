using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class BranchServiceRepository : IBranchServiceRepository
    {
        private readonly GymmetryContext _context;
        public BranchServiceRepository(GymmetryContext context) { _context = context; }

        public async Task<BranchService> CreateBranchServiceAsync(BranchService entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.BranchServices.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<BranchService?> GetBranchServiceByIdAsync(Guid id)
        {
            return await _context.BranchServices.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<BranchService>> GetAllBranchServicesAsync()
        {
            return await _context.BranchServices.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateBranchServiceAsync(BranchService entity)
        {
            var existing = await _context.BranchServices.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBranchServiceAsync(Guid id)
        {
            var entity = await _context.BranchServices.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BranchService>> FindBranchServicesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(BranchService), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(BranchService.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(BranchService).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(filter.Value);
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<BranchService, bool>>(predicate, parameter);
            return await _context.BranchServices.Where(lambda).ToListAsync();
        }
    }
}
