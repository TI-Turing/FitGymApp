using System;

namespace FitGymApp.Domain.DTO.User.Request
{
    public class PaymentRequestDto
    {
        public Guid UserId { get; set; }
        public string PaymentMethod { get; set; } // e.g., DebitCard, CreditCard, PSE, MercadoPago, PayPal, Stripe
        public decimal Amount { get; set; }
        public string Currency { get; set; } // e.g., COP, USD
        public string Description { get; set; } // e.g., "Payment for Premium Plan"
    }
}