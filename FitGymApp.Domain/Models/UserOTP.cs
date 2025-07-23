using System;

namespace FitGymApp.Domain.Models
{
    public class UserOTP
    {
        public Guid Id { get; set; }
        public Guid OTP { get; set; }
        public string Method { get; set; } = null!;
        public bool IsVerified { get; set; }
        public Guid VerificationTypeId { get; set; }
        public Guid UserId { get; set; }
        public string? Ip { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsActive { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual VerificationType VerificationType { get; set; } = null!;
    }
}
