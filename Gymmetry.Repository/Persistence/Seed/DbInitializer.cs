using Gymmetry.Domain.Models;
using Gymmetry.Infrastructure.Persistence.Seeds;
using Gymmetry.Repository.Persistence.Seed;
using Gymmetry.Repository.Persistence.Seed;
using System.Threading.Tasks;

namespace Gymmetry.Repository.Persistence.Seed
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(GymmetryContext context)
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
            await RoutineDaySeed.SeedAsync(context);
        }
    }
}
