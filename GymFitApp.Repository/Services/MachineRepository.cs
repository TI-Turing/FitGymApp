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
    public class MachineRepository : IMachineRepository
    {
        private readonly FitGymAppContext _context;
        public MachineRepository(FitGymAppContext context)
        {
            _context = context;
        }

        public async Task<Machine> CreateMachineAsync(Machine machine)
        {
            machine.Id = Guid.NewGuid();
            machine.CreatedAt = DateTime.UtcNow;
            machine.IsActive = true;
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();
            return machine;
        }

        public async Task<Machine?> GetMachineByIdAsync(Guid id)
        {
            return await _context.Machines.FirstOrDefaultAsync(m => m.Id == id && m.IsActive);
        }

        public async Task<IEnumerable<Machine>> GetAllMachinesAsync()
        {
            return await _context.Machines.Where(m => m.IsActive).ToListAsync();
        }

        public async Task<bool> UpdateMachineAsync(Machine machine)
        {
            var existing = await _context.Machines.FirstOrDefaultAsync(m => m.Id == machine.Id && m.IsActive);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(machine);
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMachineAsync(Guid id)
        {
            var entity = await _context.Machines.FirstOrDefaultAsync(m => m.Id == id && m.IsActive);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Machine>> FindMachinesByFieldsAsync(Dictionary<string, object> filters)
        {
            var parameter = Expression.Parameter(typeof(Machine), "m");
            Expression predicate = Expression.Equal(
                Expression.Property(parameter, nameof(Machine.IsActive)),
                Expression.Constant(true)
            );
            foreach (var filter in filters)
            {
                var property = typeof(Machine).GetProperty(filter.Key);
                if (property == null) continue;
                var left = Expression.Property(parameter, property);
                var right = Expression.Constant(ValueConverter.ConvertValueToType(filter.Value, property.PropertyType));
                var equals = Expression.Equal(left, right);
                predicate = Expression.AndAlso(predicate, equals);
            }
            var lambda = Expression.Lambda<Func<Machine, bool>>(predicate, parameter);
            return await _context.Machines.Where(lambda).ToListAsync();
        }

        public async Task CreateMachinesAsync(IEnumerable<Machine> machines)
        {
            foreach (var machine in machines)
            {
                machine.Id = Guid.NewGuid();
                machine.CreatedAt = DateTime.UtcNow;
                machine.IsActive = true;
            }
            await _context.Machines.AddRangeAsync(machines);
            await _context.SaveChangesAsync();
        }

        public async Task AddMachineCategoryAsync(MachineCategory machineCategory)
        {
            _context.MachineCategories.Add(machineCategory);
            await _context.SaveChangesAsync();
        }

        public async Task ClearMachineCategoriesAsync(Guid machineId)
        {
            var categories = _context.MachineCategories.Where(mc => mc.MachineId == machineId);
            _context.MachineCategories.RemoveRange(categories);
            await _context.SaveChangesAsync();
        }
    }
}
