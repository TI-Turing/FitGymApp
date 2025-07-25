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
    public class UserOtpRepository : IUserOtpRepository
    {
        private readonly GymmetryContext _context;

        public UserOtpRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserOTP>> FindUserOtpByFieldsAsync(Dictionary<string, object> filters)
        {
            var predicate = BuildPredicate(filters);
            return await _context.Set<UserOTP>().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateUserOtpAsync(UserOTP entity)
        {
            var existing = await _context.Set<UserOTP>()
                .FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive)
                .ConfigureAwait(false);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            existing.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task DeleteUserOtpsAsync(IEnumerable<UserOTP> otps)
        {
            if (otps == null || !otps.Any()) return;
            foreach (var otp in otps)
            {
                otp.IsActive = false;
                otp.DeletedAt = DateTime.UtcNow;
            }
            _context.Set<UserOTP>().UpdateRange(otps);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        private static Expression<Func<UserOTP, bool>> BuildPredicate(Dictionary<string, object> filters)
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
            return Expression.Lambda<Func<UserOTP, bool>>(predicate, parameter);
        }
    }
}
