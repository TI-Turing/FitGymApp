using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Machine.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
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
