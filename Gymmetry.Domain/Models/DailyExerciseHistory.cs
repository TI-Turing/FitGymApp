using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class DailyExerciseHistory
{
    public Guid Id { get; set; }

    public string Set { get; set; } = null!;

    public string Repetitions { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid DailyHistoryId { get; set; }

    public virtual DailyHistory DailyHistory { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
