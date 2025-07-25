using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class ConfigAutoRepository : IConfigAutoRepository
    {
        private readonly GymmetryContext _context;
        public ConfigAutoRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task UpdateUsdPricesAsync(decimal usdToCopRate)
        {
            var gymPlanSelectedTypes = await _context.GymPlanSelectedTypes.Where(p => p.Price != null).ToListAsync();
            foreach (var gymPlanSelectedType in gymPlanSelectedTypes)
            {
                gymPlanSelectedType.UsdPrice = gymPlanSelectedType.Price / usdToCopRate;
            }

            var plans = await _context.PlanTypes.Where(p => p.Price != null).ToListAsync();
            foreach (var plan in plans)
            {
                plan.UsdPrice = plan.Price / usdToCopRate;
            }
            await _context.SaveChangesAsync();
        }
    }
}
