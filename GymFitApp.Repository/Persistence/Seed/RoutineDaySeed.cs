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



            context.RoutineDays.AddRange(routineDays);
            await context.SaveChangesAsync();
        }
    }
}