using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class LogLogin
{
    public Guid Id { get; set; }

    public bool IsSuccess { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
