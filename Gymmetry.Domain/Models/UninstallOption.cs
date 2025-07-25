using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class UninstallOption
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<LogUninstall> LogUninstalls { get; set; } = new List<LogUninstall>();
}
