using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class DailyExercise
{
    public Guid Id { get; set; }

    public string Set { get; set; } = null!;

    public string Repetitions { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid DailyId { get; set; }

    public Guid ExerciseId { get; set; }

    public virtual Daily Daily { get; set; } = null!;

    public virtual Exercise Exercise { get; set; } = null!;
}
