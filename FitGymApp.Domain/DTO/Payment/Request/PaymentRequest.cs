using System;

namespace FitGymApp.Domain.DTO.Payment.Request
{
    public class PaymentRequest
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Document { get; set; } = null!;
        public Guid DocumentType { get; set; }
        public string BankCode { get; set; } = null!;
        public string ReturnUrl { get; set; } = null!;
    }
}
