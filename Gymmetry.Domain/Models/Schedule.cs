using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Schedule
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsHoliday { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
