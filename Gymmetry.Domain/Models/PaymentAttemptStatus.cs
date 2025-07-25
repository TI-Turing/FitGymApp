using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models
{
    public class PaymentAttemptStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!; // Example: Pending, Success, Failed

        public virtual ICollection<PaymentAttempt> PaymentAttempts { get; set; } = new List<PaymentAttempt>();
    }
}