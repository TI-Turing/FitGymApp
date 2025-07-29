using System;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Persistence.Seed
{
    public static class BranchServiceTypeSeed
    {
        public static async Task SeedAsync(GymmetryContext context)
        {
            var serviceTypes = new[]
            {
                new { Name = "Entrenamiento Personalizado", Description = "Sesiones individuales con entrenador." },
                new { Name = "Clases Grupales", Description = "Clases de yoga, pilates, spinning, etc." },
                new { Name = "Nutrición", Description = "Asesoría y planes nutricionales." },
                new { Name = "Fisioterapia", Description = "Servicios de rehabilitación física." },
                new { Name = "Spa / Masajes", Description = "Masajes y tratamientos de relajación." },
                new { Name = "Evaluación Física", Description = "Valoración inicial y seguimiento físico." },
                new { Name = "Zona de Cardio", Description = "Acceso a máquinas de cardio." },
                new { Name = "Zona de Pesas", Description = "Acceso a pesas libres y máquinas de fuerza." },
                new { Name = "Entrenamiento Funcional", Description = "Circuitos y rutinas funcionales." },
                new { Name = "Otros", Description = "Servicios adicionales según la sede." }
            };

            foreach (var type in serviceTypes)
            {
                if (!context.BranchServiceTypes.Any(x => x.Name == type.Name))
                {
                    context.BranchServiceTypes.Add(new BranchServiceType
                    {
                        Id = Guid.NewGuid(),
                        Name = type.Name,
                        Description = type.Description,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    });
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
