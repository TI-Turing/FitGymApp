using System;
using System.Collections.Generic;

namespace FitGymApp.Domain.Models;

public partial class Gym
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid CountryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid GymTypeId { get; set; }

    public virtual GymType GymType { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<GymPlanSelected> GymPlanSelecteds { get; set; } = new List<GymPlanSelected>();

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();

    public virtual ICollection<RoutineTemplate> RoutineTemplates { get; set; } = new List<RoutineTemplate>();

    public virtual ICollection<User> UserGyms { get; set; } = new List<User>();

    public virtual ICollection<User> UserUserGymAssigneds { get; set; } = new List<User>();
}
