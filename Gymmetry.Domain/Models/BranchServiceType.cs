using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class BranchServiceType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<BranchService> BranchServices { get; set; } = new List<BranchService>();
}
