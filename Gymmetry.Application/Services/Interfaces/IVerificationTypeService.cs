using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IVerificationTypeService
    {
        Task<ApplicationResponse<VerificationType>> CreateVerificationTypeAsync(VerificationType request);
        Task<ApplicationResponse<VerificationType>> GetVerificationTypeByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<VerificationType>>> GetAllVerificationTypesAsync();
        Task<ApplicationResponse<bool>> UpdateVerificationTypeAsync(VerificationType request);
        Task<ApplicationResponse<bool>> DeleteVerificationTypeAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<VerificationType>>> FindVerificationTypesByFieldsAsync(Dictionary<string, object> filters);
    }
}
