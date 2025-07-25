using FitGymApp.Domain.Models;

public static class ExerciseSeed
{
    public static async Task SeedAsync(FitGymAppContext context)
    {
        // Nueva relación de categorías según el mapeo proporcionado
        // 642FC19F-500F-47AE-A81B-1303AC978D9D   Estiramiento
        // D9507CD0-1EDA-4D4D-A408-13FF76C14D88   Cardio
        // 9F9F94D0-7CD1-48E9-81A7-86AA503CA685   Aislado (focalizado)
        // 6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A   Funcional
        // E779339F-36BB-4EF8-9135-CF36BE4C4B07   Calentamiento
        // BC9D888F-4612-4BBB-ABEC-FF1EE76D129A   Ejercicio principal (compuesto)

        var exercises = new List<Exercise>
        {
            new Exercise {
                Name = "Press de banca",
                Description = "Ejercicio compuesto para el tren superior que fortalece principalmente el pectoral mayor, tríceps y deltoides anterior. Se realiza recostado en un banco empujando una barra hacia arriba.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.7, ""brazo"": 0.2, ""core"": 0.1, ""espalda"": 0.0, ""hombro"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Press inclinado con barra",
                Description = "Variante del press de banca para enfatizar la parte superior del pectoral y el deltoides anterior. Se realiza en banco inclinado con barra.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.7, ""hombro"": 0.2, ""brazo"": 0.1, ""espalda"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0, ""core"": 0.0}"
            },
            new Exercise {
                Name = "Press de banca declinado",
                Description = "Press de banca realizado en banco declinado, colocando el énfasis en la parte inferior del pectoral y el tríceps.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.8, ""brazo"": 0.1, ""core"": 0.1, ""espalda"": 0.0, ""hombro"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Press de banca con mancuernas",
                Description = "Variante del press de banca utilizando mancuernas. Permite mayor rango de movimiento y activa más músculos estabilizadores.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.7, ""brazo"": 0.2, ""core"": 0.1, ""espalda"": 0.0, ""hombro"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Press inclinado con mancuernas",
                Description = "Press de banca inclinado con mancuernas para trabajar la parte superior del pectoral, hombros y tríceps.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.7, ""brazo"": 0.2, ""hombro"": 0.1, ""espalda"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0, ""core"": 0.0}"
            },
            new Exercise {
                Name = "Flexiones de pecho",
                Description = "Ejercicio de calistenia por excelencia. Trabaja el pectoral mayor, tríceps y deltoides anterior usando el peso corporal.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.6, ""brazo"": 0.2, ""hombro"": 0.2, ""core"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Fondos en paralelas",
                Description = "Ejercicio de empuje para el tren superior, especialmente tríceps y pectorales. Puede realizarse en paralelas asistidas o libres.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""brazo"": 0.5, ""pecho"": 0.3, ""hombro"": 0.2, ""core"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Remo con barra",
                Description = "Remo bilateral con barra, excelente para desarrollar la espalda media y baja, así como la fuerza de agarre.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.7, ""brazo"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Remo con barra supino",
                Description = "Remo con barra con agarre supino, enfatiza la parte baja del dorsal y el bíceps.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.6, ""brazo"": 0.3, ""core"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Remo unilateral con mancuerna",
                Description = "Remo con mancuerna apoyado sobre banco, permite aislar y trabajar cada lado de la espalda de forma unilateral.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.7, ""brazo"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Remo invertido",
                Description = "Ejercicio de calistenia que fortalece la espalda, bíceps y core usando el propio peso corporal en una barra baja.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.5, ""brazo"": 0.3, ""core"": 0.1, ""hombro"": 0.1, ""pecho"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Remo en máquina",
                Description = "Remo sentado en máquina, ideal para aislar la espalda y controlar el movimiento, seguro para principiantes.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.7, ""brazo"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Jalón al pecho",
                Description = "Ejercicio en polea alta para desarrollar dorsales, parte superior de la espalda y bíceps.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.7, ""brazo"": 0.2, ""hombro"": 0.1, ""pecho"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0, ""core"": 0.0}"
            },
            new Exercise {
                Name = "Remo bajo en polea",
                Description = "Remo sentado en polea baja, permite trabajar el dorsal ancho y la musculatura media de la espalda.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.6, ""brazo"": 0.3, ""core"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Remo con barra T",
                Description = "Remo con barra en T, excelente para el grosor de la espalda y el desarrollo de la fuerza.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""espalda"": 0.7, ""brazo"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""pierna"": 0.0, ""gluteo"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Sentadilla frontal con barra",
                Description = "Variante de sentadilla con la barra situada sobre la parte anterior de los hombros, enfatizando más los cuádriceps y el core.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.5, ""core"": 0.2, ""gluteo"": 0.2, ""espalda"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""brazo"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Sentadilla búlgara",
                Description = "Sentadilla unilateral con una pierna apoyada hacia atrás, ideal para fuerza, equilibrio y glúteos.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.6, ""gluteo"": 0.3, ""core"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Zancadas con barra",
                Description = "Desplantes alternos hacia adelante con barra sobre la espalda, excelente para piernas, glúteos y core.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.6, ""gluteo"": 0.2, ""core"": 0.2, ""pecho"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""abdomen"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Zancada caminando",
                Description = "Variación de zancadas en la que se avanza dando pasos largos, ideal para mejorar la estabilidad y la fuerza en piernas y glúteos.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.5, ""gluteo"": 0.3, ""core"": 0.2, ""abdomen"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Desplante con barra",
                Description = "Desplante estático o alternado sosteniendo una barra sobre la espalda, enfocado en trabajar piernas y glúteos.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.5, ""gluteo"": 0.3, ""core"": 0.2, ""abdomen"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Dominadas",
                Description = "Ejercicio de tracción vertical que desarrolla la espalda, bíceps y core usando el peso corporal suspendido en barra fija.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.5, ""brazo"": 0.3, ""core"": 0.1, ""hombro"": 0.1, ""pecho"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Dominadas con lastre",
                Description = "Variante avanzada de dominadas agregando peso extra, ideal para progresar en fuerza y masa muscular.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.5, ""brazo"": 0.3, ""core"": 0.1, ""hombro"": 0.1, ""pecho"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Clean & Press",
                Description = "Ejercicio olímpico compuesto que combina cargada y press, trabajando todo el cuerpo y mejorando fuerza y coordinación.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.3, ""espalda"": 0.2, ""hombro"": 0.2, ""core"": 0.1, ""brazo"": 0.1, ""pecho"": 0.1, ""gluteo"": 0.1, ""trapecio"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Thrusters",
                Description = "Sentadilla frontal seguida de press de hombros, movimiento funcional y metabólico, ideal para fuerza y resistencia.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.3, ""hombro"": 0.2, ""core"": 0.2, ""espalda"": 0.1, ""gluteo"": 0.1, ""pecho"": 0.1, ""brazo"": 0.1, ""trapecio"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Peso muerto",
                Description = "Levantamiento de peso desde el suelo. Trabaja toda la cadena posterior, especialmente glúteos, espalda baja, isquiotibiales y core.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""espalda"": 0.6, ""pierna"": 0.2, ""gluteo"": 0.2, ""pecho"": 0.0, ""brazo"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0, ""core"": 0.0, ""hombro"": 0.0}"
            },
            new Exercise {
                Name = "Peso muerto sumo",
                Description = "Variante de peso muerto con las piernas más separadas y pies girados, mayor énfasis en glúteos y aductores.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.4, ""gluteo"": 0.3, ""espalda"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""brazo"": 0.0, ""trapecio"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Peso muerto rumano",
                Description = "Peso muerto con piernas semi-extendidas, ideal para isquiotibiales y glúteos, manteniendo la espalda recta durante el movimiento.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.4, ""gluteo"": 0.3, ""espalda"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""hombro"": 0.0, ""brazo"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Press militar con barra",
                Description = "Press de hombros de pie con barra. Desarrolla fuerza y masa muscular en deltoides, tríceps y core.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""hombro"": 0.5, ""brazo"": 0.2, ""core"": 0.1, ""pecho"": 0.1, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.1, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Press de hombros con mancuernas sentado",
                Description = "Press de hombros sentado para fortalecer deltoides y tríceps, con mayor rango de movimiento y estabilidad.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""hombro"": 0.6, ""brazo"": 0.2, ""core"": 0.1, ""pecho"": 0.1, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },

            // === AISLADOS (FOCALIZADOS) ===
            new Exercise {
                Name = "Curl con barra",
                Description = "Ejercicio clásico de aislamiento de bíceps, se realiza de pie flexionando los brazos mientras se sostiene una barra.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.7, ""hombro"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Curl martillo con mancuernas",
                Description = "Variante de curl de bíceps con agarre neutro para trabajar el braquiorradial y bíceps.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.8, ""core"": 0.1, ""hombro"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Curl de bíceps concentrado",
                Description = "Curl de bíceps sentado, apoyando el brazo en el muslo para aislar aún más el trabajo en el bíceps.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.9, ""core"": 0.1, ""hombro"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Curl de bíceps en banco inclinado",
                Description = "Variante de curl de bíceps en banco inclinado, favorece el estiramiento completo del bíceps.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.9, ""core"": 0.1, ""hombro"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Curl predicador con barra",
                Description = "Curl de bíceps en banco predicador, ideal para aislar el bíceps y reducir el impulso.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.9, ""core"": 0.1, ""hombro"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Patada de tríceps",
                Description = "Extensión de tríceps con mancuerna, se realiza inclinado hacia adelante y extendiendo el codo.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.8, ""core"": 0.1, ""hombro"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Extensión de tríceps en cuerda",
                Description = "Extensión de tríceps en polea alta con cuerda, enfatiza la cabeza lateral del tríceps.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.9, ""hombro"": 0.1, ""core"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Extensión de tríceps en máquina",
                Description = "Trabajo de tríceps en máquina, de forma controlada y segura.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.9, ""hombro"": 0.1, ""core"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Fondos de tríceps en banco",
                Description = "Ejercicio de tríceps usando el peso corporal, apoyando las manos en un banco y ejecutando una flexo-extensión de codo.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.8, ""hombro"": 0.2, ""core"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Elevaciones laterales",
                Description = "Aislamiento del deltoides lateral con mancuernas, ideal para dar forma redondeada al hombro.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""hombro"": 0.7, ""trapecio"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0}"
            },
            new Exercise {
                Name = "Elevaciones frontales de hombro",
                Description = "Elevar mancuernas al frente para aislar el deltoides anterior.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""hombro"": 0.7, ""core"": 0.1, ""trapecio"": 0.1, ""brazo"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Elevación lateral acostado",
                Description = "Aislamiento del deltoides lateral tumbado de lado, para activar aún más fibras musculares.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""hombro"": 0.9, ""core"": 0.1, ""brazo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Face pull en polea",
                Description = "Ejercicio en polea para fortalecer la parte posterior del hombro y el trapecio, mejorando la postura.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""hombro"": 0.5, ""espalda"": 0.2, ""trapecio"": 0.2, ""core"": 0.1, ""brazo"": 0.0, ""pecho"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Encogimiento de hombros con barra",
                Description = "Aislamiento de trapecio con barra, se realiza de pie elevando los hombros.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""trapecio"": 0.7, ""hombro"": 0.2, ""brazo"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""core"": 0.0}"
            },
            new Exercise {
                Name = "Abducción de hombro en polea baja",
                Description = "Aislamiento de deltoides mediante polea baja, ideal para activación lateral del hombro.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""hombro"": 0.8, ""core"": 0.1, ""brazo"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Extensión de muñeca",
                Description = "Ejercicio para fortalecer el antebrazo, trabajando extensores de muñeca con barra o mancuernas.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""brazo"": 0.9, ""core"": 0.1, ""hombro"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Extensión de cuádriceps en máquina",
                Description = "Aislamiento de cuádriceps mediante extensión de piernas en máquina.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""pierna"": 0.9, ""core"": 0.1, ""gluteo"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0, ""brazo"": 0.0}"
            },
            new Exercise {
                Name = "Extensión de cuádriceps unilateral",
                Description = "Aislamiento de cada cuádriceps por separado, ideal para corregir desbalances musculares.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""pierna"": 0.9, ""core"": 0.1, ""gluteo"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Curl femoral en máquina",
                Description = "Aislamiento de isquiotibiales mediante flexión de rodilla en máquina.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""pierna"": 0.8, ""gluteo"": 0.2, ""core"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Curl femoral tumbado",
                Description = "Aislamiento de isquiotibiales en máquina tumbado, para máxima contracción muscular.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""pierna"": 0.9, ""gluteo"": 0.1, ""core"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Abducción de cadera en máquina",
                Description = "Aislamiento de glúteo medio y menor, usando máquina de abducción de piernas.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""gluteo"": 0.8, ""pierna"": 0.2, ""core"": 0.0, ""abdomen"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""espalda"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Elevaciones de talón sentado",
                Description = "Aislamiento de pantorrillas (gemelos) mediante elevación de talones en máquina sentado.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""pierna"": 0.9, ""gluteo"": 0.1, ""core"": 0.0, ""abdomen"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            // ------------------ Funcional -------------------------
            new Exercise {
                Name = "Caminadora (trote ligero)",
                Description = "Ejercicio cardiovascular realizado en cinta, ideal para mejorar la capacidad aeróbica, quemar grasa y fortalecer las piernas.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""pierna"": 0.4, ""core"": 0.3, ""abdomen"": 0.2, ""gluteo"": 0.1, ""espalda"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Bicicleta estática",
                Description = "Ejercicio cardiovascular de bajo impacto para fortalecer piernas y glúteos y mejorar la resistencia aeróbica.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""pierna"": 0.6, ""core"": 0.2, ""gluteo"": 0.2, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Máquina elíptica",
                Description = "Ejercicio cardiovascular de bajo impacto que involucra todo el cuerpo, ideal para mejorar capacidad aeróbica y tonificar piernas y brazos.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""pierna"": 0.5, ""core"": 0.2, ""brazo"": 0.1, ""gluteo"": 0.2, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Saltar cuerda",
                Description = "Ejercicio cardiovascular intenso que mejora la coordinación, quema calorías y fortalece piernas y core.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""pierna"": 0.5, ""core"": 0.3, ""abdomen"": 0.1, ""gluteo"": 0.1, ""brazo"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "HIIT",
                Description = "Entrenamiento interválico de alta intensidad que combina ejercicios cardiovasculares y de fuerza, ideal para quemar grasa y mejorar la condición física.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""pierna"": 0.3, ""core"": 0.3, ""abdomen"": 0.2, ""gluteo"": 0.1, ""brazo"": 0.1, ""hombro"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Subir escaleras",
                Description = "Ejercicio cardiovascular y de fuerza que fortalece piernas y glúteos mediante el ascenso repetido de escalones.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""pierna"": 0.7, ""gluteo"": 0.2, ""core"": 0.1, ""abdomen"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Battle ropes",
                Description = "Ejercicio cardiovascular y de fuerza utilizando cuerdas gruesas, excelente para brazos, hombros, core y resistencia.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""brazo"": 0.4, ""core"": 0.2, ""hombro"": 0.2, ""pierna"": 0.1, ""gluteo"": 0.1, ""espalda"": 0.0, ""pecho"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Remo ergómetro",
                Description = "Ejercicio de cardio en máquina de remo, que integra tren superior, inferior y core, ideal para quemar calorías y mejorar resistencia.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""espalda"": 0.3, ""pierna"": 0.3, ""core"": 0.2, ""brazo"": 0.2, ""gluteo"": 0.1, ""abdomen"": 0.0, ""pecho"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Step touch",
                Description = "Paso lateral sencillo y rítmico, ideal para calentar y mejorar la coordinación y resistencia cardiovascular.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""pierna"": 0.5, ""core"": 0.2, ""abdomen"": 0.1, ""gluteo"": 0.1, ""brazo"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Shadow boxing",
                Description = "Simulación de combate de boxeo al aire, excelente para cardio, coordinación y agilidad de brazos y core.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""brazo"": 0.4, ""core"": 0.2, ""pierna"": 0.2, ""hombro"": 0.2, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },

            // === FUNCIONAL ===
            new Exercise {
                Name = "Kettlebell swing",
                Description = "Movimiento balístico para mejorar fuerza, potencia y resistencia de glúteos, piernas y core. Se realiza con pesa rusa.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""core"": 0.3, ""pierna"": 0.3, ""gluteo"": 0.2, ""hombro"": 0.2, ""pecho"": 0.0, ""espalda"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0, ""brazo"": 0.0}"
            },
            new Exercise {
                Name = "Wall ball",
                Description = "Lanzamiento de balón medicinal hacia una pared, combinando sentadilla y press, ideal para fuerza y resistencia metabólica.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""core"": 0.2, ""pierna"": 0.3, ""brazo"": 0.2, ""hombro"": 0.3, ""gluteo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""abdomen"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Box Jump",
                Description = "Salto explosivo sobre un cajón o plataforma estabilizando la caída. Mejora potencia y capacidad de reacción en piernas.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""pierna"": 0.5, ""core"": 0.2, ""gluteo"": 0.2, ""abdomen"": 0.1, ""hombro"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Wall Walk",
                Description = "Ejercicio de calistenia donde se sube y baja caminando con los pies por la pared desde una posición de plancha. Desafía hombros y core.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""core"": 0.3, ""hombro"": 0.3, ""brazo"": 0.2, ""pierna"": 0.1, ""abdomen"": 0.1, ""espalda"": 0.0, ""pecho"": 0.0, ""gluteo"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Turkish Get Up",
                Description = "Levantamiento turco con kettlebell, ejercicio funcional y completo para fuerza, movilidad y estabilidad de todo el cuerpo.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""core"": 0.3, ""pierna"": 0.2, ""hombro"": 0.2, ""brazo"": 0.2, ""gluteo"": 0.1, ""abdomen"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Bear Crawl",
                Description = "Desplazamiento a cuatro apoyos, excelente para fortalecer core, hombros y mejorar la coordinación.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""core"": 0.2, ""pierna"": 0.2, ""hombro"": 0.2, ""brazo"": 0.2, ""abdomen"": 0.1, ""gluteo"": 0.1, ""pecho"": 0.1, ""espalda"": 0.1, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Farmer Walk",
                Description = "Caminata cargando peso en cada mano, ideal para fortalecer agarre, core, espalda y trapecio.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""core"": 0.2, ""pierna"": 0.2, ""brazo"": 0.2, ""hombro"": 0.2, ""gluteo"": 0.1, ""abdomen"": 0.1, ""pecho"": 0.0, ""espalda"": 0.1, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Slam ball",
                Description = "Lanzamiento explosivo de balón medicinal al suelo, útil para trabajar potencia, core y brazos.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""core"": 0.2, ""hombro"": 0.2, ""brazo"": 0.2, ""pierna"": 0.2, ""abdomen"": 0.1, ""gluteo"": 0.1, ""pecho"": 0.1, ""espalda"": 0.1, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Lunge twist",
                Description = "Zancada con giro de torso, excelente para core, glúteos y piernas, además de trabajar estabilidad.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""pierna"": 0.4, ""core"": 0.3, ""gluteo"": 0.2, ""abdomen"": 0.1, ""hombro"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Plancha lateral con rotación",
                Description = "Plancha lateral sobre un antebrazo, rotando el torso. Trabaja oblicuos, core y estabilidad de hombro.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""core"": 0.4, ""abdomen"": 0.2, ""hombro"": 0.1, ""brazo"": 0.1, ""pierna"": 0.1, ""gluteo"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },

            // === CALENTAMIENTO ===
            new Exercise {
                Name = "Rotación de brazos",
                Description = "Movimiento circular de brazos extendidos para calentar y movilizar hombros y trapecio.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                TagsObjectives = @"{""hombro"": 0.5, ""brazo"": 0.3, ""trapecio"": 0.2, ""pecho"": 0.0, ""espalda"": 0.0, ""pierna"": 0.0, ""gluteo"": 0.0, ""core"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Jumping jacks",
                Description = "Salto abriendo y cerrando piernas y brazos. Ejercicio de calentamiento y cardio para todo el cuerpo.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                TagsObjectives = @"{""pierna"": 0.4, ""brazo"": 0.2, ""core"": 0.2, ""hombro"": 0.2, ""abdomen"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Rotación de cadera",
                Description = "Movimiento circular de caderas para calentar y mejorar movilidad en la articulación de la cadera.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                TagsObjectives = @"{""core"": 0.2, ""pierna"": 0.2, ""abdomen"": 0.2, ""gluteo"": 0.2, ""hombro"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.2, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Movilidad articular de tobillos",
                Description = "Ejercicios de movilidad para los tobillos, ideal para calentar y prevenir lesiones en actividades de impacto.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                TagsObjectives = @"{""pierna"": 0.5, ""core"": 0.1, ""abdomen"": 0.1, ""gluteo"": 0.1, ""hombro"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.1, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Skipping bajo",
                Description = "Trote elevando ligeramente las rodillas, útil para calentar y activar el tren inferior.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                TagsObjectives = @"{""pierna"": 0.4, ""core"": 0.2, ""abdomen"": 0.1, ""gluteo"": 0.1, ""hombro"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Jump rope lento",
                Description = "Salto de cuerda a baja intensidad, perfecto para calentar y mejorar la coordinación.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                TagsObjectives = @"{""pierna"": 0.4, ""core"": 0.2, ""abdomen"": 0.1, ""gluteo"": 0.1, ""hombro"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Movilidad escapular (bandas)",
                Description = "Movilizaciones con bandas elásticas para activar y calentar la cintura escapular y hombros.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                TagsObjectives = @"{""hombro"": 0.3, ""core"": 0.1, ""abdomen"": 0.1, ""gluteo"": 0.1, ""pierna"": 0.1, ""brazo"": 0.1, ""pecho"": 0.0, ""espalda"": 0.1, ""trapecio"": 0.2}"
            },
            new Exercise {
                Name = "Rotaciones de columna",
                Description = "Rotación controlada del tronco para mejorar movilidad y flexibilidad de la columna.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("E779339F-36BB-4EF8-9135-CF36BE4C4B07"),
                TagsObjectives = @"{""espalda"": 0.5, ""core"": 0.3, ""abdomen"": 0.1, ""gluteo"": 0.1, ""pierna"": 0.0, ""hombro"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""trapecio"": 0.0}"
            },

            // === ESTIRAMIENTO ===
            new Exercise {
                Name = "Estiramiento de cuádriceps",
                Description = "Estiramiento de la parte anterior del muslo, ideal para después de entrenar piernas.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""pierna"": 0.8, ""gluteo"": 0.1, ""core"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Estiramiento de hombros cruzado",
                Description = "Estiramiento estático llevando un brazo por delante del cuerpo y empujando con el otro, ideal para hombros y trapecio.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""hombro"": 0.6, ""brazo"": 0.3, ""trapecio"": 0.1, ""pierna"": 0.0, ""gluteo"": 0.0, ""core"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""abdomen"": 0.0}"
            },
            new Exercise {
                Name = "Estiramiento de psoas",
                Description = "Estiramiento profundo del flexor de cadera, muy útil tras entrenar piernas o correr.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""pierna"": 0.8, ""gluteo"": 0.1, ""core"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Estiramiento de glúteo piriforme",
                Description = "Estiramiento para aliviar tensión en glúteo mayor y piriforme, recomendado para evitar molestias lumbares.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""gluteo"": 0.8, ""pierna"": 0.1, ""core"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Estiramiento de cadena posterior",
                Description = "Estiramiento global del tren posterior: isquiotibiales, glúteos y espalda baja.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""pierna"": 0.5, ""espalda"": 0.2, ""gluteo"": 0.1, ""core"": 0.1, ""abdomen"": 0.1, ""hombro"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Estiramiento de tríceps",
                Description = "Estiramiento del tríceps llevando el codo por detrás de la cabeza y empujando suavemente con la otra mano.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""brazo"": 0.7, ""hombro"": 0.2, ""core"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""pecho"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Estiramiento de dorsal",
                Description = "Estiramiento de la espalda alta, ideal para después de entrenar dorsales y hombros.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""espalda"": 0.7, ""core"": 0.2, ""brazo"": 0.1, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Estiramiento de cuello lateral",
                Description = "Inclinación de la cabeza hacia un lado para estirar trapecio y cuello, útil para aliviar tensión cervical.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""trapecio"": 0.6, ""core"": 0.2, ""hombro"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""pecho"": 0.0, ""brazo"": 0.1}"
            },
            new Exercise {
                Name = "Estiramiento de aductores (mariposa)",
                Description = "Estiramiento de la parte interna de los muslos, ideal para mejorar la flexibilidad de la cadera.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""pierna"": 0.7, ""core"": 0.2, ""gluteo"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""hombro"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Postura del niño (yoga)",
                Description = "Postura de yoga que relaja la espalda, hombros y caderas; excelente para finalizar la rutina.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""espalda"": 0.4, ""core"": 0.2, ""gluteo"": 0.1, ""pierna"": 0.1, ""abdomen"": 0.1, ""hombro"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""trapecio"": 0.1}"
            },
            new Exercise {
                Name = "Estiramiento de pecho en pared",
                Description = "Estiramiento del pectoral mayor apoyando el brazo en la pared y girando el cuerpo.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("642FC19F-500F-47AE-A81B-1303AC978D9D"),
                TagsObjectives = @"{""pecho"": 0.8, ""core"": 0.1, ""brazo"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Crunch abdominal",
                Description = "Ejercicio básico para fortalecer el recto abdominal. Se realiza tumbado, flexionando el torso hacia las piernas.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""abdomen"": 0.7, ""core"": 0.2, ""gluteo"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""pierna"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Plancha abdominal",
                Description = "Ejercicio isométrico que fortalece el core y el abdomen, manteniendo el cuerpo recto y sostenido sobre antebrazos y puntas de pies.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""abdomen"": 0.6, ""core"": 0.3, ""gluteo"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""pierna"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Elevaciones de piernas colgado",
                Description = "Ejercicio avanzado de calistenia para el abdomen inferior. Se realiza colgado de una barra, elevando las piernas rectas.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""abdomen"": 0.8, ""core"": 0.2, ""gluteo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""pierna"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Mountain climbers",
                Description = "Ejercicio de calistenia y cardio. Desde posición de plancha, alternar rodillas al frente rápidamente, involucrando abdomen, core y piernas.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""abdomen"": 0.3, ""core"": 0.3, ""pierna"": 0.2, ""gluteo"": 0.1, ""pecho"": 0.1, ""brazo"": 0.0, ""espalda"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Burpees",
                Description = "Ejercicio global que combina sentadilla, flexión y salto. Mejora fuerza, resistencia y potencia en todo el cuerpo.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"),
                TagsObjectives = @"{""pierna"": 0.3, ""core"": 0.2, ""abdomen"": 0.2, ""brazo"": 0.1, ""pecho"": 0.1, ""gluteo"": 0.1, ""espalda"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },

            // === EJERCICIOS ADICIONALES MULTIPROPÓSITO (HOME Y GYM) ===
            new Exercise {
                Name = "Flexiones diamante",
                Description = "Variante de flexión donde las manos se colocan juntas formando un diamante. Mayor énfasis en tríceps y pectoral interno.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.4, ""brazo"": 0.3, ""hombro"": 0.2, ""core"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Sentadilla goblet",
                Description = "Sentadilla sosteniendo una mancuerna o kettlebell frente al pecho. Facilita la técnica y activa core y piernas.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.6, ""core"": 0.2, ""gluteo"": 0.2, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Desplante lateral",
                Description = "Zancada lateral que enfatiza abductores, glúteo medio y cuádriceps. Útil para movilidad y fuerza lateral.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("6C60B74C-F83A-4AF9-ABD3-BB929D9FAE6A"),
                TagsObjectives = @"{""pierna"": 0.4, ""gluteo"": 0.2, ""core"": 0.2, ""abdomen"": 0.1, ""hombro"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Superman",
                Description = "Ejercicio en el suelo para fortalecer la espalda baja, glúteos y hombros, imitando la postura de Superman volando.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""espalda"": 0.7, ""core"": 0.1, ""gluteo"": 0.2, ""pierna"": 0.0, ""abdomen"": 0.0, ""brazo"": 0.0, ""pecho"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Plancha lateral",
                Description = "Plancha sostenida de lado, apoyando un antebrazo y el lateral del pie. Trabaja oblicuos, core y glúteo medio.",
                RequiresEquipment = false,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""core"": 0.4, ""abdomen"": 0.3, ""gluteo"": 0.2, ""pierna"": 0.1, ""espalda"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Fondos de pecho en paralelas",
                Description = "Ejercicio en paralelas para pectoral mayor, tríceps y deltoides anterior. Puede hacerse en gimnasio o parque.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.4, ""brazo"": 0.3, ""hombro"": 0.2, ""core"": 0.1, ""abdomen"": 0.0, ""espalda"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },

            // === EJERCICIOS DE GIMNASIO ADICIONALES ===
            new Exercise {
                Name = "Press de piernas en máquina",
                Description = "Ejercicio para el desarrollo de fuerza y masa muscular en las piernas, especialmente cuádriceps y glúteos, realizado en máquina de press horizontal o inclinada.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.8, ""gluteo"": 0.2, ""core"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Curl femoral sentado en máquina",
                Description = "Aislamiento de isquiotibiales flexionando rodillas en máquina sentado.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""pierna"": 0.9, ""gluteo"": 0.1, ""core"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Prensa de piernas vertical",
                Description = "Variante de prensa de piernas donde el movimiento es vertical, enfatizando cuádriceps y glúteos.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pierna"": 0.7, ""gluteo"": 0.3, ""core"": 0.0, ""abdomen"": 0.0, ""espalda"": 0.0, ""pecho"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Gemelos de pie en máquina",
                Description = "Elevaciones de talón de pie en máquina, para fortalecer gemelos y sóleo.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"),
                TagsObjectives = @"{""pierna"": 0.9, ""gluteo"": 0.1, ""core"": 0.0, ""abdomen"": 0.0, ""pecho"": 0.0, ""espalda"": 0.0, ""brazo"": 0.0, ""hombro"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Aperturas con mancuernas",
                Description = "Ejercicio de aislamiento para el pectoral, se realiza acostado abriendo y cerrando los brazos con mancuernas.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.7, ""hombro"": 0.2, ""core"": 0.1, ""espalda"": 0.0, ""brazo"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Crossover en polea",
                Description = "Ejercicio de aislamiento para trabajar el pectoral mayor desde distintos ángulos usando poleas.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.7, ""brazo"": 0.1, ""core"": 0.2, ""espalda"": 0.0, ""hombro"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Press en máquina de pecho",
                Description = "Press horizontal en máquina para pectoral, facilita la ejecución y es ideal para principiantes.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""pecho"": 0.7, ""brazo"": 0.2, ""core"": 0.1, ""espalda"": 0.0, ""hombro"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise {
                Name = "Press Arnold",
                Description = "Variante de press de hombros con mancuernas, girando las palmas durante el movimiento. Trabaja deltoides y core.",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"),
                TagsObjectives = @"{""hombro"": 0.7, ""brazo"": 0.2, ""core"": 0.1, ""pecho"": 0.0, ""espalda"": 0.0, ""abdomen"": 0.0, ""gluteo"": 0.0, ""pierna"": 0.0, ""trapecio"": 0.0}"
            },
            new Exercise
            {
                Name = "Hip Thrust con barra",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("9F9F94D0-7CD1-48E9-81A7-86AA503CA685"), // Aislado (focalizado)
                TagsObjectives = "{\"gluteo\": 0.6, \"pierna\": 0.2, \"core\": 0.1, \"espalda\": 0.1, \"pecho\": 0.0, \"hombro\": 0.0, \"brazo\": 0.0, \"abdomen\": 0.0, \"trapecio\": 0.0}"
            },
            new Exercise
            {
                Name = "Peso muerto rumano con mancuernas",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("BC9D888F-4612-4BBB-ABEC-FF1EE76D129A"), // Ejercicio principal (compuesto)
                TagsObjectives = "{\"pierna\": 0.3, \"gluteo\": 0.4, \"espalda\": 0.2, \"core\": 0.1, \"pecho\": 0.0, \"hombro\": 0.0, \"brazo\": 0.0, \"abdomen\": 0.0, \"trapecio\": 0.0}"
            },
            new Exercise
            {
    
                Name = "Jump rope rápido",
                RequiresEquipment = true,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                CategoryExerciseId = Guid.Parse("D9507CD0-1EDA-4D4D-A408-13FF76C14D88"), // Cardio
                TagsObjectives = "{\"resistencia_fisica\": 0.3, \"salud_cardiovascular\": 0.4, \"pierna\": 0.2, \"coordinacion\": 0.1, \"gluteo\": 0.0, \"abdomen\": 0.0, \"brazo\": 0.0, \"hombro\": 0.0, \"core\": 0.0, \"espalda\": 0.0, \"trapecio\": 0.0, \"pecho\": 0.0}"
            }

        };

        // Asignar un Guid válido y único a cada ejercicio
        foreach (var ex in exercises)
        {
            ex.Id = Guid.NewGuid();
        }

        foreach (var ex in exercises)
        {
            if (!context.Exercises.Any(x => x.Name == ex.Name))
                context.Exercises.Add(ex);
        }
        await context.SaveChangesAsync();
    }
}