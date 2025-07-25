using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class RoutineAssigned
{
    public Guid Id { get; set; }

    public string? Comments { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<RoutineTemplate> RoutineTemplates { get; set; } = new List<RoutineTemplate>();

    public virtual User User { get; set; } = null!;
}
