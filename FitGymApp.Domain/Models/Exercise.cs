using System;
using System.Collections.Generic;

namespace FitGymApp.Domain.Models;

public partial class Exercise
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; } // Nueva propiedad

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid CategoryExerciseId { get; set; }

    public string? TagsObjectives { get; set; }

    public bool RequiresEquipment { get; set; }

    public string? UrlImage { get; set; }
    public Guid? MachineId { get; set; }

    public virtual CategoryExercise CategoryExercise { get; set; } = null!;

    public virtual ICollection<DailyExercise> DailyExercises { get; set; } = new List<DailyExercise>();

    public virtual ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();

    public virtual Machine? Machine { get; set; } // Relación uno a muchos, Machine puede ser null
}
