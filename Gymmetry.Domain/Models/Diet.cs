using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Diet
{
    public Guid Id { get; set; }

    public string BreakFast { get; set; } = null!;

    public string MidMorning { get; set; } = null!;

    public string Lunch { get; set; } = null!;

    public string MidAfternoon { get; set; } = null!;

    public string Night { get; set; } = null!;

    public string MidNight { get; set; } = null!;

    public string? Observations { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
