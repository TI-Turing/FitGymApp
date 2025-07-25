using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class GymPlanSelectedModule
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid GymPlanSelectedId { get; set; }

    public virtual GymPlanSelected GymPlanSelected { get; set; } = null!;

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}
