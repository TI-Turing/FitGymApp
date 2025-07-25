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

    public Guid GymId { get; set; }

    public Guid PlanTypeId { get; set; }

    public virtual Gym Gym { get; set; } = null!;

    public virtual PlanType PlanType { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual PaymentAttempt? PaymentAttempt { get; set; }
}
