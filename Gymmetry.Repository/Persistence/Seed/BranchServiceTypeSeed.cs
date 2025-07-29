using System;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using System.Collections.Generic;

namespace Gymmetry.Repository.Persistence.Seed
{
    public static class BranchServiceTypeSeed
    {
        public static async Task SeedAsync(GymmetryContext context)
        {
            var guids = new List<Guid>
            {
                Guid.Parse("C9F57394-9A4A-4B43-92E9-FFAA48BD8111"),
                Guid.Parse("3F81CCCD-3171-4ACF-9161-30899A510C83"),
                Guid.Parse("6DA6BCE0-4513-4D3A-B0BE-B6F27C58716F"),
                Guid.Parse("4BEB4D60-F894-4550-8A7F-E35F5318B90B"),
                Guid.Parse("31FAA679-9046-4C65-96A6-A8BC6220CD36"),
                Guid.Parse("42EF2BDA-40B4-4B8E-92C7-32B2E8AD72DA"),
                Guid.Parse("8A83229B-8E61-4244-8B0C-4FCE557AABFF"),
                Guid.Parse("249EE3AC-5416-45C5-B269-D4449F08F5F9"),
                Guid.Parse("AEE1AC12-8F79-4BCD-AA52-CFC1BBFAA96A"),
                Guid.Parse("1E2C499E-5945-4DF7-BB95-9150E491FC3A"),
                Guid.Parse("6C2DB5AE-3050-4B08-AC70-EFD302FE7EC8"),
                Guid.Parse("8F1F4CFC-0C81-4233-A252-9B19FBA1B19B"),
                Guid.Parse("6CF9057A-EB1A-4343-BB3C-A39AB7BB03EB"),
                Guid.Parse("710AEB39-D6B1-43A9-915C-05417E848678"),
                Guid.Parse("D0B66B02-E002-477B-980D-F04836492521"),
                Guid.Parse("769F50DC-96D5-4B43-B758-40466896020C"),
                Guid.Parse("05770C52-435C-4B89-9801-37AF9422B0F6"),
                Guid.Parse("BB0461D5-FFC3-4FC6-966E-218546DC79CF"),
                Guid.Parse("7A7E9745-9837-4EF1-B39B-3A7CFE05E86E"),
                Guid.Parse("81097102-C7FB-460E-9D58-05725C41856B"),
                Guid.Parse("2676D26E-8660-4568-8978-857826650AA4")
            };
            var random = new Random();
            var shuffledGuids = guids.OrderBy(x => random.Next()).ToList();

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

            for (int i = 0; i < serviceTypes.Length; i++)
            {
                var type = serviceTypes[i];
                var guid = shuffledGuids[i % shuffledGuids.Count];
                if (!context.BranchServiceTypes.Any(x => x.Name == type.Name))
                {
                    context.BranchServiceTypes.Add(new BranchServiceType
                    {
                        Id = guid,
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
