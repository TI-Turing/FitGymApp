using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class SubModule
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid ModuleId { get; set; }

    public Guid BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<LogError> LogErrors { get; set; } = new List<LogError>();

    public virtual Module Module { get; set; } = null!;
}
