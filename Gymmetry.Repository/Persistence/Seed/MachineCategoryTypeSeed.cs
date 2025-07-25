using Gymmetry.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gymmetry.Repository.Persistence.Seed
{
    public static class MachineCategoryTypeSeed
    {
        public static async Task SeedAsync(GymmetryContext context)
        {
            if (!context.MachineCategoryTypes.Any())
            {
                context.MachineCategoryTypes.AddRange(new[]
                {
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Pecho",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Espalda",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Hombros",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Bíceps",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Tríceps",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Piernas",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Glúteos",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Abdominales / Core",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Grupo Muscular: Pantorrillas",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },

                    // Tipo de equipo
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tipo de Equipo: Máquina de pesas guiadas",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tipo de Equipo: Máquina de palanca (plate-loaded)",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tipo de Equipo: Pesas libres",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tipo de Equipo: Máquinas de cardio",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tipo de Equipo: Máquinas funcionales / multipropósito",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tipo de Equipo: Accesorios",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },

                    // Tipo de movimiento
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Movimiento: Empuje (Push)",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Movimiento: Tirón (Pull)",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Movimiento: Rotación",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Movimiento: Estabilidad / Equilibrio",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Movimiento: Cardio",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Movimiento: Rehabilitación / Estiramiento",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },

                    // Uso / Propósito
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Uso: Entrenamiento de fuerza",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Uso: Hipertrofia",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Uso: Cardiovascular",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Uso: Rehabilitación",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Uso: CrossFit / Funcional",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Uso: Pliometría / Explosividad",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },

                    // Categoría por defecto
                    new MachineCategoryType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Default Machine Category",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}