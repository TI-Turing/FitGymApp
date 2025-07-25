using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class LogError
{
    public Guid Id { get; set; }

    public string Error { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public Guid SubModuleId { get; set; }

    public virtual SubModule SubModule { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
