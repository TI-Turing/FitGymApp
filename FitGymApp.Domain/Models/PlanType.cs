using System;
using System.Collections.Generic;

namespace FitGymApp.Domain.Models;

public partial class PlanType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public decimal? Price { get; set; }

    public decimal? UsdPrice { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();
}
