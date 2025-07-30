using System;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Persistence.Seed
{
    public static class GymPlanSelectedTypeSeed
    {
        public static async Task SeedAsync(GymmetryContext context)
        {
            if (!context.GymPlanSelectedTypes.Any(x => x.Name == "Plan Básico"))
            {
                context.GymPlanSelectedTypes.Add(new GymPlanSelectedType
                {
                    Id = Guid.Parse("4942557C-1B1C-4F45-8C31-0AC4185F78E4"),
                    Name = "Plan Básico",
                    CreatedAt = new DateTime(2024, 1, 1),
                    IsActive = true,
                    CountryId = "COP",
                    Price = 20000,
                    UsdPrice = 5,
                    Description = "Plan Básico - $20.000 COP/mes."
                });
            }
            if (!context.GymPlanSelectedTypes.Any(x => x.Name == "Plan Pro"))
            {
                context.GymPlanSelectedTypes.Add(new GymPlanSelectedType
                {
                    Id = Guid.Parse("0B6D30CF-EF67-4A1B-9584-7B0C17E86730"),
                    Name = "Plan Pro",
                    CreatedAt = new DateTime(2024, 1, 1),
                    IsActive = true,
                    CountryId = "COP",
                    Price = 45000,
                    UsdPrice = 11,
                    Description = "Plan Pro (Gestión + Rutinas) - $45.000 COP/mes o $2.000 COP por cliente activo."
                });
            }
            if (!context.GymPlanSelectedTypes.Any(x => x.Name == "Plan Premium"))
            {
                context.GymPlanSelectedTypes.Add(new GymPlanSelectedType
                {
                    Id = Guid.Parse("3F0AAB23-C712-4836-B3FD-A51303469319"),
                    Name = "Plan Premium",
                    CreatedAt = new DateTime(2024, 1, 1),
                    IsActive = true,
                    CountryId = "COP",
                    Price = 70000,
                    UsdPrice = 17,
                    Description = "Plan Premium - $70.000 COP/mes."
                });
            }
            if (!context.GymPlanSelectedTypes.Any(x => x.Name == "Plan Corporativo"))
            {
                context.GymPlanSelectedTypes.Add(new GymPlanSelectedType
                {
                    Id = Guid.Parse("9C251808-3C44-4659-AFED-16A93D349808"),
                    Name = "Plan Corporativo",
                    CreatedAt = new DateTime(2024, 1, 1),
                    IsActive = true,
                    CountryId = "COP",
                    Price = null,
                    UsdPrice = null,
                    Description = "Plan Corporativo"
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
