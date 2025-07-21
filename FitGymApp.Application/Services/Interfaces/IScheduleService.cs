using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Schedule.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<ApplicationResponse<Schedule>> CreateScheduleAsync(AddScheduleRequest request);
        Task<ApplicationResponse<Schedule>> GetScheduleByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Schedule>>> GetAllSchedulesAsync();
        Task<ApplicationResponse<bool>> UpdateScheduleAsync(UpdateScheduleRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeleteScheduleAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Schedule>>> FindSchedulesByFieldsAsync(Dictionary<string, object> filters);
    }
}
