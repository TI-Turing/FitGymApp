using System;
using System.Collections.Generic;
using System.Linq;
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

        // ...otros métodos...

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