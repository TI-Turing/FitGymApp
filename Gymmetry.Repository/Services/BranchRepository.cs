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
    public class BranchRepository : IBranchRepository
    {
        private readonly GymmetryContext _context;
        public BranchRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<Branch> CreateBranchAsync(Branch branch)
        {
            branch.Id = Guid.NewGuid();
            branch.CreatedAt = DateTime.UtcNow;
            branch.IsActive = true;
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return branch;
        }

        public async Task<Branch?> GetBranchByIdAsync(Guid id)
        {
            return await _context.Branches.FirstOrDefaultAsync(b => b.Id == id && b.IsActive);
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            return await _context.Branches.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateBranchAsync(Branch branch)
        {
            var existing = await _context.Branches.FirstOrDefaultAsync(b => b.Id == branch.Id && b.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(branch);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBranchAsync(Guid id)
        {
            var entity = await _context.Branches.FirstOrDefaultAsync(b => b.Id == id && b.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Branch>> FindBranchesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Branch), "b");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Branch.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(Branch).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<Branch, bool>>(predicate, parameter);
            return await _context.Branches.Where(lambda).ToListAsync();
        }
    }
}
