using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitGymApp.Infrastructure.Persistence.Seeds
{
    public static class RoutineDaySeed
    {
        public static async Task SeedAsync(FitGymAppContext context)
        {
            // Asume que ya tienes los Ids de ejercicios y rutinas cargados previamente en context
            // y que puedes hacer búsquedas por Name para obtener los IDs
            // Ejemplo: var pressBancaId = context.Exercises.FirstOrDefault(e => e.Name == "Press de banca").Id;

            var routineDays = new List<RoutineDay>();

            // ==================== 1. Full Body sin equipo - Principiante ===================
            var fullBodySinEquipoId = Guid.Parse("4F5A2645-F6F0-4B96-A0A6-92D2D7BCC534");

            // Día 1: Full Body básico
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Full Body - Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Movilidad articular general", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Full Body - Tren inferior", Sets = 4, Repetitions = "15", Notes = "Descansar 1 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla búlgara").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Full Body - Tren superior", Sets = 4, Repetitions = "12", Notes = "Descansar 1 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Full Body - Espalda", Sets = 4, Repetitions = "12", Notes = "Descansar 1 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Full Body - Core", Sets = 3, Repetitions = "20", Notes = "Descansar 45s", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Full Body - Cardio", Sets = 3, Repetitions = "1m", Notes = "Alta intensidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Full Body - Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Enfasis en cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 2: Tren inferior y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Lower Body - Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de cadera y skipping bajo", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Skipping bajo").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Lower Body - Piernas", Sets = 4, Repetitions = "15", Notes = "Sentadilla goblet (si tienes mancuerna, sino sentadilla normal)", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Lower Body - Zancadas", Sets = 4, Repetitions = "12 por pierna", Notes = "Descansar 1 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Zancada caminando").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Lower Body - Glúteos", Sets = 4, Repetitions = "15", Notes = "Enfasis en técnica", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Lower Body - Core", Sets = 3, Repetitions = "30s", Notes = "Plancha isométrica", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Lower Body - Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Enfasis en cuádriceps y psoas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cuádriceps").Id }
            });
            // Día 3: Tren superior
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Upper Body - Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Upper Body - Pecho", Sets = 4, Repetitions = "15", Notes = "Flexiones de pecho", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Upper Body - Espalda", Sets = 4, Repetitions = "12", Notes = "Remo invertido", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Upper Body - Hombro", Sets = 3, Repetitions = "15", Notes = "Elevaciones laterales (si tienes mancuernas, sino wall walk)", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Upper Body - Brazo", Sets = 3, Repetitions = "12", Notes = "Fondos de tríceps en banco", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Fondos de tríceps en banco").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Upper Body - Core", Sets = 3, Repetitions = "20", Notes = "Crunch abdominal y plancha", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Upper Body - Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Estiramiento de hombros cruzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });
            // Día 4: Cardio-HIIT
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT - Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT - Cardio", Sets = 5, Repetitions = "45s ON / 15s OFF", Notes = "Saltar cuerda / Burpees / Mountain climbers / Shadow boxing (circuito)", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT - Core", Sets = 3, Repetitions = "20", Notes = "Plancha abdominal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT - Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Estiramiento de aductores (mariposa)", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 5: Full Body variado
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Full Body - Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Full Body - Sentadilla", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Full Body - Pecho", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Full Body - Espalda", Sets = 4, Repetitions = "12", Notes = "Remo invertido", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Full Body - Core", Sets = 3, Repetitions = "20", Notes = "Crunch abdominal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Full Body - Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Postura del niño", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });
            // Día 6: Full Body - Estiramiento y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular y rotaciones columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento general", Sets = 1, Repetitions = "20m", Notes = "Estiramientos guiados de todas las cadenas musculares", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = fullBodySinEquipoId, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });

            // ==================== 2. Fuerza Total Gym ===================
            var fuerzaTotalGymId = Guid.Parse("08632DC0-E897-4EBE-8482-2FE0465B9933");
            // Días 1-6: Se alternan tren superior, inferior, fullbody, core, cardio y estiramiento
            // (El patrón para los siguientes días/rutinas sería análogo adaptando los ejercicios por coherencia...)

            // ... CONTINUARÍAS AQUÍ CON EL RESTO DE RUTINAS Y DÍAS ...

            context.RoutineDays.AddRange(routineDays);
            await context.SaveChangesAsync();
        }
    }
}