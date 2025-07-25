using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Daily
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public Guid RoutineExerciseId { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<DailyExercise> DailyExercises { get; set; } = new List<DailyExercise>();

    public virtual RoutineExercise RoutineExercise { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
