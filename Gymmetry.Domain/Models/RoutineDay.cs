using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class RoutineDay
{
    public Guid Id { get; set; }
    public int DayNumber { get; set; }
    public string Name { get; set; } = null!;
    public int Sets { get; set; }
    public string Repetitions { get; set; } = null!;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; }
    public Guid RoutineTemplateId { get; set; }
    public Guid? ExerciseId { get; set; } // Nueva FK
    public virtual RoutineTemplate RoutineTemplate { get; set; } = null!;
    public virtual Exercise? Exercise { get; set; } // Navegación
}