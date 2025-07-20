using System;
using System.Collections.Generic;

namespace FitGymApp.Domain.Models;

public partial class MachineCategoryType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<MachineCategory> MachineCategories { get; set; } = new List<MachineCategory>();
}