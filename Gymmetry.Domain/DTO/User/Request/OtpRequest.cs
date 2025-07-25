using System;

namespace Gymmetry.Domain.DTO.User.Request
{
    public class OtpRequest
    {
        public Guid UserId { get; set; }
        public string VerificationType { get; set; } = null!;
        public string Recipient { get; set; } = null!;
        public string Method { get; set; } = null!;
    }
}
