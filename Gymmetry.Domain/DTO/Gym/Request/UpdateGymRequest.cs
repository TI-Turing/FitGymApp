using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.Gym.Request
{
    public class UpdateGymRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid CountryId { get; set; }
        public Guid GymPlanSelectedId { get; set; }
        public Guid GymTypeId { get; set; }
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
        public Guid? OwnerUserId { get; set; }
        public string? BrandColor { get; set; }
        public int? MaxBranchesAllowed { get; set; }
        public string? QrImageUrl { get; set; }
        public DateTime? TrialEndsAt { get; set; }
    }
}
