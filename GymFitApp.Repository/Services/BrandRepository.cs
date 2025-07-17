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
    public class BrandRepository : IBrandRepository
    {
        private readonly FitGymAppContext _context;
        public BrandRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<Brand> CreateBrandAsync(Brand brand)
        {
            brand.Id = Guid.NewGuid();
            brand.CreatedAt = DateTime.UtcNow;
            brand.IsActive = true;
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand?> GetBrandByIdAsync(Guid id)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.Id == id && b.IsActive);
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            return await _context.Brands.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateBrandAsync(Brand brand)
        {
            var existing = await _context.Brands.FirstOrDefaultAsync(b => b.Id == brand.Id && b.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(brand);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBrandAsync(Guid id)
        {
            var entity = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id && b.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Brand>> FindBrandsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Brand), "b");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Brand.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(Brand).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<Brand, bool>>(predicate, parameter);
            return await _context.Brands.Where(lambda).ToListAsync();
        }
    }
}
