using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;

namespace FitGymApp.Repository.Services.Interfaces
{
    public interface IVerificationTypeRepository
    {
        Task<VerificationType> CreateVerificationTypeAsync(VerificationType entity);
        Task<VerificationType> GetVerificationTypeByIdAsync(Guid id);
        Task<IEnumerable<VerificationType>> GetAllVerificationTypesAsync();
        Task<bool> UpdateVerificationTypeAsync(VerificationType entity);
        Task<bool> DeleteVerificationTypeAsync(Guid id);
        Task<IEnumerable<VerificationType>> FindVerificationTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
