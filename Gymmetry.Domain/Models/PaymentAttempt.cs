using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models
{
    public class PaymentAttempt
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Gateway { get; set; }
        public string ExternalPaymentId { get; set; }
        public string CountryCode { get; set; }
        public Guid? GymId { get; set; }
        public Guid? PlanId { get; set; }
        public Guid? GymPlanSelectedId { get; set; }
        public Guid StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? Ip { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual Plan Plan { get; set; }
        public virtual GymPlanSelected GymPlanSelected { get; set; }
        public virtual PaymentAttemptStatus Status { get; set; }
    }
}