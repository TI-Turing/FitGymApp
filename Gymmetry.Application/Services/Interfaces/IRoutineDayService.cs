using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.RoutineDay.Request;
using Gymmetry.Domain.ViewModels;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IRoutineDayService
    {
        Task<ApplicationResponse<RoutineDay>> CreateRoutineDayAsync(AddRoutineDayRequest request);
        Task<ApplicationResponse<RoutineDay>> GetRoutineDayByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<RoutineDay>>> GetAllRoutineDaysAsync();
        Task<ApplicationResponse<bool>> UpdateRoutineDayAsync(UpdateRoutineDayRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteRoutineDayAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<RoutineDay>>> FindRoutineDaysByFieldsAsync(Dictionary<string, object> filters);
        Task<ApplicationResponse<IEnumerable<RoutineDayDetailViewModel>>> GetRoutineDayDetailsAsync();
    }
}
