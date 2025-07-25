using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class RoutineExercise
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public string Sets { get; set; } = null!;

    public string Repetitions { get; set; } = null!;

    public Guid RoutineTemplateId { get; set; }

    public Guid ExerciseId { get; set; }

    public virtual ICollection<Daily> Dailies { get; set; } = new List<Daily>();

    public virtual ICollection<DailyHistory> DailyHistories { get; set; } = new List<DailyHistory>();

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual RoutineTemplate RoutineTemplate { get; set; } = null!;
}
