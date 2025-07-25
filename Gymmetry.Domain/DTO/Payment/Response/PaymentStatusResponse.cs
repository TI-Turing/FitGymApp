using Gymmetry.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymmetry.Domain.DTO.Payment.Response
{
    public class PaymentStatusResponse
    {
        public PaymentStatusEnum Status { get; set; }
        public string ExternalId { get; set; }
        public string Gateway { get; set; } // Wompi, Stripe, etc.
        public string Message { get; set; }
    }
}
