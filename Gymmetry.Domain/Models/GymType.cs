using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class GymType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<Gym> Gyms { get; set; } = new List<Gym>();
}
