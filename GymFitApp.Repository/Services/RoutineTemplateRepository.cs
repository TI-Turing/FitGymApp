using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitGymApp.Repository.Services
{
    public class RoutineTemplateRepository : IRoutineTemplateRepository
    {
        private readonly FitGymAppContext _context;
        public RoutineTemplateRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<RoutineTemplate> CreateRoutineTemplateAsync(RoutineTemplate entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true;
            await _context.RoutineTemplates.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RoutineTemplate> GetRoutineTemplateByIdAsync(Guid id)
        {
            return await _context.RoutineTemplates.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }

        public async Task<IEnumerable<RoutineTemplate>> GetAllRoutineTemplatesAsync()
        {
            return await _context.RoutineTemplates.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateRoutineTemplateAsync(RoutineTemplate entity)
        {
            var existing = await _context.RoutineTemplates.FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteRoutineTemplateAsync(Guid id)
        {
            var entity = await _context.RoutineTemplates.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<RoutineTemplate>> FindRoutineTemplatesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(RoutineTemplate), "e");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(RoutineTemplate.IsActive)),
                Expression.Constant(true)
            );

            foreach (var filter in filters)
            {
                var property = typeof(RoutineTemplate).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }

            var lambda = Expression.Lambda<Func<RoutineTemplate, bool>>(predicate, parameter);
            return await _context.RoutineTemplates.Where(lambda).ToListAsync();
        }

        public async Task<Guid> DuplicateRoutineTemplateAsync(Guid routineTemplateId, Guid gymId)
        {
            var original = await _context.RoutineTemplates
                .Include(rt => rt.RoutineDays)
                .AsNoTracking()
                .FirstOrDefaultAsync(rt => rt.Id == routineTemplateId && rt.IsActive)
                .ConfigureAwait(false);
            if (original == null)
                throw new InvalidOperationException("RoutineTemplate not found");

            var newTemplate = new RoutineTemplate
            {
                Id = Guid.NewGuid(),
                Name = original.Name,
                Comments = original.Comments,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                GymId = gymId,
                RoutineUserRoutineId = original.RoutineUserRoutineId,
                RoutineAssignedId = original.RoutineAssignedId,
                IsDefault = false,
                TagsObjectives = original.TagsObjectives,
                TagsMachines = original.TagsMachines,
                IsBodyweight = original.IsBodyweight,
                RequiresEquipment = original.RequiresEquipment,
                IsCalisthenic = original.IsCalisthenic
            };
            _context.RoutineTemplates.Add(newTemplate);

            // Duplicar RoutineDays
            foreach (var day in original.RoutineDays)
            {
                var newDay = new RoutineDay
                {
                    Id = Guid.NewGuid(),
                    DayNumber = day.DayNumber,
                    Name = day.Name,
                    Sets = day.Sets,
                    Repetitions = day.Repetitions,
                    Notes = day.Notes,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    RoutineTemplateId = newTemplate.Id,
                    ExerciseId = day.ExerciseId
                };
                _context.RoutineDays.Add(newDay);
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return newTemplate.Id;
        }
    }
}
