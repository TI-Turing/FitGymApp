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

            // ========== 2. Fuerza Total Gym ==========
            var rid = Guid.Parse("08632DC0-E897-4EBE-8482-2FE0465B9933");
            // Día 1: Pecho-Hombro-Tríceps
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento general", Sets = 1, Repetitions = "5m", Notes = "Movilidad escapular (bandas)", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press de banca", Sets = 5, Repetitions = "8-12", Notes = "Descanso 2 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press inclinado con barra", Sets = 4, Repetitions = "8-12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Press inclinado con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Fondos en paralelas", Sets = 4, Repetitions = "10-12", Notes = "Si no puedes haz fondos en banco", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press militar con barra", Sets = 4, Repetitions = "8-12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Extensión de tríceps en cuerda", Sets = 4, Repetitions = "12-15", Notes = "Descanso 1 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de pectoral en pared", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de pecho en pared").Id }
            });
            // Día 2: Pierna-Glúteo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento de tren inferior", Sets = 1, Repetitions = "5m", Notes = "Movilidad articular de tobillos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad articular de tobillos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Sentadilla frontal con barra", Sets = 5, Repetitions = "8-12", Notes = "Descanso 2 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Peso muerto rumano", Sets = 4, Repetitions = "10-12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Prensa de piernas vertical", Sets = 4, Repetitions = "10-12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Prensa de piernas vertical").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl femoral en máquina", Sets = 4, Repetitions = "12-15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Gemelos de pie en máquina", Sets = 4, Repetitions = "15-20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Gemelos de pie en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de cuádriceps", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cuádriceps").Id }
            });
            // Día 3: Espalda-Brazo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento dorsal", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Remo con barra", Sets = 5, Repetitions = "8-12", Notes = "Descanso 2 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Jalón al pecho", Sets = 4, Repetitions = "10-12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Jalón al pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Remo bajo en polea", Sets = 4, Repetitions = "10-12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Remo bajo en polea").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl martillo con mancuernas", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Curl martillo con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });
            // Día 4: Full Body explosivo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento dinámico", Sets = 1, Repetitions = "5m", Notes = "Jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 5, Repetitions = "8", Notes = "Descanso 2 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Kettlebell swing", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Kettlebell swing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Box Jump", Sets = 5, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Descanso 30s", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "5m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 5: Core y funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento core", Sets = 1, Repetitions = "5m", Notes = "Rotación de cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de cadera").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Descanso 1 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha lateral", Sets = 3, Repetitions = "45s x lado", Notes = "Descanso 30s", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Bear Crawl", Sets = 4, Repetitions = "30m", Notes = "Avanzar y retroceder", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Farmer Walk", Sets = 4, Repetitions = "40m", Notes = "Mantener core estable", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Farmer Walk").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });
            // Día 6: Cardio y estiramiento largo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Entrenamiento cardiovascular", Sets = 8, Repetitions = "3 min", Notes = "Caminadora (trote ligero)", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Caminadora (trote ligero)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Bicicleta estática", Sets = 6, Repetitions = "5 min", Notes = "Ritmo moderado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Bicicleta estática").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento general", Sets = 1, Repetitions = "15m", Notes = "Estiramientos guiados", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 3. Piernas y Glúteos Tonificados
            var rid3 = Guid.Parse("A1111111-0000-4000-8000-000000000003");
            // Día 1: Pierna - Cuádriceps y glúteo
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento tren inferior", Sets = 1, Repetitions = "7m", Notes = "Movilidad articular y skipping bajo", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Skipping bajo").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Prensa de piernas vertical", Sets = 5, Repetitions = "12", Notes = "Descanso 1:30 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Prensa de piernas vertical").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Desplante con barra", Sets = 4, Repetitions = "12 por pierna", Notes = "Descanso 1:30 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Desplante con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Extensión de cuádriceps en máquina", Sets = 4, Repetitions = "15", Notes = "Controlar movimiento", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de cuádriceps en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de cuádriceps", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cuádriceps").Id }
            });
            // Día 2: Femoral, glúteos y core
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de cadera").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Peso muerto rumano", Sets = 5, Repetitions = "10", Notes = "Descanso 2 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl femoral en máquina", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Sentadilla búlgara", Sets = 4, Repetitions = "10 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla búlgara").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });
            // Día 3: Glúteo, abductores y core
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Desplante lateral", Sets = 3, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha lateral", Sets = 3, Repetitions = "30s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 4: Fuerza, combinados y cardio
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Saltar cuerda", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Zancadas con barra", Sets = 4, Repetitions = "12 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Zancadas con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Peso muerto sumo", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto sumo").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Step touch", Sets = 4, Repetitions = "2m", Notes = "Cardio suave entre ejercicios", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de psoas", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de psoas").Id }
            });
            // Día 5: Glúteo, isquios y abductores
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Curl femoral tumbado", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral tumbado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Desplante lateral", Sets = 3, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha lateral", Sets = 3, Repetitions = "30s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });
            // Día 6: Pierna completa + Estiramiento largo
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Calentamiento global", Sets = 1, Repetitions = "7m", Notes = "Movilidad articular general", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad articular de tobillos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Prensa de piernas en máquina", Sets = 5, Repetitions = "12", Notes = "Descanso 1:30", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Press de piernas en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Peso muerto sumo", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto sumo").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Gemelos de pie en máquina", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Gemelos de pie en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "10m", Notes = "Estiramientos guiados de tren inferior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid3, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });

            // 4. HIIT Express en Casa
            var rid4 = Guid.Parse("A1111111-0000-4000-8000-000000000004");
            // Día 1: HIIT Circuito 1
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento HIIT", Sets = 1, Repetitions = "5m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Circuito HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Burpees", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Circuito HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Mountain climbers", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Circuito HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Sentadilla búlgara", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla búlgara").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Circuito HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Flexiones de pecho", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Estiramiento de cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 2: HIIT Circuito 2
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Shadow boxing y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Circuito HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Saltar cuerda", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Circuito HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Step touch", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Circuito HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Crunch abdominal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Circuito HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Plancha abdominal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Estiramiento de cuádriceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cuádriceps").Id }
            });
            // Día 3: HIIT Core & Cardio
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad articular de tobillos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Burpees", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Plancha lateral", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Bear Crawl", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Crunch abdominal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Estiramiento de cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 4: HIIT Full Body
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Flexiones de pecho", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Desplante lateral", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Plancha abdominal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Saltar cuerda", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Estiramiento de aductores (mariposa)", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 5: HIIT Cardio Resistencia
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Burpees", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Mountain climbers", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Sentadilla búlgara", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla búlgara").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "HIIT", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "Plancha abdominal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento", Sets = 1, Repetitions = "5m", Notes = "Estiramiento de cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 6: HIIT Fullbody + Movilidad
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular y rotaciones columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Estiramientos guiados y postura del niño", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid4, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 5. Espalda y Brazos Power
            var rid5 = Guid.Parse("A1111111-0000-4000-8000-000000000005");
            // Día 1: Espalda gruesa y fuerza de agarre
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento dorsal", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Peso muerto", Sets = 5, Repetitions = "6-8", Notes = "Fuerza máxima, descanso 2min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo con barra", Sets = 5, Repetitions = "8-10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo con barra supino", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra supino").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo con barra T", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra T").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Farmer Walk", Sets = 3, Repetitions = "40m", Notes = "Mantener core estable", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Farmer Walk").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });
            // Día 2: Espalda vertical y bíceps
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 5, Repetitions = "8-12", Notes = "Si puedes, usa lastre", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Jalón al pecho", Sets = 4, Repetitions = "10-12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Jalón al pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo unilateral con mancuerna", Sets = 4, Repetitions = "10 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Remo unilateral con mancuerna").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl con barra", Sets = 4, Repetitions = "12", Notes = "Bíceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl martillo con mancuernas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Curl martillo con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "Relaja la espalda", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });
            // Día 3: Power brazos y antebrazo
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl de bíceps concentrado", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Curl de bíceps concentrado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl de bíceps en banco inclinado", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Curl de bíceps en banco inclinado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Extensión de tríceps en cuerda", Sets = 4, Repetitions = "12", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Fondos de tríceps en banco", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Fondos de tríceps en banco").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Extensión de muñeca", Sets = 3, Repetitions = "15", Notes = "Antebrazo", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de muñeca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de tríceps", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de tríceps").Id }
            });
            // Día 4: Espalda funcional y core
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Movilidad escapular y jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo ergómetro", Sets = 4, Repetitions = "4min", Notes = "Cardio funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo bajo en polea", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Remo bajo en polea").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo invertido", Sets = 4, Repetitions = "12", Notes = "Si puedes, realiza con lastre", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Superman", Sets = 3, Repetitions = "15", Notes = "Espalda baja", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Superman").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });
            // Día 5: Full Arm Power
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Curl predicador con barra", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Curl predicador con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Extensión de tríceps en máquina", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Elevaciones laterales", Sets = 3, Repetitions = "15", Notes = "Hombro", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Elevaciones frontales de hombro", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones frontales de hombro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Face pull en polea", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Face pull en polea").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de tríceps", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de tríceps").Id }
            });
            // Día 6: Espalda, brazos y estiramiento largo
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad global", Sets = 1, Repetitions = "8m", Notes = "Movilidad escapular y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Rotaciones de columna").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Remo en máquina", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Remo en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Dominadas", Sets = 4, Repetitions = "8-10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Extensión de muñeca", Sets = 3, Repetitions = "15", Notes = "Antebrazo", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de muñeca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Abducción de hombro en polea baja", Sets = 3, Repetitions = "12", Notes = "Hombro", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de hombro en polea baja").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "10m", Notes = "Estiramiento largo y relajación", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid5, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // 6. Fuerza y Potencia Explosiva
            var rid6 = Guid.Parse("A1111111-0000-4000-8000-000000000006");
            // Día 1: Sentadilla y explosividad tren inferior
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento dinámico", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla frontal con barra", Sets = 5, Repetitions = "8", Notes = "Explosivo al subir", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 5, Repetitions = "10", Notes = "Máxima altura", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Zancadas con barra", Sets = 4, Repetitions = "12 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Zancadas con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Kettlebell swing", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Kettlebell swing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de cuádriceps", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cuádriceps").Id }
            });
            // Día 2: Power tren superior + core
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press de banca", Sets = 5, Repetitions = "8", Notes = "Explosivo", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Clean & Press", Sets = 5, Repetitions = "8", Notes = "Foco en potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });
            // Día 3: Fullbody explosivo
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Thrusters", Sets = 5, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto sumo", Sets = 5, Repetitions = "10", Notes = "Explosivo", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto sumo").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Kettlebell swing", Sets = 4, Repetitions = "20", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Kettlebell swing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Slam ball", Sets = 4, Repetitions = "15", Notes = "Explosión máxima", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Slam ball").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha lateral", Sets = 3, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "5m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 4: Tren inferior velocidad/agilidad
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Skipping bajo y movilidad tobillos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Skipping bajo").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Box Jump", Sets = 5, Repetitions = "12", Notes = "Velocidad máxima", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Lunge twist", Sets = 4, Repetitions = "12 por pierna", Notes = "Control y potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Lunge twist").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Subir escaleras", Sets = 5, Repetitions = "2m", Notes = "Rápido, descanso corto", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Subir escaleras").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de psoas", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de psoas").Id }
            });
            // Día 5: Tren superior fuerza/potencia
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Rotación de brazos y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Clean & Press", Sets = 5, Repetitions = "8", Notes = "Foco en potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Press militar con barra", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Press Arnold", Sets = 4, Repetitions = "10", Notes = "Variación potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Press Arnold").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Fondos en paralelas", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });
            // Día 6: Fullbody, recuperación y estiramiento largo
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular y rotaciones columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento general", Sets = 1, Repetitions = "15m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid6, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 7. Tonificación Total Mujer
            var rid7 = Guid.Parse("A1111111-0000-4000-8000-000000000007");
            // Día 1: Tren inferior y glúteos
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "Descanso 1 min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Abducción de cadera en máquina", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Desplante lateral", Sets = 4, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Curl femoral en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "Pantorrillas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });
            // Día 2: Tren superior y brazos
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press de banca con mancuernas", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Aperturas con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Aperturas con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Elevaciones laterales", Sets = 3, Repetitions = "15", Notes = "Hombro", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl con barra", Sets = 3, Repetitions = "15", Notes = "Bíceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Patada de tríceps", Sets = 3, Repetitions = "15", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Patada de tríceps").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de tríceps", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de tríceps").Id }
            });
            // Día 3: Glúteo, pierna y core
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl femoral en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Desplante con barra", Sets = 3, Repetitions = "12 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Desplante con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 4: Tren superior y core
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Press de banca con mancuernas", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Aperturas con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Aperturas con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Elevaciones laterales", Sets = 3, Repetitions = "15", Notes = "Hombro", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Curl con barra", Sets = 3, Repetitions = "15", Notes = "Bíceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Patada de tríceps", Sets = 3, Repetitions = "15", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Patada de tríceps").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de tríceps", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de tríceps").Id }
            });
            // Día 5: Fullbody funcional
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Wall ball", Sets = 4, Repetitions = "15", Notes = "Funcional y metabólico", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Wall ball").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Bear Crawl", Sets = 4, Repetitions = "30m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 6: Cardio, core y estiramiento largo
            routineDays.AddRange(new[] {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Cardio suave", Sets = 1, Repetitions = "10m", Notes = "Caminadora (trote ligero)", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Caminadora (trote ligero)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento general", Sets = 1, Repetitions = "10m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid7, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 8. Movilidad y Postura
            var rid8 = Guid.Parse("A1111111-0000-4000-8000-000000000008");
            // Día 1: Movilidad general y postura básica
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Rotaciones de columna y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Rotaciones de columna").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Movilidad articular de tobillos", Sets = 2, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad articular de tobillos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Rotación de cadera", Sets = 2, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de cadera").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Movilidad escapular (bandas)", Sets = 2, Repetitions = "20", Notes = "Si tienes banda elástica", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de psoas", Sets = 2, Repetitions = "30s por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de psoas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de aductores (mariposa)", Sets = 2, Repetitions = "30s", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 2: Flexión y extensión columna
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Rotación de brazos y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Movilidad escapular (bandas)", Sets = 2, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha lateral", Sets = 2, Repetitions = "45s por lado", Notes = "Mantener el cuerpo alineado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha lateral con rotación", Sets = 2, Repetitions = "15 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral con rotación").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de cadena posterior", Sets = 2, Repetitions = "30s", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 3: Movilidad de cadera y tobillo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Jumping jacks y movilidad tobillos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Movilidad articular de tobillos", Sets = 2, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad articular de tobillos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de cuádriceps", Sets = 2, Repetitions = "30s por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cuádriceps").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 2, Repetitions = "30s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 2, Repetitions = "30s", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 4: Movilidad escapular y cuello
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Movilidad escapular (bandas)", Sets = 2, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de hombros cruzado", Sets = 2, Repetitions = "30s por brazo", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de cuello lateral", Sets = 2, Repetitions = "30s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cuello lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de dorsal", Sets = 2, Repetitions = "30s", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });
            // Día 5: Movilidad global y postura
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento global", Sets = 1, Repetitions = "8m", Notes = "Rotaciones de columna y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Rotaciones de columna").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha lateral", Sets = 2, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha lateral con rotación", Sets = 2, Repetitions = "15 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral con rotación").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de cadena posterior", Sets = 2, Repetitions = "30s", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Postura del niño (yoga)", Sets = 2, Repetitions = "1m", Notes = "Relajación final", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });
            // Día 6: Sesión larga movilidad y estiramiento integral
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular general", Sets = 1, Repetitions = "12m", Notes = "Repetir todos los ejercicios previos en circuito suave", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad articular de tobillos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "15m", Notes = "Combina cadenas posterior, psoas, aductores, cuello y postura del niño", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid8, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });

            // 9. Cardio HIIT Avanzado
            var rid9 = Guid.Parse("A1111111-0000-4000-8000-000000000009");
            // Día 1: HIIT Fullbody
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento HIIT", Sets = 1, Repetitions = "8m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT intenso", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Mountain climbers", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Alta intensidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 4, Repetitions = "45s", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "4m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 2: Cardio funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo ergómetro", Sets = 6, Repetitions = "3m ON / 1m OFF", Notes = "Cardio funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Step touch", Sets = 5, Repetitions = "2m", Notes = "Recuperación activa", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha lateral", Sets = 4, Repetitions = "45s por lado", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "4m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 3: HIIT avanzado y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Shadow boxing y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "HIIT", Sets = 6, Repetitions = "40s ON / 20s OFF", Notes = "Burpees", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "HIIT", Sets = 6, Repetitions = "40s ON / 20s OFF", Notes = "Mountain climbers", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "HIIT", Sets = 6, Repetitions = "40s ON / 20s OFF", Notes = "Flexiones de pecho", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "HIIT", Sets = 6, Repetitions = "40s ON / 20s OFF", Notes = "Sentadilla búlgara", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla búlgara").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "4m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 4: Cardio y HIIT funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad articular de tobillos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT funcional", Sets = 6, Repetitions = "45s ON / 15s OFF", Notes = "Bear Crawl", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT funcional", Sets = 6, Repetitions = "45s ON / 15s OFF", Notes = "Battle ropes", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Battle ropes").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "HIIT funcional", Sets = 6, Repetitions = "45s ON / 15s OFF", Notes = "Box Jump", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "4m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });
            // Día 5: HIIT express metabólico
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Mountain climbers", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Intenso", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "45s", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "4m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });
            // Día 6: Cardio largo + movilidad/estiramiento
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Calentamiento movilidad", Sets = 1, Repetitions = "8m", Notes = "Movilidad articular y jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Remo ergómetro", Sets = 6, Repetitions = "3m ON / 1m OFF", Notes = "Cardio largo", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Caminadora (trote ligero)", Sets = 3, Repetitions = "10m", Notes = "Cardio moderado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Caminadora (trote ligero)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid9, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 10. Definición Muscular Gym
            var rid10 = Guid.Parse("A1111111-0000-4000-8000-000000000010");

            // Día 1: Pecho y Core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press de banca", Sets = 4, Repetitions = "12", Notes = "Descanso 1min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press inclinado con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Press inclinado con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Aperturas con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Aperturas con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de pecho en pared", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de pecho en pared").Id }
            });

            // Día 2: Espalda y Cardio
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Remo ergómetro y movilidad dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Jalón al pecho", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Jalón al pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo bajo en polea", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Remo bajo en polea").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 3, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo ergómetro", Sets = 4, Repetitions = "3m ON / 1m OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 3: Pierna y glúteo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Prensa de piernas vertical", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Prensa de piernas vertical").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Desplante con barra", Sets = 4, Repetitions = "12 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Desplante con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl femoral en máquina", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "Pantorrilla", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });

            // Día 4: Hombro y brazos
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Press militar con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Press de hombros con mancuernas sentado", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Press de hombros con mancuernas sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Elevaciones laterales", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Curl con barra", Sets = 3, Repetitions = "15", Notes = "Bíceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Extensión de tríceps en cuerda", Sets = 3, Repetitions = "15", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de tríceps", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de tríceps").Id }
            });

            // Día 5: Cardio HIIT y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Mountain climbers", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Intenso", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 6: Estiramiento largo y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento integral", Sets = 1, Repetitions = "15m", Notes = "Postura del niño, cadena posterior, aductores, tríceps y pectoral", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid10, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 11. Tren Superior en Casa
            var rid11 = Guid.Parse("A1111111-0000-4000-8000-000000000011");

            // Día 1: Full upper body calisténico
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento superior", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Flexiones de pecho", Sets = 4, Repetitions = "15", Notes = "Descanso 1min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo invertido", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Fondos de tríceps en banco", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Fondos de tríceps en banco").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Elevaciones laterales", Sets = 3, Repetitions = "15", Notes = "Si tienes mancuernas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 2: Espalda y bíceps
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Shadow boxing y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo invertido", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl con barra", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl martillo con mancuernas", Sets = 3, Repetitions = "15", Notes = "Si tienes mancuernas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Curl martillo con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Superman", Sets = 3, Repetitions = "15", Notes = "Espalda baja", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Superman").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 3: Pecho, hombro y tríceps
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Flexiones de pecho", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Fondos de tríceps en banco", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Fondos de tríceps en banco").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones laterales", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Patada de tríceps", Sets = 3, Repetitions = "15", Notes = "Si tienes mancuernas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Patada de tríceps").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de pecho en pared", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de pecho en pared").Id }
            });

            // Día 4: Espalda y hombro
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Shadow boxing y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo invertido", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Elevaciones laterales", Sets = 3, Repetitions = "15", Notes = "Si tienes mancuernas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 3, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Superman", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Superman").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 5: Fullbody calisténico y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Flexiones de pecho", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Remo invertido", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Fondos de tríceps en banco", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Fondos de tríceps en banco").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 6: Estiramiento y movilidad integral
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad completa", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid11, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 12. Fullbody Express en Casa
            var rid12 = Guid.Parse("A1111111-0000-4000-8000-000000000012");

            // Día 1: Fullbody circuito
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento global", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "Sin peso o con mancuerna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Flexiones de pecho", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo invertido", Sets = 3, Repetitions = "10", Notes = "Si tienes barra baja o TRX", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Desplante lateral", Sets = 3, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "5m", Notes = "Cadena posterior y postura del niño", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Flexiones de pecho", Sets = 4, Repetitions = "15", Notes = "Descanso 1min", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo invertido", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Elevaciones laterales", Sets = 3, Repetitions = "15", Notes = "Si tienes mancuernas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior y glúteos
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Desplante con barra", Sets = 3, Repetitions = "12 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Desplante con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "Si tienes banda elástica", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Cardio HIIT y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Burpees", Sets = 4, Repetitions = "30s ON / 30s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Mountain climbers", Sets = 4, Repetitions = "30s ON / 30s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 5: Fullbody funcional y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento global", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Bear Crawl", Sets = 4, Repetitions = "20m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Estiramiento largo y movilidad integral
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad completa", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid12, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 13. Fuerza Funcional Intermedia
            var rid13 = Guid.Parse("A1111111-0000-4000-8000-000000000013");

            // Día 1: Fullbody funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento global", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "Fullbody", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Kettlebell swing", Sets = 4, Repetitions = "15", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Kettlebell swing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Bear Crawl", Sets = 4, Repetitions = "20m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior fuerza
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 4, Repetitions = "10", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Flexiones de pecho", Sets = 4, Repetitions = "15", Notes = "Descanso corto", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo invertido", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior potencia
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "12", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Box Jump", Sets = 4, Repetitions = "10", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Desplante lateral", Sets = 3, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento dinámico", Sets = 1, Repetitions = "7m", Notes = "Shadow boxing y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Kettlebell swing", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Kettlebell swing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 4, Repetitions = "20m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 3, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento global", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Sesión larga recuperación y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid13, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 14. Cardio & Core Express
            var rid14 = Guid.Parse("A1111111-0000-4000-8000-000000000014");

            // Día 1: Cardio HIIT
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Burpees", Sets = 4, Repetitions = "30s ON / 30s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Mountain climbers", Sets = 4, Repetitions = "30s ON / 30s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento general", Sets = 1, Repetitions = "4m", Notes = "Cadena posterior y postura del niño", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Core intenso
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "Sin descanso", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha lateral", Sets = 4, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Bear Crawl", Sets = 3, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 3: Cardio funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Step touch", Sets = 4, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });

            // Día 4: HIIT metabólico
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Burpees", Sets = 4, Repetitions = "30s ON / 30s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Mountain climbers", Sets = 4, Repetitions = "30s ON / 30s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "4m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core express y funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Bear Crawl", Sets = 3, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 6: Estiramiento y movilidad integral
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad completa", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento general", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores, dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid14, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 15. Glúteo y Pierna Mujer Intermedio
            var rid15 = Guid.Parse("A1111111-0000-4000-8000-000000000015");

            // Día 1: Glúteo enfocado
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Hip Thrust con barra", Sets = 4, Repetitions = "15", Notes = "Glúteo", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Hip Thrust con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Abducción de cadera en máquina", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Desplante lateral", Sets = 3, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Peso muerto rumano con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "Pantorrillas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 2: Pierna y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl femoral en máquina", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Desplante con barra", Sets = 3, Repetitions = "12 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Desplante con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 3: Pierna posterior y glúteo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl femoral en máquina", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody funcional y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento global", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 3, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 5: Cardio HIIT y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Burpees", Sets = 4, Repetitions = "30s ON / 30s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Mountain climbers", Sets = 4, Repetitions = "30s ON / 30s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento general", Sets = 1, Repetitions = "4m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Estiramiento largo y movilidad integral
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad completa", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento general", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid15, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 16. Fullbody Funcional Hombre
            var rid16 = Guid.Parse("A1111111-0000-4000-8000-000000000016");

            // Día 1: Fullbody fuerza y potencia
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento global", Sets = 1, Repetitions = "8m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 4, Repetitions = "10", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Bear Crawl", Sets = 4, Repetitions = "20m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "6m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior fuerza y empuje
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y jumping jacks", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 4, Repetitions = "10", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Flexiones de pecho", Sets = 4, Repetitions = "15", Notes = "Descanso corto", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Flexiones de pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo invertido", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior potencia y salto
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "12", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Box Jump", Sets = 4, Repetitions = "10", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Desplante lateral", Sets = 3, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico y funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento dinámico", Sets = 1, Repetitions = "7m", Notes = "Shadow boxing y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Kettlebell swing", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Kettlebell swing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 4, Repetitions = "20m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 3, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "6m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core y movilidad integral
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento global", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid16, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 17. Espalda y Core Avanzado
            var rid17 = Guid.Parse("A1111111-0000-4000-8000-000000000017");

            // Día 1: Espalda fuerza
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Remo ergómetro y movilidad dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Jalón al pecho", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Jalón al pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Dominadas", Sets = 4, Repetitions = "10", Notes = "Pronación", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo bajo en polea", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Remo bajo en polea").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 2: Espalda y core funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Step touch y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo invertido", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Remo invertido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Superman", Sets = 4, Repetitions = "15", Notes = "Espalda baja", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Superman").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha lateral", Sets = 3, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 3: Cardio HIIT y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Mountain climbers", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Intenso", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento general", Sets = 1, Repetitions = "4m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 4: Espalda y core avanzado
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Remo ergómetro y movilidad dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Jalón al pecho", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Jalón al pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Dominadas", Sets = 4, Repetitions = "10", Notes = "Supinación", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo bajo en polea", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Remo bajo en polea").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 5: Core y movilidad integral
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento global", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha lateral", Sets = 3, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid17, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 18. Core y Cardio Funcional
            var rid18 = Guid.Parse("A1111111-0000-4000-8000-000000000018");

            // Día 1: Core funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha lateral", Sets = 4, Repetitions = "45s por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Bear Crawl", Sets = 4, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 2: Cardio HIIT
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Mountain climbers", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento general", Sets = 1, Repetitions = "4m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 3: Cardio funcional y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Step touch", Sets = 4, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });

            // Día 4: HIIT funcional y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Step touch y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Burpees", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Mountain climbers", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 4, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 5: Cardio express y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Step touch", Sets = 4, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Estiramiento largo y movilidad integral
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad completa", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento general", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid18, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 19. Tren Inferior Fuerza y Potencia
            var rid19 = Guid.Parse("A1111111-0000-4000-8000-000000000019");

            // Día 1: Pierna fuerza
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Prensa de piernas vertical", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Prensa de piernas vertical").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Peso muerto rumano con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Curl femoral en máquina", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "Pantorrillas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 2: Pierna y salto
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Box Jump", Sets = 4, Repetitions = "10", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Desplante lateral", Sets = 3, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl femoral en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Curl femoral en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 3: Cardio HIIT y tren inferior
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Step touch y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Mountain climbers", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 4: Tren inferior funcional
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 4, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Desplante con barra", Sets = 4, Repetitions = "12 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Desplante con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 5: Cardio, abdomen y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "7m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Estiramiento y movilidad global
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid19, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 20. Tren Superior Hipertrofia
            var rid20 = Guid.Parse("A1111111-0000-4000-8000-000000000020");

            // Día 1: Pecho y tríceps
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press de banca", Sets = 4, Repetitions = "12", Notes = "Hipertrofia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press inclinado con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Press inclinado con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Aperturas con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Aperturas con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Extensión de tríceps en cuerda", Sets = 4, Repetitions = "15", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de pecho en pared", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de pecho en pared").Id }
            });

            // Día 2: Espalda y bíceps
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Remo ergómetro y movilidad dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Jalón al pecho", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Jalón al pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo bajo en polea", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Remo bajo en polea").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl con barra", Sets = 4, Repetitions = "15", Notes = "Bíceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl martillo con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Curl martillo con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 3: Hombro y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Press militar con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Press de hombros con mancuernas sentado", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Press de hombros con mancuernas sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones laterales", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 4: Fullbody superior y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Press de banca", Sets = 4, Repetitions = "12", Notes = "Hipertrofia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Curl con barra", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Extensión de tríceps en cuerda", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 5: Cardio y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Mountain climbers", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 6: Estiramiento y movilidad total
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid20, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 21. Fullbody Express Avanzado
            var rid21 = Guid.Parse("A1111111-0001-4000-8000-000000000021");

            // Día 1: Fullbody HIIT
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "Fullbody", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 4, Repetitions = "10", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "6m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior avanzado
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 4, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 4, Repetitions = "12", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "Pantorrillas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Shadow boxing y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "Fullbody", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 4, Repetitions = "10", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 4, Repetitions = "20m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 3, Repetitions = "45s por lado", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "6m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid21, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 22. Cardio Metabólico y Core
            var rid22 = Guid.Parse("A1111111-0001-4000-8000-000000000022");

            // Día 1: Cardio HIIT y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Burpees", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Mountain climbers", Sets = 5, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento general", Sets = 1, Repetitions = "6m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Cardio funcional y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Step touch", Sets = 4, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });

            // Día 3: HIIT funcional y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Burpees", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Mountain climbers", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Bear Crawl", Sets = 4, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 4: Cardio express y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Saltar cuerda", Sets = 5, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Step touch", Sets = 4, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core express y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Movilidad y estiramiento largo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid22, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 23. Tren Inferior Express
            var rid23 = Guid.Parse("A1111111-0001-4000-8000-000000000023");

            // Día 1: Pierna fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Prensa de piernas vertical", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Prensa de piernas vertical").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Peso muerto rumano con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 2: Pierna y salto
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Box Jump", Sets = 4, Repetitions = "10", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Desplante lateral", Sets = 3, Repetitions = "12 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 3: Cardio HIIT y tren inferior
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Step touch y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Burpees", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Mountain climbers", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla goblet", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 4: Pierna funcional express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 4, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Desplante con barra", Sets = 4, Repetitions = "12 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Desplante con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 5: Cardio express y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Step touch", Sets = 4, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Estiramiento y movilidad global
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid23, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 24. Tren Superior Express
            var rid24 = Guid.Parse("A1111111-0001-4000-8000-000000000024");

            // Día 1: Pecho y tríceps express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press de banca", Sets = 4, Repetitions = "12", Notes = "Hipertrofia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press inclinado con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Press inclinado con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Extensión de tríceps en cuerda", Sets = 4, Repetitions = "15", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de pecho en pared", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de pecho en pared").Id }
            });

            // Día 2: Espalda y bíceps express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Remo ergómetro y movilidad dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Jalón al pecho", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Jalón al pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo bajo en polea", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Remo bajo en polea").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Curl con barra", Sets = 4, Repetitions = "15", Notes = "Bíceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 3: Hombro y core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Press militar con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones laterales", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones laterales").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 4: Fullbody superior express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Press de banca", Sets = 4, Repetitions = "12", Notes = "Hipertrofia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Curl con barra", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Extensión de tríceps en cuerda", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 5: Cardio y core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Burpees", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Mountain climbers", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 6: Recuperación y movilidad total
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid24, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 25. Fullbody Funcional Express
            var rid25 = Guid.Parse("A1111111-0001-4000-8000-000000000025");

            // Día 1: Fullbody HIIT express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Burpees", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 3, Repetitions = "12", Notes = "Fullbody", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 3, Repetitions = "10", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 3, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 3, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior y core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 3, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 2, Repetitions = "20", Notes = "Pantorrillas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Shadow boxing y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 3, Repetitions = "12", Notes = "Fullbody", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 3, Repetitions = "10", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 3, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 2, Repetitions = "45s por lado", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core y movilidad express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "7m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "8m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid25, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 26. Cardio Express y Core
            var rid26 = Guid.Parse("A1111111-0001-4000-8000-000000000026");

            // Día 1: Cardio HIIT y Core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Burpees", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Mountain climbers", Sets = 4, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Cardio funcional y core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Step touch", Sets = 3, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de cadena posterior", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de cadena posterior").Id }
            });

            // Día 3: HIIT funcional y core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Burpees", Sets = 3, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Mountain climbers", Sets = 3, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Bear Crawl", Sets = 3, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 4: Cardio express y core
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Step touch", Sets = 3, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "4m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core express y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "7m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Movilidad y estiramiento largo express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "8m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid26, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });


            // 27. Tren Inferior Power Express
            var rid27 = Guid.Parse("A1111111-0001-4000-8000-000000000027");

            // Día 1: Power pierna express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla frontal con barra", Sets = 3, Repetitions = "10", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 3, Repetitions = "8", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Peso muerto rumano con mancuernas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 2: Fuerza y salto express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Desplante lateral", Sets = 3, Repetitions = "10 por lado", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Desplante lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Box Jump", Sets = 3, Repetitions = "8", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 3: Cardio HIIT y tren inferior express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Burpees", Sets = 3, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Mountain climbers", Sets = 3, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Saltar cuerda", Sets = 3, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla goblet", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla goblet").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 4: Tren inferior funcional express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 3, Repetitions = "12m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Desplante con barra", Sets = 3, Repetitions = "10 por pierna", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Desplante con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 5: Cardio express y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 3, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Step touch", Sets = 3, Repetitions = "2m", Notes = "Intervalos", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento general", Sets = 1, Repetitions = "4m", Notes = "Postura del niño y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Estiramiento y movilidad global express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "8m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid27, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 28. Tren Superior Power Express
            var rid28 = Guid.Parse("A1111111-0001-4000-8000-000000000028");

            // Día 1: Power tren superior express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press militar con barra", Sets = 3, Repetitions = "10", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo con barra", Sets = 3, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Fondos en paralelas", Sets = 3, Repetitions = "10", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Dominadas", Sets = 3, Repetitions = "8", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 2: Espalda y pectoral power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Remo ergómetro y movilidad dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Remo ergómetro").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 3, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Jalón al pecho", Sets = 3, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Jalón al pecho").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press de banca", Sets = 3, Repetitions = "10", Notes = "Pecho", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press inclinado con barra", Sets = 3, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Press inclinado con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 3: Tríceps, bíceps y core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Fondos en paralelas", Sets = 3, Repetitions = "10", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Extensión de tríceps en cuerda", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Extensión de tríceps en cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl con barra", Sets = 3, Repetitions = "12", Notes = "Bíceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Curl martillo con mancuernas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Curl martillo con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 4: Fullbody superior power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Press de banca", Sets = 3, Repetitions = "10", Notes = "Pecho", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Remo con barra", Sets = 3, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Fondos en paralelas", Sets = 3, Repetitions = "10", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Curl con barra", Sets = 3, Repetitions = "12", Notes = "Bíceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Curl con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento de dorsal", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de dorsal").Id }
            });

            // Día 5: Cardio y core power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Burpees", Sets = 3, Repetitions = "40s ON / 20s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Mountain climbers", Sets = 3, Repetitions = "40s ON / 20s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Saltar cuerda", Sets = 3, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 6: Recuperación y movilidad superior express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "8m", Notes = "Movilidad escapular, hombros y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid28, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 29. Fullbody Power Express
            var rid29 = Guid.Parse("A1111111-0001-4000-8000-000000000029");

            // Día 1: Fullbody fuerza/potencia express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 3, Repetitions = "10", Notes = "Fullbody/Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 3, Repetitions = "8", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 3, Repetitions = "8", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 3, Repetitions = "10", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 3, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 3, Repetitions = "10", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 3, Repetitions = "8", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 3, Repetitions = "10", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Box Jump", Sets = 3, Repetitions = "8", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico/potencia express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Shadow boxing y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 3, Repetitions = "10", Notes = "Fullbody", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 3, Repetitions = "8", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 3, Repetitions = "12m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 2, Repetitions = "45s por lado", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core y movilidad power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "7m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "8m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid29, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 30. Cardio Power Express
            var rid30 = Guid.Parse("A1111111-0001-4000-8000-000000000030");

            // Día 1: Cardio HIIT Power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope rápido y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Burpees", Sets = 4, Repetitions = "45s ON / 15s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Mountain climbers", Sets = 4, Repetitions = "45s ON / 15s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 3, Repetitions = "10", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Cardio funcional explosivo
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Burpees", Sets = 3, Repetitions = "45s ON / 15s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Box Jump", Sets = 3, Repetitions = "10", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Bear Crawl", Sets = 3, Repetitions = "12m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 3: HIIT power y core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope rápido y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Burpees", Sets = 4, Repetitions = "45s ON / 15s OFF", Notes = "HIIT", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Mountain climbers", Sets = 4, Repetitions = "45s ON / 15s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Mountain climbers").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de aductores (mariposa)", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de aductores (mariposa)").Id }
            });

            // Día 4: Cardio dinámico power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Step touch y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Step touch").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Saltar cuerda", Sets = 4, Repetitions = "1m ON / 30s OFF", Notes = "Cardio", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Saltar cuerda").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Burpees", Sets = 3, Repetitions = "45s ON / 15s OFF", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Burpees").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Box Jump", Sets = 3, Repetitions = "10", Notes = "Explosividad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 3, Repetitions = "12m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core y movilidad power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "7m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Movilidad y estiramiento largo power express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "8m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid30, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 31. Fullbody Intermedio Express
            var rid31 = Guid.Parse("A1111111-0002-4000-8000-000000000031");

            // Día 1: Fullbody fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jumping jacks y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla frontal con barra", Sets = 3, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press de banca", Sets = 3, Repetitions = "12", Notes = "Hipertrofia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo con barra", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior y core express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Rotación de brazos y movilidad escapular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 3, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 3, Repetitions = "12", Notes = "Tríceps", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 3, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad cadera", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 3, Repetitions = "12", Notes = "Fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 3, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 2, Repetitions = "20", Notes = "Pantorrillas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "2m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Shadow boxing y movilidad articular", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 3, Repetitions = "12", Notes = "Fullbody", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 3, Repetitions = "10", Notes = "Potencia", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 3, Repetitions = "15m", Notes = "Funcional", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 2, Repetitions = "45s por lado", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "5m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core y movilidad express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "5m", Notes = "Jump rope lento y movilidad", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope lento").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 3, Repetitions = "1m", Notes = "Core", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 3, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "7m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global", Sets = 1, Repetitions = "8m", Notes = "Movilidad escapular, tobillos y columna", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior, aductores y dorsal", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid31, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 32. Fullbody Avanzado Express
            var rid32 = Guid.Parse("A1111111-0002-4000-8000-000000000032");

            // Día 1: Fullbody fuerza avanzada express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad articular avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "10", Notes = "Fuerza avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Press de banca", Sets = 4, Repetitions = "10", Notes = "Hipertrofia avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Press de banca").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Remo con barra", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core avanzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "6m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior avanzado express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y movilidad escapular avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 4, Repetitions = "10", Notes = "Fuerza avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 4, Repetitions = "10", Notes = "Tríceps avanzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Crunch abdominal", Sets = 4, Repetitions = "20", Notes = "Core avanzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior avanzado express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope rápido y movilidad cadera avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "10", Notes = "Fuerza avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 4, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "20", Notes = "Pantorrillas", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico avanzado express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Shadow boxing y movilidad articular avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 4, Repetitions = "10", Notes = "Fullbody avanzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 4, Repetitions = "10", Notes = "Potencia avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 4, Repetitions = "15m", Notes = "Funcional avanzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 3, Repetitions = "1m por lado", Notes = "Core avanzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "6m", Notes = "Postura del niño y cadena posterior", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core avanzado y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope rápido y movilidad avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core avanzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "25", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "8m", Notes = "Postura del niño, cadena posterior y aductores", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total avanzada
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global avanzada", Sets = 1, Repetitions = "10m", Notes = "Movilidad escapular, tobillos y columna avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo avanzado", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior, aductores y dorsal avanzado", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid32, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 33. Fullbody Ultra Express
            var rid33 = Guid.Parse("A1111111-0002-4000-8000-000000000033");

            // Día 1: Fullbody ultra fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jumping jacks y movilidad global intensa", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "Fullbody ultra fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 4, Repetitions = "10", Notes = "Potencia ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 4, Repetitions = "10", Notes = "Explosividad ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "7m", Notes = "Postura del niño y cadena posterior avanzada", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior ultra express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Rotación de brazos y movilidad escapular ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 4, Repetitions = "12", Notes = "Fuerza ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 4, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 4, Repetitions = "12", Notes = "Tríceps ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 4, Repetitions = "10", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior ultra express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope rápido y movilidad cadera ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 4, Repetitions = "12", Notes = "Fuerza ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 4, Repetitions = "18", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 4, Repetitions = "18", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 3, Repetitions = "25", Notes = "Pantorrillas ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "3m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico ultra express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Shadow boxing y movilidad avanzada ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 4, Repetitions = "12", Notes = "Fullbody ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 4, Repetitions = "10", Notes = "Potencia ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 4, Repetitions = "15m", Notes = "Funcional ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 3, Repetitions = "1m por lado", Notes = "Core ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "7m", Notes = "Postura del niño y cadena posterior ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core ultra y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "6m", Notes = "Jump rope rápido y movilidad ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 4, Repetitions = "1m", Notes = "Core ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 4, Repetitions = "25", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "9m", Notes = "Postura del niño, cadena posterior y aductores ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total ultra
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global ultra", Sets = 1, Repetitions = "11m", Notes = "Movilidad escapular, tobillos y columna ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo ultra", Sets = 1, Repetitions = "11m", Notes = "Postura del niño, cadena posterior, aductores y dorsal ultra", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid33, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 34. Fullbody Élite Express
            var rid34 = Guid.Parse("A1111111-0002-4000-8000-000000000034");

            // Día 1: Fullbody élite fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Jumping jacks y movilidad global élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 5, Repetitions = "12", Notes = "Fullbody fuerza élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 5, Repetitions = "10", Notes = "Potencia élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 5, Repetitions = "12", Notes = "Explosividad élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 5, Repetitions = "1m", Notes = "Core élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "8m", Notes = "Postura del niño y cadena posterior élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior élite express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Rotación de brazos y movilidad escapular élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 5, Repetitions = "12", Notes = "Fuerza élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 5, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 5, Repetitions = "12", Notes = "Tríceps élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 5, Repetitions = "12", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "4m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior élite express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope rápido y movilidad cadera élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 5, Repetitions = "12", Notes = "Fuerza élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 5, Repetitions = "18", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 5, Repetitions = "18", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 4, Repetitions = "25", Notes = "Pantorrillas élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "4m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico élite express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Shadow boxing y movilidad avanzada élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 5, Repetitions = "12", Notes = "Fullbody élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 5, Repetitions = "10", Notes = "Potencia élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 5, Repetitions = "18m", Notes = "Funcional élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 4, Repetitions = "1m por lado", Notes = "Core élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "8m", Notes = "Postura del niño y cadena posterior élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core élite y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "7m", Notes = "Jump rope rápido y movilidad élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 5, Repetitions = "1m", Notes = "Core élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 5, Repetitions = "25", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Postura del niño, cadena posterior y aductores élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total élite
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global élite", Sets = 1, Repetitions = "12m", Notes = "Movilidad escapular, tobillos y columna élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo élite", Sets = 1, Repetitions = "12m", Notes = "Postura del niño, cadena posterior, aductores y dorsal élite", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid34, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 35. Fullbody Supreme Express
            var rid35 = Guid.Parse("A1111111-0002-4000-8000-000000000035");

            // Día 1: Fullbody supreme fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "9m", Notes = "Jumping jacks y movilidad supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 6, Repetitions = "15", Notes = "Fullbody supreme fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 6, Repetitions = "12", Notes = "Potencia supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 6, Repetitions = "15", Notes = "Explosividad supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 6, Repetitions = "1m", Notes = "Core supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "9m", Notes = "Postura del niño y cadena posterior supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior supreme express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Rotación de brazos y movilidad escapular supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 6, Repetitions = "15", Notes = "Fuerza supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 6, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 6, Repetitions = "15", Notes = "Tríceps supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 6, Repetitions = "15", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "5m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior supreme express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Jump rope rápido y movilidad cadera supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 6, Repetitions = "15", Notes = "Fuerza supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 6, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 6, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 5, Repetitions = "30", Notes = "Pantorrillas supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "5m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico supreme express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Shadow boxing y movilidad avanzada supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 6, Repetitions = "15", Notes = "Fullbody supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 6, Repetitions = "12", Notes = "Potencia supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 6, Repetitions = "18m", Notes = "Funcional supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 5, Repetitions = "1m por lado", Notes = "Core supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "9m", Notes = "Postura del niño y cadena posterior supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core supreme y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "8m", Notes = "Jump rope rápido y movilidad supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 6, Repetitions = "1m", Notes = "Core supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 6, Repetitions = "30", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "12m", Notes = "Postura del niño, cadena posterior y aductores supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total supreme
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global supreme", Sets = 1, Repetitions = "14m", Notes = "Movilidad escapular, tobillos y columna supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo supreme", Sets = 1, Repetitions = "14m", Notes = "Postura del niño, cadena posterior, aductores y dorsal supreme", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid35, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 36. Fullbody Infinity Express
            var rid36 = Guid.Parse("A1111111-0002-4000-8000-000000000036");

            // Día 1: Fullbody infinity fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "10m", Notes = "Jumping jacks y movilidad infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 7, Repetitions = "18", Notes = "Fullbody infinity fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 7, Repetitions = "15", Notes = "Potencia infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 7, Repetitions = "18", Notes = "Explosividad infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 7, Repetitions = "1m", Notes = "Core infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "10m", Notes = "Postura del niño y cadena posterior infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior infinity express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "9m", Notes = "Rotación de brazos y movilidad escapular infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 7, Repetitions = "18", Notes = "Fuerza infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 7, Repetitions = "18", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 7, Repetitions = "18", Notes = "Tríceps infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 7, Repetitions = "18", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "6m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior infinity express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "9m", Notes = "Jump rope rápido y movilidad cadera infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 7, Repetitions = "18", Notes = "Fuerza infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 7, Repetitions = "22", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 7, Repetitions = "22", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 6, Repetitions = "35", Notes = "Pantorrillas infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "6m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico infinity express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "9m", Notes = "Shadow boxing y movilidad avanzada infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 7, Repetitions = "18", Notes = "Fullbody infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 7, Repetitions = "15", Notes = "Potencia infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 7, Repetitions = "20m", Notes = "Funcional infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 6, Repetitions = "1m por lado", Notes = "Core infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "10m", Notes = "Postura del niño y cadena posterior infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core infinity y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "9m", Notes = "Jump rope rápido y movilidad infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 7, Repetitions = "1m", Notes = "Core infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 7, Repetitions = "35", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "14m", Notes = "Postura del niño, cadena posterior y aductores infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total infinity
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global infinity", Sets = 1, Repetitions = "16m", Notes = "Movilidad escapular, tobillos y columna infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo infinity", Sets = 1, Repetitions = "16m", Notes = "Postura del niño, cadena posterior, aductores y dorsal infinity", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid36, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 37. Fullbody Legend Express
            var rid37 = Guid.Parse("A1111111-0002-4000-8000-000000000037");

            // Día 1: Fullbody legend fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "12m", Notes = "Jumping jacks y movilidad legendaria", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 8, Repetitions = "20", Notes = "Fullbody legend fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 8, Repetitions = "15", Notes = "Potencia legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 8, Repetitions = "20", Notes = "Explosividad legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 8, Repetitions = "1m", Notes = "Core legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "12m", Notes = "Postura del niño y cadena posterior legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior legend express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "10m", Notes = "Rotación de brazos y movilidad escapular legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 8, Repetitions = "20", Notes = "Fuerza legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 8, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 8, Repetitions = "20", Notes = "Tríceps legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 8, Repetitions = "20", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "7m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior legend express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "10m", Notes = "Jump rope rápido y movilidad cadera legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 8, Repetitions = "20", Notes = "Fuerza legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 8, Repetitions = "25", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 8, Repetitions = "25", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 7, Repetitions = "40", Notes = "Pantorrillas legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "7m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico legend express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "10m", Notes = "Shadow boxing y movilidad avanzada legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 8, Repetitions = "20", Notes = "Fullbody legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 8, Repetitions = "15", Notes = "Potencia legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 8, Repetitions = "22m", Notes = "Funcional legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 7, Repetitions = "1m por lado", Notes = "Core legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "12m", Notes = "Postura del niño y cadena posterior legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core legend y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "10m", Notes = "Jump rope rápido y movilidad legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 8, Repetitions = "1m", Notes = "Core legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 8, Repetitions = "40", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "16m", Notes = "Postura del niño, cadena posterior y aductores legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total legend
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global legend", Sets = 1, Repetitions = "18m", Notes = "Movilidad escapular, tobillos y columna legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo legend", Sets = 1, Repetitions = "18m", Notes = "Postura del niño, cadena posterior, aductores y dorsal legend", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid37, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 38. Fullbody Myth Express
            var rid38 = Guid.Parse("A1111111-0002-4000-8000-000000000038");

            // Día 1: Fullbody myth fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "14m", Notes = "Jumping jacks y movilidad myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 9, Repetitions = "22", Notes = "Fullbody myth fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 9, Repetitions = "18", Notes = "Potencia myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 9, Repetitions = "22", Notes = "Explosividad myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 9, Repetitions = "1m", Notes = "Core myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "14m", Notes = "Postura del niño y cadena posterior myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior myth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "12m", Notes = "Rotación de brazos y movilidad escapular myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 9, Repetitions = "22", Notes = "Fuerza myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 9, Repetitions = "22", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 9, Repetitions = "22", Notes = "Tríceps myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 9, Repetitions = "22", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "8m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior myth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "12m", Notes = "Jump rope rápido y movilidad cadera myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 9, Repetitions = "22", Notes = "Fuerza myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 9, Repetitions = "28", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 9, Repetitions = "28", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 8, Repetitions = "45", Notes = "Pantorrillas myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "8m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico myth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "12m", Notes = "Shadow boxing y movilidad avanzada myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 9, Repetitions = "22", Notes = "Fullbody myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 9, Repetitions = "18", Notes = "Potencia myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 9, Repetitions = "22m", Notes = "Funcional myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 8, Repetitions = "1m por lado", Notes = "Core myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "14m", Notes = "Postura del niño y cadena posterior myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core myth y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "12m", Notes = "Jump rope rápido y movilidad myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 9, Repetitions = "1m", Notes = "Core myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 9, Repetitions = "45", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "18m", Notes = "Postura del niño, cadena posterior y aductores myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total myth
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global myth", Sets = 1, Repetitions = "20m", Notes = "Movilidad escapular, tobillos y columna myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo myth", Sets = 1, Repetitions = "20m", Notes = "Postura del niño, cadena posterior, aductores y dorsal myth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid38, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 39. Fullbody Ultimate Express
            var rid39 = Guid.Parse("A1111111-0002-4000-8000-000000000039");

            // Día 1: Fullbody ultimate fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "16m", Notes = "Jumping jacks y movilidad ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 10, Repetitions = "25", Notes = "Fullbody ultimate fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 10, Repetitions = "20", Notes = "Potencia ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 10, Repetitions = "25", Notes = "Explosividad ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 10, Repetitions = "1m", Notes = "Core ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "16m", Notes = "Postura del niño y cadena posterior ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior ultimate express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "14m", Notes = "Rotación de brazos y movilidad escapular ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 10, Repetitions = "25", Notes = "Fuerza ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 10, Repetitions = "25", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 10, Repetitions = "25", Notes = "Tríceps ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 10, Repetitions = "25", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "9m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior ultimate express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "14m", Notes = "Jump rope rápido y movilidad cadera ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 10, Repetitions = "25", Notes = "Fuerza ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 10, Repetitions = "30", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 10, Repetitions = "30", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 9, Repetitions = "50", Notes = "Pantorrillas ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "9m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico ultimate express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "14m", Notes = "Shadow boxing y movilidad avanzada ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 10, Repetitions = "25", Notes = "Fullbody ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 10, Repetitions = "20", Notes = "Potencia ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 10, Repetitions = "25m", Notes = "Funcional ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 9, Repetitions = "1m por lado", Notes = "Core ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "16m", Notes = "Postura del niño y cadena posterior ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core ultimate y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "14m", Notes = "Jump rope rápido y movilidad ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 10, Repetitions = "1m", Notes = "Core ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 10, Repetitions = "50", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "20m", Notes = "Postura del niño, cadena posterior y aductores ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total ultimate
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global ultimate", Sets = 1, Repetitions = "22m", Notes = "Movilidad escapular, tobillos y columna ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo ultimate", Sets = 1, Repetitions = "22m", Notes = "Postura del niño, cadena posterior, aductores y dorsal ultimate", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid39, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 40. Fullbody Godmode Express
            var rid40 = Guid.Parse("A1111111-0002-4000-8000-000000000040");

            // Día 1: Fullbody godmode fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "18m", Notes = "Jumping jacks y movilidad godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 11, Repetitions = "28", Notes = "Fullbody godmode fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 11, Repetitions = "22", Notes = "Potencia godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 11, Repetitions = "28", Notes = "Explosividad godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 11, Repetitions = "1m", Notes = "Core godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "18m", Notes = "Postura del niño y cadena posterior godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior godmode express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "16m", Notes = "Rotación de brazos y movilidad escapular godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 11, Repetitions = "28", Notes = "Fuerza godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 11, Repetitions = "28", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 11, Repetitions = "28", Notes = "Tríceps godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 11, Repetitions = "28", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "10m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior godmode express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "16m", Notes = "Jump rope rápido y movilidad cadera godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 11, Repetitions = "28", Notes = "Fuerza godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 11, Repetitions = "35", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 11, Repetitions = "35", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 10, Repetitions = "55", Notes = "Pantorrillas godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "10m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico godmode express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "16m", Notes = "Shadow boxing y movilidad avanzada godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 11, Repetitions = "28", Notes = "Fullbody godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 11, Repetitions = "22", Notes = "Potencia godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 11, Repetitions = "28m", Notes = "Funcional godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 10, Repetitions = "1m por lado", Notes = "Core godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "18m", Notes = "Postura del niño y cadena posterior godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core godmode y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "16m", Notes = "Jump rope rápido y movilidad godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 11, Repetitions = "1m", Notes = "Core godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 11, Repetitions = "55", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "22m", Notes = "Postura del niño, cadena posterior y aductores godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total godmode
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global godmode", Sets = 1, Repetitions = "24m", Notes = "Movilidad escapular, tobillos y columna godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo godmode", Sets = 1, Repetitions = "24m", Notes = "Postura del niño, cadena posterior, aductores y dorsal godmode", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid40, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 41. Fullbody Overlord Express
            var rid41 = Guid.Parse("A1111111-0003-4000-8000-000000000041");

            // Día 1: Fullbody overlord fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "20m", Notes = "Jumping jacks y movilidad overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 12, Repetitions = "30", Notes = "Fullbody overlord fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 12, Repetitions = "25", Notes = "Potencia overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 12, Repetitions = "30", Notes = "Explosividad overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 12, Repetitions = "1m", Notes = "Core overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "20m", Notes = "Postura del niño y cadena posterior overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior overlord express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "18m", Notes = "Rotación de brazos y movilidad escapular overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 12, Repetitions = "30", Notes = "Fuerza overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 12, Repetitions = "30", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 12, Repetitions = "30", Notes = "Tríceps overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 12, Repetitions = "30", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "12m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior overlord express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "18m", Notes = "Jump rope rápido y movilidad cadera overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 12, Repetitions = "30", Notes = "Fuerza overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 12, Repetitions = "38", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 12, Repetitions = "38", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 11, Repetitions = "60", Notes = "Pantorrillas overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "12m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico overlord express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "18m", Notes = "Shadow boxing y movilidad avanzada overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 12, Repetitions = "30", Notes = "Fullbody overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 12, Repetitions = "25", Notes = "Potencia overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 12, Repetitions = "30m", Notes = "Funcional overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 11, Repetitions = "1m por lado", Notes = "Core overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "20m", Notes = "Postura del niño y cadena posterior overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core overlord y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "18m", Notes = "Jump rope rápido y movilidad overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 12, Repetitions = "1m", Notes = "Core overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 12, Repetitions = "60", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "24m", Notes = "Postura del niño, cadena posterior y aductores overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total overlord
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global overlord", Sets = 1, Repetitions = "26m", Notes = "Movilidad escapular, tobillos y columna overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo overlord", Sets = 1, Repetitions = "26m", Notes = "Postura del niño, cadena posterior, aductores y dorsal overlord", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid41, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 42. Fullbody Titan Express
            var rid42 = Guid.Parse("A1111111-0003-4000-8000-000000000042");

            // Día 1: Fullbody titan fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "22m", Notes = "Jumping jacks y movilidad titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 13, Repetitions = "32", Notes = "Fullbody titan fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 13, Repetitions = "28", Notes = "Potencia titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 13, Repetitions = "32", Notes = "Explosividad titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 13, Repetitions = "1m", Notes = "Core titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "22m", Notes = "Postura del niño y cadena posterior titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior titan express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "20m", Notes = "Rotación de brazos y movilidad escapular titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 13, Repetitions = "32", Notes = "Fuerza titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 13, Repetitions = "32", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 13, Repetitions = "32", Notes = "Tríceps titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 13, Repetitions = "32", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "14m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior titan express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "20m", Notes = "Jump rope rápido y movilidad cadera titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 13, Repetitions = "32", Notes = "Fuerza titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 13, Repetitions = "40", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 13, Repetitions = "40", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 12, Repetitions = "65", Notes = "Pantorrillas titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "14m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico titan express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "20m", Notes = "Shadow boxing y movilidad avanzada titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 13, Repetitions = "32", Notes = "Fullbody titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 13, Repetitions = "28", Notes = "Potencia titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 13, Repetitions = "32m", Notes = "Funcional titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 12, Repetitions = "1m por lado", Notes = "Core titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "22m", Notes = "Postura del niño y cadena posterior titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core titan y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "20m", Notes = "Jump rope rápido y movilidad titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 13, Repetitions = "1m", Notes = "Core titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 13, Repetitions = "65", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "26m", Notes = "Postura del niño, cadena posterior y aductores titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total titan
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global titan", Sets = 1, Repetitions = "28m", Notes = "Movilidad escapular, tobillos y columna titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo titan", Sets = 1, Repetitions = "28m", Notes = "Postura del niño, cadena posterior, aductores y dorsal titan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid42, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 43. Fullbody Colossus Express
            var rid43 = Guid.Parse("A1111111-0003-4000-8000-000000000043");

            // Día 1: Fullbody colossus fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "24m", Notes = "Jumping jacks y movilidad colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 14, Repetitions = "35", Notes = "Fullbody colossus fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 14, Repetitions = "30", Notes = "Potencia colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 14, Repetitions = "35", Notes = "Explosividad colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 14, Repetitions = "1m", Notes = "Core colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "24m", Notes = "Postura del niño y cadena posterior colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior colossus express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "22m", Notes = "Rotación de brazos y movilidad escapular colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 14, Repetitions = "35", Notes = "Fuerza colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 14, Repetitions = "35", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 14, Repetitions = "35", Notes = "Tríceps colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 14, Repetitions = "35", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "16m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior colossus express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "22m", Notes = "Jump rope rápido y movilidad cadera colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 14, Repetitions = "35", Notes = "Fuerza colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 14, Repetitions = "42", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 14, Repetitions = "42", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 13, Repetitions = "70", Notes = "Pantorrillas colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "16m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico colossus express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "22m", Notes = "Shadow boxing y movilidad avanzada colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 14, Repetitions = "35", Notes = "Fullbody colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 14, Repetitions = "30", Notes = "Potencia colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 14, Repetitions = "35m", Notes = "Funcional colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 13, Repetitions = "1m por lado", Notes = "Core colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "24m", Notes = "Postura del niño y cadena posterior colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core colossus y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "22m", Notes = "Jump rope rápido y movilidad colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 14, Repetitions = "1m", Notes = "Core colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 14, Repetitions = "70", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "28m", Notes = "Postura del niño, cadena posterior y aductores colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total colossus
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global colossus", Sets = 1, Repetitions = "30m", Notes = "Movilidad escapular, tobillos y columna colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo colossus", Sets = 1, Repetitions = "30m", Notes = "Postura del niño, cadena posterior, aductores y dorsal colossus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid43, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 44. Fullbody Behemoth Express
            var rid44 = Guid.Parse("A1111111-0003-4000-8000-000000000044");

            // Día 1: Fullbody behemoth fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "26m", Notes = "Jumping jacks y movilidad behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 15, Repetitions = "38", Notes = "Fullbody behemoth fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 15, Repetitions = "32", Notes = "Potencia behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 15, Repetitions = "38", Notes = "Explosividad behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 15, Repetitions = "1m", Notes = "Core behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "26m", Notes = "Postura del niño y cadena posterior behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior behemoth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "24m", Notes = "Rotación de brazos y movilidad escapular behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 15, Repetitions = "38", Notes = "Fuerza behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 15, Repetitions = "38", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 15, Repetitions = "38", Notes = "Tríceps behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 15, Repetitions = "38", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "18m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior behemoth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "24m", Notes = "Jump rope rápido y movilidad cadera behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 15, Repetitions = "38", Notes = "Fuerza behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 15, Repetitions = "45", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 15, Repetitions = "45", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 14, Repetitions = "75", Notes = "Pantorrillas behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "18m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico behemoth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "24m", Notes = "Shadow boxing y movilidad avanzada behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 15, Repetitions = "38", Notes = "Fullbody behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 15, Repetitions = "32", Notes = "Potencia behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 15, Repetitions = "38m", Notes = "Funcional behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 14, Repetitions = "1m por lado", Notes = "Core behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "26m", Notes = "Postura del niño y cadena posterior behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core behemoth y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "24m", Notes = "Jump rope rápido y movilidad behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 15, Repetitions = "1m", Notes = "Core behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 15, Repetitions = "75", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "30m", Notes = "Postura del niño, cadena posterior y aductores behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total behemoth
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global behemoth", Sets = 1, Repetitions = "32m", Notes = "Movilidad escapular, tobillos y columna behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo behemoth", Sets = 1, Repetitions = "32m", Notes = "Postura del niño, cadena posterior, aductores y dorsal behemoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid44, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 45. Fullbody Leviathan Express
            var rid45 = Guid.Parse("A1111111-0003-4000-8000-000000000045");

            // Día 1: Fullbody leviathan fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "28m", Notes = "Jumping jacks y movilidad leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 16, Repetitions = "40", Notes = "Fullbody leviathan fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 16, Repetitions = "35", Notes = "Potencia leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 16, Repetitions = "40", Notes = "Explosividad leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 16, Repetitions = "1m", Notes = "Core leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "28m", Notes = "Postura del niño y cadena posterior leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior leviathan express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "26m", Notes = "Rotación de brazos y movilidad escapular leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 16, Repetitions = "40", Notes = "Fuerza leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 16, Repetitions = "40", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 16, Repetitions = "40", Notes = "Tríceps leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 16, Repetitions = "40", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "18m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior leviathan express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "26m", Notes = "Jump rope rápido y movilidad cadera leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 16, Repetitions = "40", Notes = "Fuerza leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 16, Repetitions = "48", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 16, Repetitions = "48", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 15, Repetitions = "80", Notes = "Pantorrillas leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "18m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico leviathan express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "26m", Notes = "Shadow boxing y movilidad avanzada leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 16, Repetitions = "40", Notes = "Fullbody leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 16, Repetitions = "35", Notes = "Potencia leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 16, Repetitions = "40m", Notes = "Funcional leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 15, Repetitions = "1m por lado", Notes = "Core leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "28m", Notes = "Postura del niño y cadena posterior leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core leviathan y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "26m", Notes = "Jump rope rápido y movilidad leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 16, Repetitions = "1m", Notes = "Core leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 16, Repetitions = "80", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "32m", Notes = "Postura del niño, cadena posterior y aductores leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total leviathan
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global leviathan", Sets = 1, Repetitions = "34m", Notes = "Movilidad escapular, tobillos y columna leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo leviathan", Sets = 1, Repetitions = "34m", Notes = "Postura del niño, cadena posterior, aductores y dorsal leviathan", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid45, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 46. Fullbody Mammoth Express
            var rid46 = Guid.Parse("A1111111-0003-4000-8000-000000000046");

            // Día 1: Fullbody mammoth fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "30m", Notes = "Jumping jacks y movilidad mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 17, Repetitions = "45", Notes = "Fullbody mammoth fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 17, Repetitions = "40", Notes = "Potencia mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 17, Repetitions = "45", Notes = "Explosividad mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 17, Repetitions = "1m", Notes = "Core mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "30m", Notes = "Postura del niño y cadena posterior mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior mammoth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "28m", Notes = "Rotación de brazos y movilidad escapular mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 17, Repetitions = "45", Notes = "Fuerza mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 17, Repetitions = "45", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 17, Repetitions = "45", Notes = "Tríceps mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 17, Repetitions = "45", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "20m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior mammoth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "28m", Notes = "Jump rope rápido y movilidad cadera mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 17, Repetitions = "45", Notes = "Fuerza mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 17, Repetitions = "55", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 17, Repetitions = "55", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 16, Repetitions = "85", Notes = "Pantorrillas mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "20m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico mammoth express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "28m", Notes = "Shadow boxing y movilidad avanzada mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 17, Repetitions = "45", Notes = "Fullbody mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 17, Repetitions = "40", Notes = "Potencia mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 17, Repetitions = "45m", Notes = "Funcional mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 16, Repetitions = "1m por lado", Notes = "Core mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "30m", Notes = "Postura del niño y cadena posterior mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core mammoth y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "28m", Notes = "Jump rope rápido y movilidad mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 17, Repetitions = "1m", Notes = "Core mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 17, Repetitions = "85", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "34m", Notes = "Postura del niño, cadena posterior y aductores mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total mammoth
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global mammoth", Sets = 1, Repetitions = "36m", Notes = "Movilidad escapular, tobillos y columna mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo mammoth", Sets = 1, Repetitions = "36m", Notes = "Postura del niño, cadena posterior, aductores y dorsal mammoth", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid46, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 47. Fullbody Juggernaut Express
            var rid47 = Guid.Parse("A1111111-0003-4000-8000-000000000047");

            // Día 1: Fullbody juggernaut fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "32m", Notes = "Jumping jacks y movilidad juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 18, Repetitions = "48", Notes = "Fullbody juggernaut fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 18, Repetitions = "45", Notes = "Potencia juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 18, Repetitions = "48", Notes = "Explosividad juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 18, Repetitions = "1m", Notes = "Core juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "32m", Notes = "Postura del niño y cadena posterior juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior juggernaut express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "30m", Notes = "Rotación de brazos y movilidad escapular juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 18, Repetitions = "48", Notes = "Fuerza juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 18, Repetitions = "48", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 18, Repetitions = "48", Notes = "Tríceps juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 18, Repetitions = "48", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "22m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior juggernaut express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "30m", Notes = "Jump rope rápido y movilidad cadera juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 18, Repetitions = "48", Notes = "Fuerza juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 18, Repetitions = "58", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 18, Repetitions = "58", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 17, Repetitions = "90", Notes = "Pantorrillas juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "22m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico juggernaut express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "30m", Notes = "Shadow boxing y movilidad avanzada juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 18, Repetitions = "48", Notes = "Fullbody juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 18, Repetitions = "45", Notes = "Potencia juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 18, Repetitions = "48m", Notes = "Funcional juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 17, Repetitions = "1m por lado", Notes = "Core juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "32m", Notes = "Postura del niño y cadena posterior juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core juggernaut y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "30m", Notes = "Jump rope rápido y movilidad juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 18, Repetitions = "1m", Notes = "Core juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 18, Repetitions = "90", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "36m", Notes = "Postura del niño, cadena posterior y aductores juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total juggernaut
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global juggernaut", Sets = 1, Repetitions = "38m", Notes = "Movilidad escapular, tobillos y columna juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo juggernaut", Sets = 1, Repetitions = "38m", Notes = "Postura del niño, cadena posterior, aductores y dorsal juggernaut", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid47, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 48. Fullbody Titanomachy Express
            var rid48 = Guid.Parse("A1111111-0003-4000-8000-000000000048");

            // Día 1: Fullbody titanomachy fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "34m", Notes = "Jumping jacks y movilidad titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 19, Repetitions = "50", Notes = "Fullbody titanomachy fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 19, Repetitions = "48", Notes = "Potencia titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 19, Repetitions = "50", Notes = "Explosividad titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 19, Repetitions = "1m", Notes = "Core titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "34m", Notes = "Postura del niño y cadena posterior titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior titanomachy express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "32m", Notes = "Rotación de brazos y movilidad escapular titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 19, Repetitions = "50", Notes = "Fuerza titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 19, Repetitions = "50", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 19, Repetitions = "50", Notes = "Tríceps titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 19, Repetitions = "50", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "24m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior titanomachy express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "32m", Notes = "Jump rope rápido y movilidad cadera titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 19, Repetitions = "50", Notes = "Fuerza titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 19, Repetitions = "60", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 19, Repetitions = "60", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 18, Repetitions = "95", Notes = "Pantorrillas titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "24m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico titanomachy express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "32m", Notes = "Shadow boxing y movilidad avanzada titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 19, Repetitions = "50", Notes = "Fullbody titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 19, Repetitions = "48", Notes = "Potencia titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 19, Repetitions = "50m", Notes = "Funcional titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 18, Repetitions = "1m por lado", Notes = "Core titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "34m", Notes = "Postura del niño y cadena posterior titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core titanomachy y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "32m", Notes = "Jump rope rápido y movilidad titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 19, Repetitions = "1m", Notes = "Core titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 19, Repetitions = "95", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "38m", Notes = "Postura del niño, cadena posterior y aductores titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total titanomachy
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global titanomachy", Sets = 1, Repetitions = "40m", Notes = "Movilidad escapular, tobillos y columna titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo titanomachy", Sets = 1, Repetitions = "40m", Notes = "Postura del niño, cadena posterior, aductores y dorsal titanomachy", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid48, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 49. Fullbody Pantheon Express
            var rid49 = Guid.Parse("A1111111-0003-4000-8000-000000000049");

            // Día 1: Fullbody pantheon fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "36m", Notes = "Jumping jacks y movilidad pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 20, Repetitions = "55", Notes = "Fullbody pantheon fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 20, Repetitions = "50", Notes = "Potencia pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 20, Repetitions = "55", Notes = "Explosividad pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 20, Repetitions = "1m", Notes = "Core pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "36m", Notes = "Postura del niño y cadena posterior pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior pantheon express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "34m", Notes = "Rotación de brazos y movilidad escapular pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 20, Repetitions = "55", Notes = "Fuerza pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 20, Repetitions = "55", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 20, Repetitions = "55", Notes = "Tríceps pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 20, Repetitions = "55", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "26m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior pantheon express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "34m", Notes = "Jump rope rápido y movilidad cadera pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 20, Repetitions = "55", Notes = "Fuerza pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 20, Repetitions = "65", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 20, Repetitions = "65", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 19, Repetitions = "100", Notes = "Pantorrillas pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "26m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico pantheon express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "34m", Notes = "Shadow boxing y movilidad avanzada pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 20, Repetitions = "55", Notes = "Fullbody pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 20, Repetitions = "50", Notes = "Potencia pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 20, Repetitions = "55m", Notes = "Funcional pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 19, Repetitions = "1m por lado", Notes = "Core pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "36m", Notes = "Postura del niño y cadena posterior pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core pantheon y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "34m", Notes = "Jump rope rápido y movilidad pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 20, Repetitions = "1m", Notes = "Core pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 20, Repetitions = "100", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "40m", Notes = "Postura del niño, cadena posterior y aductores pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total pantheon
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global pantheon", Sets = 1, Repetitions = "42m", Notes = "Movilidad escapular, tobillos y columna pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo pantheon", Sets = 1, Repetitions = "42m", Notes = "Postura del niño, cadena posterior, aductores y dorsal pantheon", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid49, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // 50. Fullbody Olympus Express
            var rid50 = Guid.Parse("A1111111-0003-4000-8000-000000000050");

            // Día 1: Fullbody olympus fuerza express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Calentamiento", Sets = 1, Repetitions = "38m", Notes = "Jumping jacks y movilidad olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Jumping jacks").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Thrusters", Sets = 21, Repetitions = "60", Notes = "Fullbody olympus fuerza", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Clean & Press", Sets = 21, Repetitions = "55", Notes = "Potencia olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Box Jump", Sets = 21, Repetitions = "60", Notes = "Explosividad olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Box Jump").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Plancha abdominal", Sets = 21, Repetitions = "1m", Notes = "Core olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 1, Name = "Estiramiento integral", Sets = 1, Repetitions = "38m", Notes = "Postura del niño y cadena posterior olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 2: Tren superior olympus express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Calentamiento", Sets = 1, Repetitions = "36m", Notes = "Rotación de brazos y movilidad escapular olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Rotación de brazos").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Press militar con barra", Sets = 21, Repetitions = "60", Notes = "Fuerza olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Press militar con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Remo con barra", Sets = 21, Repetitions = "60", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Remo con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Fondos en paralelas", Sets = 21, Repetitions = "60", Notes = "Tríceps olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Fondos en paralelas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Dominadas", Sets = 21, Repetitions = "60", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Dominadas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 2, Name = "Estiramiento de hombros cruzado", Sets = 1, Repetitions = "28m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de hombros cruzado").Id }
            });

            // Día 3: Tren inferior olympus express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Calentamiento", Sets = 1, Repetitions = "36m", Notes = "Jump rope rápido y movilidad cadera olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Sentadilla frontal con barra", Sets = 21, Repetitions = "60", Notes = "Fuerza olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Sentadilla frontal con barra").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Peso muerto rumano con mancuernas", Sets = 21, Repetitions = "70", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Peso muerto rumano con mancuernas").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Abducción de cadera en máquina", Sets = 21, Repetitions = "70", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Abducción de cadera en máquina").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Elevaciones de talón sentado", Sets = 20, Repetitions = "110", Notes = "Pantorrillas olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Elevaciones de talón sentado").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 3, Name = "Estiramiento de glúteo piriforme", Sets = 1, Repetitions = "28m", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Estiramiento de glúteo piriforme").Id }
            });

            // Día 4: Fullbody dinámico olympus express
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Calentamiento", Sets = 1, Repetitions = "36m", Notes = "Shadow boxing y movilidad avanzada olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Shadow boxing").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Thrusters", Sets = 21, Repetitions = "60", Notes = "Fullbody olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Thrusters").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Clean & Press", Sets = 21, Repetitions = "55", Notes = "Potencia olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Clean & Press").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Bear Crawl", Sets = 21, Repetitions = "60m", Notes = "Funcional olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Bear Crawl").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Plancha lateral", Sets = 20, Repetitions = "1m por lado", Notes = "Core olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Plancha lateral").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 4, Name = "Estiramiento general", Sets = 1, Repetitions = "38m", Notes = "Postura del niño y cadena posterior olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 5: Core olympus y movilidad
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Calentamiento", Sets = 1, Repetitions = "36m", Notes = "Jump rope rápido y movilidad olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Jump rope rápido").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Plancha abdominal", Sets = 21, Repetitions = "1m", Notes = "Core olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Plancha abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Crunch abdominal", Sets = 21, Repetitions = "110", Notes = "", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Crunch abdominal").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 5, Name = "Estiramiento integral", Sets = 1, Repetitions = "44m", Notes = "Postura del niño, cadena posterior y aductores olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            // Día 6: Recuperación y movilidad total olympus
            routineDays.AddRange(new[]
            {
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Movilidad articular global olympus", Sets = 1, Repetitions = "44m", Notes = "Movilidad escapular, tobillos y columna olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Movilidad escapular (bandas)").Id },
                new RoutineDay { Id = Guid.NewGuid(), DayNumber = 6, Name = "Estiramiento largo olympus", Sets = 1, Repetitions = "44m", Notes = "Postura del niño, cadena posterior, aductores y dorsal olympus", CreatedAt = DateTime.UtcNow, IsActive = true, RoutineTemplateId = rid50, ExerciseId = context.Exercises.First(e => e.Name == "Postura del niño (yoga)").Id }
            });

            context.RoutineDays.AddRange(routineDays);
            await context.SaveChangesAsync();
        }
    }
}