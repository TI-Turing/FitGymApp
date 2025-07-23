using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitGymApp.Repository.Services
{
    public class UserOtpRepository : IUserOtpRepository
    {
        private readonly FitGymAppContext _context;
        public UserOtpRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserOTP>> FindUserOtpByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(UserOTP), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(UserOTP.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(UserOTP).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<UserOTP, bool>>(predicate, parameter);
            return await _context.Set<UserOTP>().Where(lambda).ToListAsync();
        }

        public async Task<bool> UpdateUserOtpAsync(UserOTP entity)
        {
            var existing = await _context.Set<UserOTP>().FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
