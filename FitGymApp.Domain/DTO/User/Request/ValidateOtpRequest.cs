using System;

namespace FitGymApp.Domain.DTO.User.Request
{
    public class ValidateOtpRequest
    {
        public Guid UserId { get; set; }
        public string Otp { get; set; } = null!;
        public string VerificationType { get; set; } = null!;
    }
}
