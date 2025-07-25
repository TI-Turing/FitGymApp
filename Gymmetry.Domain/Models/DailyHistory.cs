using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class DailyHistory
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

    public Guid BranchId { get; set; }

    public Guid RoutineExerciseId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<DailyExerciseHistory> DailyExerciseHistories { get; set; } = new List<DailyExerciseHistory>();

    public virtual RoutineExercise RoutineExercise { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
