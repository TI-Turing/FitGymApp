using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class RoutineTemplate
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid? GymId { get; set; }

    public Guid? RoutineUserRoutineId { get; set; }

    public Guid? RoutineAssignedId { get; set; }

    public bool IsDefault { get; set; }

    public string? TagsObjectives { get; set; }

    public string? TagsMachines { get; set; }

    public bool IsBodyweight { get; set; }

    public bool RequiresEquipment { get; set; }

    public bool IsCalisthenic { get; set; }

    public virtual Gym Gym { get; set; } = null!;

    public virtual RoutineAssigned RoutineAssigned { get; set; } = null!;

    public virtual ICollection<RoutineDay> RoutineDays { get; set; } = new List<RoutineDay>();

    public virtual ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();

    public virtual User RoutineUserRoutine { get; set; } = null!;
}
