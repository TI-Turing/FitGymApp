using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class MachineCategory
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid MachineId { get; set; }
    public Guid MachineCategoryTypeId { get; set; }

    public virtual Machine Machine { get; set; } = null!;
    public virtual MachineCategoryType MachineCategoryType { get; set; } = null!;
}
