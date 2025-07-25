using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IBillRepository
    {
        Task<Bill> CreateBillAsync(Bill entity);
        Task<Bill?> GetBillByIdAsync(Guid id);
        Task<IEnumerable<Bill>> GetAllBillsAsync();
        Task<bool> UpdateBillAsync(Bill entity);
        Task<bool> DeleteBillAsync(Guid id);
        Task<IEnumerable<Bill>> FindBillsByFieldsAsync(Dictionary<string, object> filters);
    }
}
