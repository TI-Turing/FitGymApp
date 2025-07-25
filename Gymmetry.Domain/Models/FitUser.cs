using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class FitUser
{
    public Guid Id { get; set; }

    public string Goal { get; set; } = null!;

    public string ExperienceLevel { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
