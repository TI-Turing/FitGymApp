using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.ViewModels;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class RoutineDayRepository : IRoutineDayRepository
    {
        private readonly GymmetryContext _context;

        public RoutineDayRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<RoutineDay> CreateRoutineDayAsync(RoutineDay routineDay)
        {
            if (routineDay == null) throw new ArgumentNullException(nameof(routineDay));
            routineDay.Id = Guid.NewGuid();
            routineDay.CreatedAt = DateTime.UtcNow;
            routineDay.IsActive = true;
            _context.RoutineDays.Add(routineDay);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return routineDay;
        }

        public async Task<RoutineDay?> GetRoutineDayByIdAsync(Guid id)
        {
            return await _context.RoutineDays
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id && r.IsActive)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<RoutineDay>> GetAllRoutineDaysAsync()
        {
            return await _context.RoutineDays
                .AsNoTracking()
                .Where(r => r.IsActive)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateRoutineDayAsync(RoutineDay routineDay)
        {
            if (routineDay == null) throw new ArgumentNullException(nameof(routineDay));
            var existing = await _context.RoutineDays.FirstOrDefaultAsync(r => r.Id == routineDay.Id && r.IsActive).ConfigureAwait(false);
            if (existing == null) return false;
            _context.Entry(existing).CurrentValues.SetValues(routineDay);
            existing.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteRoutineDayAsync(Guid id)
        {
            var entity = await _context.RoutineDays.FirstOrDefaultAsync(r => r.Id == id && r.IsActive).ConfigureAwait(false);
            if (entity == null) return false;
            entity.IsActive = false;
            entity.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<IEnumerable<RoutineDay>> FindRoutineDaysByFieldsAsync(Dictionary<string, object> filters)
        {
            var predicate = BuildPredicate(filters);
            return await _context.RoutineDays
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        private static Expression<Func<RoutineDay, bool>> BuildPredicate(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(RoutineDay), "r");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(RoutineDay.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(RoutineDay).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            return Expression.Lambda<Func<RoutineDay, bool>>(predicate, parameter);
        }

        public async Task<IEnumerable<RoutineDayDetailViewModel>> GetRoutineDayDetailsAsync()
        {
            var query = from d in _context.RoutineDays
                        join r in _context.RoutineTemplates on d.RoutineTemplateId equals r.Id
                        join e in _context.Exercises on d.ExerciseId equals e.Id
                        join c in _context.CategoryExercises on e.CategoryExerciseId equals c.Id
                        join m in _context.Machines on e.MachineId equals m.Id into machineJoin
                        from m in machineJoin.DefaultIfEmpty()
                        where r.IsActive
                        orderby r.Id, d.DayNumber
                        select new RoutineDayDetailViewModel
                        {
                            RoutineId = r.Id,
                            DayNumber = d.DayNumber,
                            ExerciseName = e.Name,
                            ExerciseDescription = e.Description ?? string.Empty,
                            Sets = d.Sets,
                            Repetitions = d.Repetitions,
                            RequiresEquipment = e.RequiresEquipment,
                            CategoryName = c.Name,
                            IsBodyweight = r.IsBodyweight,
                            IsCalisthenic = r.IsCalisthenic,
                            IsDefault = r.IsDefault,
                            MachineName = m != null ? m.Name : null
                        };
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Guid>> CreateRoutineDaysAsync(IEnumerable<RoutineDay> routineDays)
        {
            if (routineDays == null) throw new ArgumentNullException(nameof(routineDays));
            var ids = new List<Guid>();
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var routineDay in routineDays)
                {
                    routineDay.Id = Guid.NewGuid();
                    routineDay.CreatedAt = DateTime.UtcNow;
                    routineDay.IsActive = true;
                    _context.RoutineDays.Add(routineDay);
                    ids.Add(routineDay.Id);
                }
                await _context.SaveChangesAsync().ConfigureAwait(false);
                await transaction.CommitAsync();
                return ids;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
