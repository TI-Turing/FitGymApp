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
            var rid21 = Guid.Parse("A1111111-0000-4000-8000-000000000021");

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
            var rid22 = Guid.Parse("A1111111-0000-4000-8000-000000000022");

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
            var rid23 = Guid.Parse("A1111111-0000-4000-8000-000000000023");

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
            var rid24 = Guid.Parse("A1111111-0000-4000-8000-000000000024");

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
            var rid25 = Guid.Parse("A1111111-0000-4000-8000-000000000025");

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
            var rid26 = Guid.Parse("A1111111-0000-4000-8000-000000000026");

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
            var rid27 = Guid.Parse("A1111111-0000-4000-8000-000000000027");

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
            var rid28 = Guid.Parse("A1111111-0000-4000-8000-000000000028");

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
            var rid29 = Guid.Parse("A1111111-0000-4000-8000-000000000029");

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



            context.RoutineDays.AddRange(routineDays);
            await context.SaveChangesAsync();
        }
    }
}