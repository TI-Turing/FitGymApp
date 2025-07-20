using System;
using System.Collections.Generic;

namespace FitGymApp.Domain.Models;

public partial class GymPlanSelected
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid GymPlanSelectedTypeId { get; set; }

    public Guid? GymId { get; set; }

    public virtual ICollection<GymPlanSelectedModule> GymPlanSelectedModules { get; set; } = new List<GymPlanSelectedModule>();

    public virtual GymPlanSelectedType GymPlanSelectedType { get; set; } = null!;
    public virtual PaymentAttempt? PaymentAttempt { get; set; }
}
