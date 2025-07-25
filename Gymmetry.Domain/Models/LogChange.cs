using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class LogChange
{
    public Guid Id { get; set; }

    public string Table { get; set; } = null!;

    public string PastObject { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public string? InvocationId { get; set; }

    public virtual User User { get; set; } = null!;
}
