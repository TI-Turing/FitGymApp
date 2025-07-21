using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.PhysicalAssessment.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IPhysicalAssessmentService
    {
        Task<ApplicationResponse<PhysicalAssessment>> CreatePhysicalAssessmentAsync(AddPhysicalAssessmentRequest request);
        Task<ApplicationResponse<PhysicalAssessment>> GetPhysicalAssessmentByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<PhysicalAssessment>>> GetAllPhysicalAssessmentsAsync();
        Task<ApplicationResponse<bool>> UpdatePhysicalAssessmentAsync(UpdatePhysicalAssessmentRequest request, Guid? userId, string ip = "", string invocationId = "");
        Task<ApplicationResponse<bool>> DeletePhysicalAssessmentAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<PhysicalAssessment>>> FindPhysicalAssessmentsByFieldsAsync(Dictionary<string, object> filters);
    }
}
