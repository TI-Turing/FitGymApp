using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Gym
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string? LogoUrl { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? SocialMediaLinks { get; set; }
    public string? LegalRepresentative { get; set; }
    public string? BillingEmail { get; set; }
    public Guid? SubscriptionPlanId { get; set; }
    public bool IsVerified { get; set; }
    public string? Tags { get; set; }
    public Guid? Owner_UserId { get; set; }
    public string? BrandColor { get; set; }
    public int? MaxBranchesAllowed { get; set; }
    public string? QrImageUrl { get; set; }
    public DateTime? TrialEndsAt { get; set; }
    public Guid CountryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; }
    public Guid? GymTypeId { get; set; }
    public virtual GymType GymType { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<GymPlanSelected> GymPlanSelecteds { get; set; } = new List<GymPlanSelected>();

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();

    public virtual ICollection<RoutineTemplate> RoutineTemplates { get; set; } = new List<RoutineTemplate>();

    public virtual ICollection<User> UserGyms { get; set; } = new List<User>();

    public virtual ICollection<User> UserUserGymAssigneds { get; set; } = new List<User>();

    public virtual ICollection<PaymentAttempt> PaymentAttempts { get; set; } = new List<PaymentAttempt>();

    public string? FacbookUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public string? Slogan { get; set; }
    public Guid? PaisId { get; set; }
}
