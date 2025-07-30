using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Plan
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; } // FK to User

    public Guid PlanTypeId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual PlanType PlanType { get; set; } = null!;

    public virtual PaymentAttempt? PaymentAttempt { get; set; }
}
