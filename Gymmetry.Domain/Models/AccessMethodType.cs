using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class AccessMethodType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
