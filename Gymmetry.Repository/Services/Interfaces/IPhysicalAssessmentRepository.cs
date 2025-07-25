using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IPhysicalAssessmentRepository
    {
        Task<PhysicalAssessment> CreatePhysicalAssessmentAsync(PhysicalAssessment assessment);
        Task<PhysicalAssessment?> GetPhysicalAssessmentByIdAsync(Guid id);
        Task<IEnumerable<PhysicalAssessment>> GetAllPhysicalAssessmentsAsync();
        Task<bool> UpdatePhysicalAssessmentAsync(PhysicalAssessment assessment);
        Task<bool> DeletePhysicalAssessmentAsync(Guid id);
        Task<IEnumerable<PhysicalAssessment>> FindPhysicalAssessmentsByFieldsAsync(Dictionary<string, object> filters);
    }
}
