using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;

namespace FitGymApp.Repository.Services.Interfaces
{
    public interface IMachineRepository
    {
        Task<Machine> CreateMachineAsync(Machine machine);
        Task CreateMachinesAsync(IEnumerable<Machine> machines);
        Task<Machine?> GetMachineByIdAsync(Guid id);
        Task<IEnumerable<Machine>> GetAllMachinesAsync();
        Task<bool> UpdateMachineAsync(Machine machine);
        Task<bool> DeleteMachineAsync(Guid id);
        Task<IEnumerable<Machine>> FindMachinesByFieldsAsync(Dictionary<string, object> filters);
        Task AddMachineCategoryAsync(MachineCategory machineCategory);
        Task ClearMachineCategoriesAsync(Guid machineId);
    }
}
