using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Branch
{
    public Guid Id { get; set; }

    public string Address { get; set; } = null!;

    public Guid CityId { get; set; }

    public Guid RegionId { get; set; }

    public Guid GymId { get; set; }

    public Guid AccessMethodId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? OpeningHours { get; set; }
    public Guid? Manager_UserId { get; set; }
    public string? ManagerPhone { get; set; }
    public int? Capacity { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Notes { get; set; }
    public string? ParkingInfo { get; set; }
    public bool WifiAvailable { get; set; }

    public virtual AccessMethodType AccessMethod { get; set; } = null!;

    public virtual ICollection<DailyHistory> DailyHistories { get; set; } = new List<DailyHistory>();

    public virtual Gym Gym { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<SubModule> SubModules { get; set; } = new List<SubModule>();
}
