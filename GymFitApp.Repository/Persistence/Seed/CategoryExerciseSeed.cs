using System;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;

namespace GymFitApp.Repository.Persistence.Seed
{
    public static class CategoryExerciseSeed
    {
        public static async Task SeedAsync(FitGymAppContext context)
        {
            if (!context.CategoryExercises.Any(x => x.Name == "Calentamiento"))
            {
                context.CategoryExercises.Add(new CategoryExercise
                {
                    Id = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                    Name = "Calentamiento",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });
            }

            if (!context.CategoryExercises.Any(x => x.Name == "Ejercicio principal (compuesto)"))
            {
                context.CategoryExercises.Add(new CategoryExercise
                {
                    Id = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                    Name = "Ejercicio principal (compuesto)",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });
            }

            if (!context.CategoryExercises.Any(x => x.Name == "Aislado (focalizado)"))
            {
                context.CategoryExercises.Add(new CategoryExercise
                {
                    Id = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                    Name = "Aislado (focalizado)",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });
            }

            if (!context.CategoryExercises.Any(x => x.Name == "Funcional"))
            {
                context.CategoryExercises.Add(new CategoryExercise
                {
                    Id = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                    Name = "Funcional",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });
            }

            if (!context.CategoryExercises.Any(x => x.Name == "Estiramiento"))
            {
                context.CategoryExercises.Add(new CategoryExercise
                {
                    Id = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                    Name = "Estiramiento",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });
            }

            if (!context.CategoryExercises.Any(x => x.Name == "Cardio"))
            {
                context.CategoryExercises.Add(new CategoryExercise
                {
                    Id = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                    Name = "Cardio",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
