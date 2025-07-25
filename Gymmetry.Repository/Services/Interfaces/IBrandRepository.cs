using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> CreateBrandAsync(Brand brand);
        Task<Brand?> GetBrandByIdAsync(Guid id);
        Task<IEnumerable<Brand>> GetAllBrandsAsync();
        Task<bool> UpdateBrandAsync(Brand brand);
        Task<bool> DeleteBrandAsync(Guid id);
        Task<IEnumerable<Brand>> FindBrandsByFieldsAsync(Dictionary<string, object> filters);
    }
}
