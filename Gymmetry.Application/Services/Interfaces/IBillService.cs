using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.Bill.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IBillService
    {
        Task<ApplicationResponse<Bill>> CreateBillAsync(AddBillRequest request);
        Task<ApplicationResponse<Bill>> GetBillByIdAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Bill>>> GetAllBillsAsync();
        Task<ApplicationResponse<bool>> UpdateBillAsync(UpdateBillRequest request);
        Task<ApplicationResponse<bool>> DeleteBillAsync(Guid id);
        Task<ApplicationResponse<IEnumerable<Bill>>> FindBillsByFieldsAsync(Dictionary<string, object> filters);
    }
}
