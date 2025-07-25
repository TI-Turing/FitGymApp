using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Module
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Url { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserTypeId { get; set; }

    public Guid GymPlanSelectedModuleModuleModuleId { get; set; }

    public virtual GymPlanSelectedModule GymPlanSelectedModuleModuleModule { get; set; } = null!;

    public virtual ICollection<SubModule> SubModules { get; set; } = new List<SubModule>();

    public virtual UserType UserType { get; set; } = null!;
}
