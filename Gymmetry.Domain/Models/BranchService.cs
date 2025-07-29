using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class BranchService
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public Guid BranchServiceTypeId { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; }

    public virtual Branch Branch { get; set; } = null!;
    public virtual BranchServiceType BranchServiceType { get; set; } = null!;
}
