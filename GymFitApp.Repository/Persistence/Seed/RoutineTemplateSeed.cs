using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitGymApp.Infrastructure.Persistence.Seeds;

public static class RoutineTemplateSeed
{
    public static async Task SeedAsync(FitGymAppContext context)
    {
        if (!context.RoutineTemplates.Any())
        {
            var routines = new List<RoutineTemplate>
            {
                new RoutineTemplate
                {
                    Id = Guid.Parse("4F5A2645-F6F0-4B96-A0A6-92D2D7BCC534"),
                    Name = "Full Body sin equipo - Principiante",
                    Comments = "Cuerpo completo en casa, ideal para principiantes sin equipamiento.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 1.0, ""masa_muscular"": 0.5, ""definicion_muscular"": 0.7, ""fuerza"": 0.3,
                        ""resistencia_fisica"": 1.0, ""tonificacion"": 0.8, ""movilidad"": 0.3, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.7, ""anti_estres"": 0.4, ""energia"": 0.6,
                        ""sueño"": 0.2, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.1, ""entrenamiento_funcional"": 0.5,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.5, ""velocidad_agilidad"": 0.2,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 0.0, ""avanzado"": 0.0,
                        ""rutina_corta"": 0.5, ""rutina_larga"": 0.0, ""autoestima"": 0.7
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = true
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("08632DC0-E897-4EBE-8482-2FE0465B9933"),
                    Name = "Fuerza Total Gym",
                    Comments = "Rutina de fuerza para todo el cuerpo en gimnasio, con barra y mancuernas.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.2, ""masa_muscular"": 1.0, ""definicion_muscular"": 0.5, ""fuerza"": 1.0,
                        ""resistencia_fisica"": 0.2, ""tonificacion"": 0.3, ""movilidad"": 0.1, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.1, ""anti_estres"": 0.1, ""energia"": 0.3,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.5,
                        ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.5, ""hiit"": 0.0, ""velocidad_agilidad"": 0.1,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.5
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000003"),
                    Name = "Piernas y Glúteos Tonificados",
                    Comments = "Enfoque en tren inferior, máquinas y peso libre, nivel intermedio.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.3, ""masa_muscular"": 0.6, ""definicion_muscular"": 0.7, ""fuerza"": 0.7,
                        ""resistencia_fisica"": 0.4, ""tonificacion"": 1.0, ""movilidad"": 0.2, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.2, ""energia"": 0.3,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.1,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 0.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 0.7, ""autoestima"": 0.6
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000004"),
                    Name = "HIIT Express en Casa",
                    Comments = "Entrenamiento HIIT sin equipo, ideal para quemar grasa y mejorar resistencia.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 1.0, ""masa_muscular"": 0.3, ""definicion_muscular"": 0.8, ""fuerza"": 0.2,
                        ""resistencia_fisica"": 1.0, ""tonificacion"": 0.5, ""movilidad"": 0.2, ""postura"": 0.1,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 1.0, ""anti_estres"": 0.5, ""energia"": 0.7,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.4,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 1.0, ""velocidad_agilidad"": 0.4,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.7, ""avanzado"": 0.7,
                        ""rutina_corta"": 1.0, ""rutina_larga"": 0.0, ""autoestima"": 0.7
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = true
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000005"),
                    Name = "Espalda y Brazos Power",
                    Comments = "Gimnasio, con énfasis en fuerza y masa muscular en la espalda y brazos.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.1, ""masa_muscular"": 1.0, ""definicion_muscular"": 0.7, ""fuerza"": 0.8,
                        ""resistencia_fisica"": 0.2, ""tonificacion"": 0.3, ""movilidad"": 0.1, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.0, ""anti_estres"": 0.1, ""energia"": 0.2,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.8, ""avanzado"": 0.8,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 0.8, ""autoestima"": 0.5
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000006"),
                    Name = "Fuerza y Potencia Explosiva",
                    Comments = "Rutina avanzada para fuerza y potencia, enfoque en movimientos explosivos, gimnasio y peso libre.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.0, ""masa_muscular"": 0.7, ""definicion_muscular"": 0.3, ""fuerza"": 1.0,
                        ""resistencia_fisica"": 0.3, ""tonificacion"": 0.2, ""movilidad"": 0.2, ""postura"": 0.3,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.1, ""anti_estres"": 0.0, ""energia"": 0.8,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.7,
                        ""deportes_especificos"": 0.5, ""pruebas_fisicas"": 0.7, ""hiit"": 0.4, ""velocidad_agilidad"": 0.7,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.0, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 0.7, ""autoestima"": 0.5
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000007"),
                    Name = "Tonificación Total Mujer",
                    Comments = "Rutina para tonificar todo el cuerpo, énfasis en glúteos, piernas y abdomen.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.5, ""masa_muscular"": 0.6, ""definicion_muscular"": 0.7, ""fuerza"": 0.3,
                        ""resistencia_fisica"": 0.7, ""tonificacion"": 1.0, ""movilidad"": 0.2, ""postura"": 0.1,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.3, ""anti_estres"": 0.3, ""energia"": 0.4,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.2, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.2, ""intermedio"": 0.7, ""avanzado"": 0.4,
                        ""rutina_corta"": 0.1, ""rutina_larga"": 0.7, ""autoestima"": 1.0
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000008"),
                    Name = "Movilidad y Postura",
                    Comments = "Rutina de movilidad articular y corrección postural, ideal para cualquier edad.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.0, ""masa_muscular"": 0.0, ""definicion_muscular"": 0.0, ""fuerza"": 0.0,
                        ""resistencia_fisica"": 0.2, ""tonificacion"": 0.0, ""movilidad"": 1.0, ""postura"": 1.0,
                        ""rehabilitacion"": 0.7, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.6, ""energia"": 0.3,
                        ""sueño"": 0.3, ""adulto_mayor"": 0.7, ""enfermedades_cronicas"": 0.3, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.7, ""intermedio"": 0.6, ""avanzado"": 0.0,
                        ""rutina_corta"": 0.8, ""rutina_larga"": 0.0, ""autoestima"": 0.7
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000009"),
                    Name = "Cardio HIIT Avanzado",
                    Comments = "Entrenamiento HIIT de alta intensidad para quema extrema de grasa y mejora cardiovascular.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 1.0, ""masa_muscular"": 0.4, ""definicion_muscular"": 1.0, ""fuerza"": 0.2,
                        ""resistencia_fisica"": 1.0, ""tonificacion"": 0.5, ""movilidad"": 0.1, ""postura"": 0.0,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 1.0, ""anti_estres"": 0.5, ""energia"": 0.8,
                        ""sueño"": 0.2, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.4,
                        ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.0, ""hiit"": 1.0, ""velocidad_agilidad"": 0.5,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.5, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.7, ""rutina_larga"": 0.4, ""autoestima"": 0.8
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = true
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000010"),
                    Name = "Definición Muscular Gym",
                    Comments = "Rutina con pesas y cardio para perder grasa y definir músculos.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.8, ""masa_muscular"": 0.6, ""definicion_muscular"": 1.0, ""fuerza"": 0.5,
                        ""resistencia_fisica"": 0.6, ""tonificacion"": 0.8, ""movilidad"": 0.1, ""postura"": 0.1,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.7, ""anti_estres"": 0.5, ""energia"": 0.5,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.6, ""velocidad_agilidad"": 0.3,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 0.5,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.8
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000011"),
                    Name = "Tren Superior en Casa",
                    Comments = "Rutina sin equipo para fortalecer y tonificar pecho, espalda, hombro y brazo.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.5, ""masa_muscular"": 0.4, ""definicion_muscular"": 0.6, ""fuerza"": 0.2,
                        ""resistencia_fisica"": 0.6, ""tonificacion"": 0.7, ""movilidad"": 0.2, ""postura"": 0.1,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.4, ""anti_estres"": 0.2, ""energia"": 0.3,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.2, ""velocidad_agilidad"": 0.1,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.5, ""intermedio"": 0.8, ""avanzado"": 0.0,
                        ""rutina_corta"": 0.3, ""rutina_larga"": 0.0, ""autoestima"": 0.7
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = true
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000012"),
                    Name = "Resistencia Muscular Total",
                    Comments = "Rutina larga para mejorar resistencia muscular, ideal para deportistas.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.4, ""masa_muscular"": 0.7, ""definicion_muscular"": 0.6, ""fuerza"": 0.5,
                        ""resistencia_fisica"": 1.0, ""tonificacion"": 0.8, ""movilidad"": 0.2, ""postura"": 0.1,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.7, ""anti_estres"": 0.2, ""energia"": 0.7,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.5,
                        ""deportes_especificos"": 0.4, ""pruebas_fisicas"": 0.3, ""hiit"": 0.5, ""velocidad_agilidad"": 0.2,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.5
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000013"),
                    Name = "Rutina Salud Cardiovascular",
                    Comments = "Rutina enfocada en mejorar la salud del corazón y la capacidad aeróbica.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.7, ""masa_muscular"": 0.2, ""definicion_muscular"": 0.4, ""fuerza"": 0.1,
                        ""resistencia_fisica"": 1.0, ""tonificacion"": 0.5, ""movilidad"": 0.3, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 1.0, ""anti_estres"": 0.6, ""energia"": 0.7,
                        ""sueño"": 0.2, ""adulto_mayor"": 0.1, ""enfermedades_cronicas"": 0.5, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.8, ""velocidad_agilidad"": 0.3,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.5, ""intermedio"": 0.9, ""avanzado"": 0.3,
                        ""rutina_corta"": 0.2, ""rutina_larga"": 0.7, ""autoestima"": 0.6
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000014"),
                    Name = "Rutina Funcional Avanzada",
                    Comments = "Circuito funcional para mejorar agilidad, fuerza y movilidad, ideal para deportistas.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.6, ""masa_muscular"": 0.6, ""definicion_muscular"": 0.6, ""fuerza"": 0.7,
                        ""resistencia_fisica"": 0.7, ""tonificacion"": 0.5, ""movilidad"": 0.6, ""postura"": 0.4,
                        ""rehabilitacion"": 0.1, ""salud_cardiovascular"": 0.6, ""anti_estres"": 0.4, ""energia"": 0.8,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 1.0,
                        ""deportes_especificos"": 0.7, ""pruebas_fisicas"": 0.5, ""hiit"": 0.7, ""velocidad_agilidad"": 0.8,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.8, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.1, ""rutina_larga"": 0.7, ""autoestima"": 0.7
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000015"),
                    Name = "Entrenamiento Pareja Divertido",
                    Comments = "Rutina para realizar en pareja, combinando fuerza, cardio y coordinación.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.5, ""masa_muscular"": 0.5, ""definicion_muscular"": 0.5, ""fuerza"": 0.3,
                        ""resistencia_fisica"": 0.6, ""tonificacion"": 0.5, ""movilidad"": 0.3, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.5, ""anti_estres"": 0.7, ""energia"": 0.7,
                        ""sueño"": 0.2, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.5,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.4, ""velocidad_agilidad"": 0.3,
                        ""entrenamiento_pareja"": 1.0, ""principiante"": 0.5, ""intermedio"": 0.7, ""avanzado"": 0.4,
                        ""rutina_corta"": 0.5, ""rutina_larga"": 0.2, ""autoestima"": 0.8
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000016"),
                    Name = "Glúteos y Core Mujer",
                    Comments = "Rutina específica para fortalecer glúteos y abdomen, con énfasis en tonificación y postura.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.4, ""masa_muscular"": 0.6, ""definicion_muscular"": 0.7, ""fuerza"": 0.2,
                        ""resistencia_fisica"": 0.5, ""tonificacion"": 0.9, ""movilidad"": 0.2, ""postura"": 0.3,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.2, ""energia"": 0.3,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.3,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.1, ""intermedio"": 0.7, ""avanzado"": 0.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 0.7, ""autoestima"": 1.0
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000017"),
                    Name = "Rutina Avanzada Full Gym",
                    Comments = "Rutina de alto nivel para deportistas experimentados, fuerza, hipertrofia y potencia.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.2, ""masa_muscular"": 1.0, ""definicion_muscular"": 0.7, ""fuerza"": 1.0,
                        ""resistencia_fisica"": 0.5, ""tonificacion"": 0.6, ""movilidad"": 0.1, ""postura"": 0.1,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.1, ""energia"": 0.8,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.5,
                        ""deportes_especificos"": 0.4, ""pruebas_fisicas"": 0.8, ""hiit"": 0.0, ""velocidad_agilidad"": 0.2,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.0, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.5
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000018"),
                    Name = "Entrenamiento Funcional General",
                    Comments = "Rutina funcional para todo tipo de usuarios, combina fuerza, cardio y movilidad.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.5, ""masa_muscular"": 0.5, ""definicion_muscular"": 0.5, ""fuerza"": 0.5,
                        ""resistencia_fisica"": 0.7, ""tonificacion"": 0.7, ""movilidad"": 0.7, ""postura"": 0.5,
                        ""rehabilitacion"": 0.1, ""salud_cardiovascular"": 0.7, ""anti_estres"": 0.5, ""energia"": 0.7,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.2, ""enfermedades_cronicas"": 0.2, ""entrenamiento_funcional"": 1.0,
                        ""deportes_especificos"": 0.3, ""pruebas_fisicas"": 0.3, ""hiit"": 0.5, ""velocidad_agilidad"": 0.6,
                        ""entrenamiento_pareja"": 0.1, ""principiante"": 0.7, ""intermedio"": 1.0, ""avanzado"": 0.5,
                        ""rutina_corta"": 0.3, ""rutina_larga"": 0.7, ""autoestima"": 0.7
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000019"),
                    Name = "Core y Abdomen en Casa",
                    Comments = "Rutina de abdomen y core sólo con peso corporal, adaptable para todos los niveles.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.3, ""masa_muscular"": 0.3, ""definicion_muscular"": 0.7, ""fuerza"": 0.3,
                        ""resistencia_fisica"": 0.6, ""tonificacion"": 0.7, ""movilidad"": 0.2, ""postura"": 0.2,
                        ""rehabilitacion"": 0.1, ""salud_cardiovascular"": 0.3, ""anti_estres"": 0.3, ""energia"": 0.4,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.2, ""enfermedades_cronicas"": 0.1, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.2, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.6, ""intermedio"": 0.7, ""avanzado"": 0.5,
                        ""rutina_corta"": 0.7, ""rutina_larga"": 0.4, ""autoestima"": 0.8
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = true
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0000-4000-8000-000000000020"),
                    Name = "Rehabilitación y Movilidad",
                    Comments = "Rutina de recuperación funcional y movilidad, adecuada para post-lesión o adultos mayores.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.0, ""masa_muscular"": 0.1, ""definicion_muscular"": 0.0, ""fuerza"": 0.1,
                        ""resistencia_fisica"": 0.4, ""tonificacion"": 0.2, ""movilidad"": 1.0, ""postura"": 1.0,
                        ""rehabilitacion"": 1.0, ""salud_cardiovascular"": 0.3, ""anti_estres"": 0.5, ""energia"": 0.3,
                        ""sueño"": 0.2, ""adulto_mayor"": 1.0, ""enfermedades_cronicas"": 0.4, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 0.7, ""avanzado"": 0.0,
                        ""rutina_corta"": 0.8, ""rutina_larga"": 0.0, ""autoestima"": 0.5
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000021"),
                    Name = "Extra HIIT Funcional Intermedio",
                    Comments = "Entrenamiento funcional tipo HIIT, combina ejercicios multiarticulares para quema de grasa y mejora de agilidad.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.9, ""masa_muscular"": 0.3, ""definicion_muscular"": 0.8, ""fuerza"": 0.4,
                        ""resistencia_fisica"": 0.9, ""tonificacion"": 0.6, ""movilidad"": 0.6, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 1.0, ""anti_estres"": 0.5, ""energia"": 0.7,
                        ""sueño"": 0.2, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 1.0,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.3, ""hiit"": 1.0, ""velocidad_agilidad"": 0.6,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 0.1,
                        ""rutina_corta"": 0.7, ""rutina_larga"": 0.2, ""autoestima"": 0.6
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000022"),
                    Name = "Extra Rutina de Calistenia Avanzada",
                    Comments = "Rutina avanzada de calistenia, ideal para progresar en fuerza y control corporal.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.4, ""masa_muscular"": 0.7, ""definicion_muscular"": 0.8, ""fuerza"": 1.0,
                        ""resistencia_fisica"": 0.8, ""tonificacion"": 0.8, ""movilidad"": 0.4, ""postura"": 0.3,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.3, ""anti_estres"": 0.2, ""energia"": 0.6,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.7,
                        ""deportes_especificos"": 0.1, ""pruebas_fisicas"": 0.7, ""hiit"": 0.4, ""velocidad_agilidad"": 0.2,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.0, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 0.8, ""autoestima"": 0.8
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = true
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000023"),
                    Name = "Extra Fuerza Básica Adulto Mayor",
                    Comments = "Rutina de fuerza muy básica, ideal para adultos mayores y principiantes.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.1, ""masa_muscular"": 0.2, ""definicion_muscular"": 0.0, ""fuerza"": 0.3,
                        ""resistencia_fisica"": 0.4, ""tonificacion"": 0.3, ""movilidad"": 0.7, ""postura"": 0.8,
                        ""rehabilitacion"": 0.8, ""salud_cardiovascular"": 0.5, ""anti_estres"": 0.5, ""energia"": 0.6,
                        ""sueño"": 0.2, ""adulto_mayor"": 1.0, ""enfermedades_cronicas"": 0.6, ""entrenamiento_funcional"": 0.3,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 0.0, ""avanzado"": 0.0,
                        ""rutina_corta"": 1.0, ""rutina_larga"": 0.0, ""autoestima"": 0.8
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000024"),
                    Name = "Extra Piernas Potentes Gym",
                    Comments = "Rutina de gimnasio enfocada en fuerza y masa muscular de piernas.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.2, ""masa_muscular"": 0.8, ""definicion_muscular"": 0.5, ""fuerza"": 1.0,
                        ""resistencia_fisica"": 0.4, ""tonificacion"": 0.4, ""movilidad"": 0.2, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.0, ""anti_estres"": 0.1, ""energia"": 0.3,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.5, ""hiit"": 0.0, ""velocidad_agilidad"": 0.1,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.5
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000025"),
                    Name = "Extra Core Salud y Postura",
                    Comments = "Rutina para fortalecer el core y mejorar la postura, adaptable a todos los niveles.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.2, ""masa_muscular"": 0.1, ""definicion_muscular"": 0.2, ""fuerza"": 0.2,
                        ""resistencia_fisica"": 0.3, ""tonificacion"": 0.5, ""movilidad"": 0.4, ""postura"": 1.0,
                        ""rehabilitacion"": 0.7, ""salud_cardiovascular"": 0.1, ""anti_estres"": 0.5, ""energia"": 0.5,
                        ""sueño"": 0.2, ""adulto_mayor"": 0.7, ""enfermedades_cronicas"": 0.2, ""entrenamiento_funcional"": 0.8,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.1, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 0.8, ""avanzado"": 0.4,
                        ""rutina_corta"": 0.8, ""rutina_larga"": 0.0, ""autoestima"": 0.8
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = true
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000026"),
                    Name = "Extra Cardio y Resistencia Gym",
                    Comments = "Rutina de gimnasio combinando máquinas de cardio y ejercicios de resistencia muscular total.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.8, ""masa_muscular"": 0.2, ""definicion_muscular"": 0.7, ""fuerza"": 0.3,
                        ""resistencia_fisica"": 1.0, ""tonificacion"": 0.7, ""movilidad"": 0.1, ""postura"": 0.1,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 1.0, ""anti_estres"": 0.3, ""energia"": 0.7,
                        ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.2, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.1, ""hiit"": 0.8, ""velocidad_agilidad"": 0.3,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.2, ""intermedio"": 1.0, ""avanzado"": 0.5,
                        ""rutina_corta"": 0.2, ""rutina_larga"": 1.0, ""autoestima"": 0.6
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000027"),
                    Name = "Extra Definición Masculina",
                    Comments = "Rutina para gimnasio, enfoque en definición muscular y baja de porcentaje graso.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.8, ""masa_muscular"": 0.4, ""definicion_muscular"": 1.0, ""fuerza"": 0.4,
                        ""resistencia_fisica"": 0.4, ""tonificacion"": 0.8, ""movilidad"": 0.1, ""postura"": 0.1,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.5, ""anti_estres"": 0.2, ""energia"": 0.5,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.1, ""hiit"": 0.6, ""velocidad_agilidad"": 0.2,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 1.0,
                        ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.9
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000028"),
                    Name = "Extra Adaptada Rehabilitación",
                    Comments = "Rutina para recuperación funcional, movilidad y fuerza básica. Ideal para post-lesión o personas con baja movilidad.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.0, ""masa_muscular"": 0.1, ""definicion_muscular"": 0.0, ""fuerza"": 0.1,
                        ""resistencia_fisica"": 0.2, ""tonificacion"": 0.2, ""movilidad"": 1.0, ""postura"": 0.7,
                        ""rehabilitacion"": 1.0, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.6, ""energia"": 0.2,
                        ""sueño"": 0.3, ""adulto_mayor"": 0.9, ""enfermedades_cronicas"": 0.5, ""entrenamiento_funcional"": 0.4,
                        ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                        ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 0.0, ""avanzado"": 0.0,
                        ""rutina_corta"": 1.0, ""rutina_larga"": 0.0, ""autoestima"": 0.6
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000029"),
                    Name = "Extra Circuito Funcional Pareja",
                    Comments = "Entrenamiento en pareja, ideal para motivarse y trabajar fuerza, cardio y coordinación juntos.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.6, ""masa_muscular"": 0.5, ""definicion_muscular"": 0.5, ""fuerza"": 0.5,
                        ""resistencia_fisica"": 0.7, ""tonificacion"": 0.6, ""movilidad"": 0.5, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.6, ""anti_estres"": 0.9, ""energia"": 0.7,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 1.0,
                        ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.0, ""hiit"": 0.5, ""velocidad_agilidad"": 0.4,
                        ""entrenamiento_pareja"": 1.0, ""principiante"": 0.5, ""intermedio"": 0.8, ""avanzado"": 0.5,
                        ""rutina_corta"": 0.5, ""rutina_larga"": 0.3, ""autoestima"": 0.9
                    }",
                    TagsMachines = null,
                    IsBodyweight = true,
                    RequiresEquipment = false,
                    IsCalisthenic = false
                },
                new RoutineTemplate
                {
                    Id = Guid.Parse("A1111111-0001-4000-8000-000000000030"),
                    Name = "Extra Resistencia Funcional Deportiva",
                    Comments = "Rutina funcional pensada para mejorar la resistencia y preparación para deportes de equipo.",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDefault = false,
                    TagsObjectives = @"{
                        ""perdida_peso"": 0.4, ""masa_muscular"": 0.4, ""definicion_muscular"": 0.6, ""fuerza"": 0.6,
                        ""resistencia_fisica"": 1.0, ""tonificacion"": 0.4, ""movilidad"": 0.5, ""postura"": 0.2,
                        ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.8, ""anti_estres"": 0.2, ""energia"": 0.8,
                        ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 1.0,
                        ""deportes_especificos"": 1.0, ""pruebas_fisicas"": 0.6, ""hiit"": 0.7, ""velocidad_agilidad"": 0.9,
                        ""entrenamiento_pareja"": 0.3, ""principiante"": 0.0, ""intermedio"": 0.9, ""avanzado"": 0.7,
                        ""rutina_corta"": 0.1, ""rutina_larga"": 0.9, ""autoestima"": 0.7
                    }",
                    TagsMachines = null,
                    IsBodyweight = false,
                    RequiresEquipment = true,
                    IsCalisthenic = false
                },
                new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000031"),
                Name = "HIIT Cardio Express",
                Comments = "Rutina súper corta de HIIT sin equipamiento, perfecta para quemar grasa en poco tiempo.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 1.0, ""masa_muscular"": 0.2, ""definicion_muscular"": 0.9, ""fuerza"": 0.2,
                    ""resistencia_fisica"": 1.0, ""tonificacion"": 0.4, ""movilidad"": 0.2, ""postura"": 0.0,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 1.0, ""anti_estres"": 0.4, ""energia"": 0.9,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.4,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 1.0, ""velocidad_agilidad"": 0.5,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.3, ""intermedio"": 1.0, ""avanzado"": 0.7,
                    ""rutina_corta"": 1.0, ""rutina_larga"": 0.0, ""autoestima"": 0.7
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = true
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000032"),
                Name = "Espalda y Trapecio Fuerte",
                Comments = "Rutina avanzada para espalda, trapecio y fuerza total con pesas.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.2, ""masa_muscular"": 0.8, ""definicion_muscular"": 0.7, ""fuerza"": 1.0,
                    ""resistencia_fisica"": 0.3, ""tonificacion"": 0.3, ""movilidad"": 0.1, ""postura"": 0.3,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.1, ""anti_estres"": 0.1, ""energia"": 0.4,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                    ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.3, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.7, ""avanzado"": 1.0,
                    ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.6
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000033"),
                Name = "Tonificación Total en Casa",
                Comments = "Rutina para tonificar todo el cuerpo sin equipo, ideal para rutinas en casa y para todos los niveles.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.7, ""masa_muscular"": 0.4, ""definicion_muscular"": 0.7, ""fuerza"": 0.2,
                    ""resistencia_fisica"": 0.7, ""tonificacion"": 1.0, ""movilidad"": 0.3, ""postura"": 0.1,
                    ""rehabilitacion"": 0.1, ""salud_cardiovascular"": 0.4, ""anti_estres"": 0.4, ""energia"": 0.4,
                    ""sueño"": 0.1, ""adulto_mayor"": 0.2, ""enfermedades_cronicas"": 0.2, ""entrenamiento_funcional"": 0.4,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.2, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.7, ""intermedio"": 1.0, ""avanzado"": 0.3,
                    ""rutina_corta"": 0.4, ""rutina_larga"": 0.5, ""autoestima"": 1.0
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = true
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000034"),
                Name = "Potencia Piernas y Glúteo",
                Comments = "Enfoque en fuerza explosiva y volumen para tren inferior, usando barras y mancuernas.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.3, ""masa_muscular"": 0.8, ""definicion_muscular"": 0.6, ""fuerza"": 0.9,
                    ""resistencia_fisica"": 0.5, ""tonificacion"": 0.4, ""movilidad"": 0.2, ""postura"": 0.2,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.2, ""energia"": 0.6,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.3,
                    ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.2, ""hiit"": 0.1, ""velocidad_agilidad"": 0.3,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 1.0,
                    ""rutina_corta"": 0.2, ""rutina_larga"": 0.8, ""autoestima"": 0.7
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000035"),
                Name = "Core & Flexibilidad Express",
                Comments = "Entrenamiento corto para fortalecer abdomen y mejorar la flexibilidad general.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.2, ""masa_muscular"": 0.1, ""definicion_muscular"": 0.5, ""fuerza"": 0.1,
                    ""resistencia_fisica"": 0.3, ""tonificacion"": 0.6, ""movilidad"": 1.0, ""postura"": 0.7,
                    ""rehabilitacion"": 0.3, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.7, ""energia"": 0.3,
                    ""sueño"": 0.2, ""adulto_mayor"": 0.4, ""enfermedades_cronicas"": 0.2, ""entrenamiento_funcional"": 0.3,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 0.8, ""avanzado"": 0.4,
                    ""rutina_corta"": 1.0, ""rutina_larga"": 0.0, ""autoestima"": 0.8
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = true
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000036"),
                Name = "Principiantes Gym Básico",
                Comments = "Rutina de iniciación al gimnasio, ejercicios sencillos y seguros con equipamiento básico.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.4, ""masa_muscular"": 0.5, ""definicion_muscular"": 0.3, ""fuerza"": 0.4,
                    ""resistencia_fisica"": 0.4, ""tonificacion"": 0.8, ""movilidad"": 0.2, ""postura"": 0.2,
                    ""rehabilitacion"": 0.1, ""salud_cardiovascular"": 0.3, ""anti_estres"": 0.4, ""energia"": 0.5,
                    ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.1, ""entrenamiento_funcional"": 0.3,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.1, ""hiit"": 0.1, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 0.0, ""avanzado"": 0.0,
                    ""rutina_corta"": 0.5, ""rutina_larga"": 0.5, ""autoestima"": 0.9
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000037"),
                Name = "Extra Potencia y Agilidad",
                Comments = "Entrenamiento funcional de potencia, salto y trabajo de agilidad, ideal para deportes de velocidad.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.3, ""masa_muscular"": 0.3, ""definicion_muscular"": 0.3, ""fuerza"": 0.7,
                    ""resistencia_fisica"": 0.5, ""tonificacion"": 0.3, ""movilidad"": 0.5, ""postura"": 0.1,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.4, ""anti_estres"": 0.3, ""energia"": 0.7,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 1.0,
                    ""deportes_especificos"": 0.7, ""pruebas_fisicas"": 0.4, ""hiit"": 0.3, ""velocidad_agilidad"": 1.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.8, ""avanzado"": 0.7,
                    ""rutina_corta"": 0.3, ""rutina_larga"": 0.6, ""autoestima"": 0.7
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000038"),
                Name = "Extra Anti-Estrés Yoga",
                Comments = "Rutina suave tipo yoga y movilidad para reducir estrés y mejorar sueño.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.0, ""masa_muscular"": 0.0, ""definicion_muscular"": 0.0, ""fuerza"": 0.0,
                    ""resistencia_fisica"": 0.2, ""tonificacion"": 0.2, ""movilidad"": 0.9, ""postura"": 0.8,
                    ""rehabilitacion"": 0.4, ""salud_cardiovascular"": 0.3, ""anti_estres"": 1.0, ""energia"": 0.4,
                    ""sueño"": 1.0, ""adulto_mayor"": 0.6, ""enfermedades_cronicas"": 0.3, ""entrenamiento_funcional"": 0.2,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 1.0, ""avanzado"": 0.6,
                    ""rutina_corta"": 0.8, ""rutina_larga"": 0.4, ""autoestima"": 1.0
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000039"),
                Name = "Extra Full Body Gym Intermedio",
                Comments = "Cuerpo completo para intermedios en gimnasio, ideal para progresar fuerza y musculatura.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.5, ""masa_muscular"": 0.8, ""definicion_muscular"": 0.6, ""fuerza"": 0.8,
                    ""resistencia_fisica"": 0.6, ""tonificacion"": 0.6, ""movilidad"": 0.3, ""postura"": 0.2,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.3, ""anti_estres"": 0.2, ""energia"": 0.5,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.7,
                    ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.3, ""hiit"": 0.2, ""velocidad_agilidad"": 0.2,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 0.3,
                    ""rutina_corta"": 0.3, ""rutina_larga"": 0.7, ""autoestima"": 0.8
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0002-4000-8000-000000000040"),
                Name = "Extra Definición Avanzada Gym",
                Comments = "Rutina avanzada para secar y definir usando pesas, cardio y entrenamiento funcional.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.9, ""masa_muscular"": 0.5, ""definicion_muscular"": 1.0, ""fuerza"": 0.4,
                    ""resistencia_fisica"": 0.7, ""tonificacion"": 0.6, ""movilidad"": 0.2, ""postura"": 0.2,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.7, ""anti_estres"": 0.1, ""energia"": 0.5,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.4,
                    ""deportes_especificos"": 0.2, ""pruebas_fisicas"": 0.2, ""hiit"": 0.6, ""velocidad_agilidad"": 0.3,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.5, ""avanzado"": 1.0,
                    ""rutina_corta"": 0.2, ""rutina_larga"": 0.8, ""autoestima"": 1.0
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000041"),
                Name = "Full Body Funcional Avanzado",
                Comments = "Entrenamiento funcional de cuerpo completo con enfoque atlético, ideal para usuarios avanzados.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.6, ""masa_muscular"": 0.8, ""definicion_muscular"": 0.7, ""fuerza"": 0.9,
                    ""resistencia_fisica"": 0.8, ""tonificacion"": 0.7, ""movilidad"": 0.5, ""postura"": 0.3,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.5, ""anti_estres"": 0.2, ""energia"": 0.6,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 1.0,
                    ""deportes_especificos"": 0.5, ""pruebas_fisicas"": 0.6, ""hiit"": 0.6, ""velocidad_agilidad"": 0.7,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.5, ""avanzado"": 1.0,
                    ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.8
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000042"),
                Name = "Piernas y Glúteos en Casa",
                Comments = "Rutina sin equipamiento para fortalecer y tonificar piernas y glúteos, ideal para casa.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.7, ""masa_muscular"": 0.4, ""definicion_muscular"": 0.8, ""fuerza"": 0.3,
                    ""resistencia_fisica"": 0.8, ""tonificacion"": 0.9, ""movilidad"": 0.3, ""postura"": 0.2,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.5, ""anti_estres"": 0.4, ""energia"": 0.3,
                    ""sueño"": 0.1, ""adulto_mayor"": 0.2, ""enfermedades_cronicas"": 0.2, ""entrenamiento_funcional"": 0.4,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.3, ""velocidad_agilidad"": 0.1,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.7, ""intermedio"": 1.0, ""avanzado"": 0.3,
                    ""rutina_corta"": 0.6, ""rutina_larga"": 0.3, ""autoestima"": 1.0
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = true
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000043"),
                Name = "Espalda Saludable y Core",
                Comments = "Rutina especializada en fortalecer la zona lumbar, espalda y core para una mejor postura.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.2, ""masa_muscular"": 0.3, ""definicion_muscular"": 0.4, ""fuerza"": 0.4,
                    ""resistencia_fisica"": 0.4, ""tonificacion"": 0.7, ""movilidad"": 0.5, ""postura"": 1.0,
                    ""rehabilitacion"": 0.8, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.5, ""energia"": 0.3,
                    ""sueño"": 0.2, ""adulto_mayor"": 0.4, ""enfermedades_cronicas"": 0.4, ""entrenamiento_funcional"": 0.6,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.1, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.8, ""intermedio"": 1.0, ""avanzado"": 0.2,
                    ""rutina_corta"": 0.7, ""rutina_larga"": 0.2, ""autoestima"": 0.8
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000044"),
                Name = "Tren Superior Hipertrofia",
                Comments = "Rutina de gimnasio enfocada en hipertrofia de pecho, espalda y brazos.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.2, ""masa_muscular"": 1.0, ""definicion_muscular"": 0.8, ""fuerza"": 0.7,
                    ""resistencia_fisica"": 0.3, ""tonificacion"": 0.4, ""movilidad"": 0.1, ""postura"": 0.1,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.0, ""anti_estres"": 0.2, ""energia"": 0.5,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.3,
                    ""deportes_especificos"": 0.1, ""pruebas_fisicas"": 0.1, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.9, ""avanzado"": 1.0,
                    ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.7
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000045"),
                Name = "Movilidad y Alivio de Estrés",
                Comments = "Rutina enfocada en movilidad y relajación, perfecta para días de descanso o recuperación.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.0, ""masa_muscular"": 0.0, ""definicion_muscular"": 0.0, ""fuerza"": 0.0,
                    ""resistencia_fisica"": 0.2, ""tonificacion"": 0.2, ""movilidad"": 1.0, ""postura"": 0.8,
                    ""rehabilitacion"": 0.6, ""salud_cardiovascular"": 0.2, ""anti_estres"": 1.0, ""energia"": 0.4,
                    ""sueño"": 0.8, ""adulto_mayor"": 0.7, ""enfermedades_cronicas"": 0.3, ""entrenamiento_funcional"": 0.2,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 1.0, ""intermedio"": 0.7, ""avanzado"": 0.3,
                    ""rutina_corta"": 1.0, ""rutina_larga"": 0.2, ""autoestima"": 1.0
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000046"),
                Name = "Brazo y Hombro Estético",
                Comments = "Rutina avanzada de gimnasio para esculpir brazos y hombros con máxima definición.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.1, ""masa_muscular"": 0.9, ""definicion_muscular"": 1.0, ""fuerza"": 0.6,
                    ""resistencia_fisica"": 0.3, ""tonificacion"": 0.8, ""movilidad"": 0.1, ""postura"": 0.2,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.0, ""anti_estres"": 0.2, ""energia"": 0.3,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.2,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.0, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.7, ""avanzado"": 1.0,
                    ""rutina_corta"": 0.2, ""rutina_larga"": 1.0, ""autoestima"": 1.0
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000047"),
                Name = "Entrenamiento Militar Básico",
                Comments = "Rutina tipo bootcamp, ideal para preparar pruebas físicas o mejorar condición general.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.7, ""masa_muscular"": 0.5, ""definicion_muscular"": 0.6, ""fuerza"": 0.7,
                    ""resistencia_fisica"": 1.0, ""tonificacion"": 0.5, ""movilidad"": 0.3, ""postura"": 0.2,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.7, ""anti_estres"": 0.2, ""energia"": 0.7,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 1.0,
                    ""deportes_especificos"": 0.6, ""pruebas_fisicas"": 1.0, ""hiit"": 0.6, ""velocidad_agilidad"": 0.6,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 1.0, ""avanzado"": 0.7,
                    ""rutina_corta"": 0.2, ""rutina_larga"": 0.8, ""autoestima"": 0.7
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = true
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000048"),
                Name = "Glúteo y Pierna Funcional",
                Comments = "Rutina funcional para esculpir pierna y glúteos, ideal para combinar con otras rutinas.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.5, ""masa_muscular"": 0.6, ""definicion_muscular"": 0.8, ""fuerza"": 0.4,
                    ""resistencia_fisica"": 0.6, ""tonificacion"": 1.0, ""movilidad"": 0.4, ""postura"": 0.2,
                    ""rehabilitacion"": 0.1, ""salud_cardiovascular"": 0.3, ""anti_estres"": 0.3, ""energia"": 0.5,
                    ""sueño"": 0.1, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 1.0,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.2, ""hiit"": 0.2, ""velocidad_agilidad"": 0.0,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.2, ""intermedio"": 0.8, ""avanzado"": 0.6,
                    ""rutina_corta"": 0.6, ""rutina_larga"": 0.4, ""autoestima"": 1.0
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = true
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000049"),
                Name = "Rutina Cardio Larga",
                Comments = "Entrenamiento cardiovascular de larga duración, ideal para mejorar resistencia y perder peso.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 1.0, ""masa_muscular"": 0.2, ""definicion_muscular"": 0.8, ""fuerza"": 0.1,
                    ""resistencia_fisica"": 1.0, ""tonificacion"": 0.4, ""movilidad"": 0.2, ""postura"": 0.1,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 1.0, ""anti_estres"": 0.4, ""energia"": 0.9,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.1, ""entrenamiento_funcional"": 0.3,
                    ""deportes_especificos"": 0.0, ""pruebas_fisicas"": 0.0, ""hiit"": 0.8, ""velocidad_agilidad"": 0.2,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.1, ""intermedio"": 0.9, ""avanzado"": 0.7,
                    ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.6
                }",
                TagsMachines = null,
                IsBodyweight = true,
                RequiresEquipment = false,
                IsCalisthenic = false
            },
            new RoutineTemplate
            {
                Id = Guid.Parse("A1111111-0003-4000-8000-000000000050"),
                Name = "Full Power: Avanzados Gym",
                Comments = "Rutina de fuerza máxima y potencia, ideal para usuarios experimentados con equipamiento completo.",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                TagsObjectives = @"{
                    ""perdida_peso"": 0.3, ""masa_muscular"": 1.0, ""definicion_muscular"": 0.8, ""fuerza"": 1.0,
                    ""resistencia_fisica"": 0.4, ""tonificacion"": 0.7, ""movilidad"": 0.2, ""postura"": 0.2,
                    ""rehabilitacion"": 0.0, ""salud_cardiovascular"": 0.2, ""anti_estres"": 0.1, ""energia"": 0.7,
                    ""sueño"": 0.0, ""adulto_mayor"": 0.0, ""enfermedades_cronicas"": 0.0, ""entrenamiento_funcional"": 0.6,
                    ""deportes_especificos"": 0.5, ""pruebas_fisicas"": 0.7, ""hiit"": 0.1, ""velocidad_agilidad"": 0.3,
                    ""entrenamiento_pareja"": 0.0, ""principiante"": 0.0, ""intermedio"": 0.5, ""avanzado"": 1.0,
                    ""rutina_corta"": 0.0, ""rutina_larga"": 1.0, ""autoestima"": 0.8
                }",
                TagsMachines = null,
                IsBodyweight = false,
                RequiresEquipment = true,
                IsCalisthenic = false
            }
            };

            context.RoutineTemplates.AddRange(routines);
            await context.SaveChangesAsync();
        }
    }
}