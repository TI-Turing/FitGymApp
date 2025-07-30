using System;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Persistence.Seed
{
    public static class PlanTypeSeed
    {
        public static async Task SeedAsync(GymmetryContext context)
        {
            if (!context.PlanTypes.Any(x => x.Name == "Plan Gratuito"))
            {
                context.PlanTypes.Add(new PlanType
                {
                    Id = Guid.Parse("4AA8380C-8479-4334-8236-3909BE9C842B"),
                    Name = "Plan Gratuito",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    Description = "Ideal para enganchar usuarios y mostrar el valor de Gymmetry.\n\nIncluye:\n- Acceso a rutinas básicas predeterminadas.\n- Registro de progreso físico (peso, medidas).\n- Visualización de rutinas asignadas por su gimnasio.\n- Seguimiento de asistencia y entrenamientos.\n- Acceso limitado al feed/red social de la app.\n- Notificaciones básicas (por ejemplo: recordatorio de rutina del día)."
                });
            }

            if (!context.PlanTypes.Any(x => x.Name == "Plan Básico"))
            {
                context.PlanTypes.Add(new PlanType
                {
                    Id = Guid.Parse("292DC91C-DCA1-4ED0-9551-76A01AE79970"),
                    Name = "Plan Básico",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    Price = 5000,
                    Description = "Para usuarios que quieren más personalización sin ir al extremo.\n\nIncluye todo lo anterior, más:\n- Rutinas personalizadas según objetivos (ganancia muscular, pérdida de peso, etc.).\n- Historial detallado de entrenamientos.\n- Acceso a planes de dieta básicos (diseñados por IA o plantillas).\n- Soporte por chat básico con entrenadores del gimnasio (si el gimnasio tiene esa opción).\n- Estadísticas semanales de progreso."
                });
            }

            if (!context.PlanTypes.Any(x => x.Name == "Plan Premium"))
            {
                context.PlanTypes.Add(new PlanType
                {
                    Id = Guid.Parse("EBBE819A-3603-41AA-80B3-D998B3244328"),
                    Name = "Plan Premium",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    Price = 15000,
                    Description = "Para usuarios comprometidos con su salud y que quieren lo mejor.\n\nIncluye todo lo anterior, más:\n- Chat con nutricionistas o entrenadores certificados (según disponibilidad).\n- Planes de dieta personalizados.\n- Videos de cada ejercicio en su rutina.\n- Corrección de técnica por IA (subiendo un video corto o análisis del movimiento).\n- Comunidad exclusiva con eventos, retos mensuales y premios.\n- Sincronización con wearables (smartwatch, banda cardíaca)."
                });
            }

            if (!context.PlanTypes.Any(x => x.Name == "Plan Familiar o Duo"))
            {
                context.PlanTypes.Add(new PlanType
                {
                    Id = Guid.Parse("1773DD85-18E3-4BF3-BFD6-611517CB4B33"),
                    Name = "Plan Familiar o Duo",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    Price = 25000,
                    Description = "Pensado para parejas o familias que entrenan juntos.\n\nIncluye todo lo del Premium, para 2 o más usuarios.\n- Descuentos para familiares adicionales.\n- Retos familiares o entre amigos.\n- Compartir progreso en grupo."
                });
            }

            await context.SaveChangesAsync();
        }
    }
}