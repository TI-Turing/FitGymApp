using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class BranchMediaRepository : IBranchMediaRepository
    {
        private readonly GymmetryContext _context;
        public BranchMediaRepository(GymmetryContext context) { _context = context; }

        public async Task<BranchMedia> CreateBranchMediaAsync(BranchMedia entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.BranchMedias.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<BranchMedia?> GetBranchMediaByIdAsync(Guid id)
        {
            return await _context.BranchMedias.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<BranchMedia>> GetAllBranchMediasAsync()
        {
            return await _context.BranchMedias.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateBranchMediaAsync(BranchMedia entity)
        {
            var existing = await _context.BranchMedias.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBranchMediaAsync(Guid id)
        {
            var entity = await _context.BranchMedias.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BranchMedia>> FindBranchMediasByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(BranchMedia), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(BranchMedia.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(BranchMedia).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(filter.Value);
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<BranchMedia, bool>>(predicate, parameter);
            return await _context.BranchMedias.Where(lambda).ToListAsync();
        }
    }

    public class CurrentOccupancyRepository : ICurrentOccupancyRepository
    {
        private readonly GymmetryContext _context;
        public CurrentOccupancyRepository(GymmetryContext context) { _context = context; }

        public async Task<CurrentOccupancy> CreateCurrentOccupancyAsync(CurrentOccupancy entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.CurrentOccupancies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CurrentOccupancy?> GetCurrentOccupancyByIdAsync(Guid id)
        {
            return await _context.CurrentOccupancies.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<CurrentOccupancy>> GetAllCurrentOccupanciesAsync()
        {
            return await _context.CurrentOccupancies.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateCurrentOccupancyAsync(CurrentOccupancy entity)
        {
            var existing = await _context.CurrentOccupancies.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCurrentOccupancyAsync(Guid id)
        {
            var entity = await _context.CurrentOccupancies.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CurrentOccupancy>> FindCurrentOccupanciesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(CurrentOccupancy), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(CurrentOccupancy.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(CurrentOccupancy).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(filter.Value);
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<CurrentOccupancy, bool>>(predicate, parameter);
            return await _context.CurrentOccupancies.Where(lambda).ToListAsync();
        }
    }
}
