using FitGymApp.Domain.Models;
using FitGymApp.Infrastructure.Persistence.Seeds;
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
            await BrandSeed.SeedAsync(context);
            await MachineCategoryTypeSeed.SeedAsync(context);
            await VerificationTypeSeed.SeedAsync(context);
            await CategoryExerciseSeed.SeedAsync(context);
            await ExerciseSeed.SeedAsync(context);
            await RoutineTemplateSeed.SeedAsync(context);
        }
    }
}
