using System;

namespace Gymmetry.Domain.Models;

public partial class CurrentOccupancy
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public int Occupancy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; }

    public virtual Branch Branch { get; set; } = null!;
}
