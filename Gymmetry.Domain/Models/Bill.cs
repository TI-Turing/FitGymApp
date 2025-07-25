using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Bill
{
    public Guid Id { get; set; }

    public string Ammount { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserTypeId { get; set; }

    public Guid UserId { get; set; }

    public Guid UserSellerId { get; set; }

    public Guid GymId { get; set; }

    public virtual Gym Gym { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual User UserSeller { get; set; } = null!;

    public virtual UserType UserType { get; set; } = null!;
}
