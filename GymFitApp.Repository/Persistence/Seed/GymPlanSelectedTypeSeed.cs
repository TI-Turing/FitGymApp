using System;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;

namespace FitGymApp.Repository.Persistence.Seed
{
    public static class GymPlanSelectedTypeSeed
    {
        public static async Task SeedAsync(FitGymAppContext context)
        {
            if (!context.GymPlanSelectedTypes.Any(x => x.Name == "Plan Básico"))
            {
                context.GymPlanSelectedTypes.Add(new GymPlanSelectedType
                {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
