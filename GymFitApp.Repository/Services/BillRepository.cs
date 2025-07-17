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
    public class BillRepository : IBillRepository
    {
        private readonly FitGymAppContext _context;
        public BillRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<Bill> CreateBillAsync(Bill bill)
        {
            bill.Id = Guid.NewGuid();
            bill.CreatedAt = DateTime.UtcNow;
            bill.IsActive = true;
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill?> GetBillByIdAsync(Guid id)
        {
            return await _context.Bills.FirstOrDefaultAsync(b => b.Id == id && b.IsActive);
        }

        public async Task<IEnumerable<Bill>> GetAllBillsAsync()
        {
            return await _context.Bills.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateBillAsync(Bill bill)
        {
            var existing = await _context.Bills.FirstOrDefaultAsync(b => b.Id == bill.Id && b.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(bill);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBillAsync(Guid id)
        {
            var entity = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id && b.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Bill>> FindBillsByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Bill), "b");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Bill.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(Bill).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<Bill, bool>>(predicate, parameter);
            return await _context.Bills.Where(lambda).ToListAsync();
        }
    }
}
