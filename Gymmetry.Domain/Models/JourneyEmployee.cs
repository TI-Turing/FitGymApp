using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class JourneyEmployee
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string StartHour { get; set; } = null!;

    public string EndHour { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid EmployeeUserId { get; set; }

    public virtual EmployeeUser EmployeeUser { get; set; } = null!;
}
