using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Permission
{
    public Guid Id { get; set; }

    public string See { get; set; } = null!;

    public string Create { get; set; } = null!;

    public string Read { get; set; } = null!;

    public string Update { get; set; } = null!;

    public string Delete { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserTypeId { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual UserType UserType { get; set; } = null!;
}
