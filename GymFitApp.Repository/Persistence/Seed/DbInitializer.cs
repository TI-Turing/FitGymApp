using FitGymApp.Domain.Models;
using FitGymApp.Repository.Persistence.Seed;
using GymFitApp.Repository.Persistence.Seed;
using System.Threading.Tasks;

namespace GymFitApp.Repository.Persistence.Seed
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(FitGymAppContext context)
        {
            await GymPlanSelectedTypeSeed.SeedAsync(context);
            await GymTypeSeed.SeedAsync(context);
            await PlanTypeSeed.SeedAsync(context);
            await AccessMethodTypeSeed.SeedAsync(context); // Added AccessMethodSeed
        }
    }
}
