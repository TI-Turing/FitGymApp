using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Machine.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IMachineService
    {
        Task<ApplicationResponse<Machine>> CreateMachineAsync(AddMachineRequest request);
        Task<ApplicationResponse<Machine>> GetMachineByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Machine>>> GetAllMachinesAsync();
        Task<ApplicationResponse<bool>> UpdateMachineAsync(UpdateMachineRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteMachineAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Machine>>> FindMachinesByFieldsAsync(Dictionary<string, object> filters);
        Task<ApplicationResponse<bool>> CreateMachinesAsync(IEnumerable<AddMachineRequest> requests);
    }
}
