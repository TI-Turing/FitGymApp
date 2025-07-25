using System;

namespace Gymmetry.Domain.DTO.Bill.Request
{
    public class UpdateBillRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Ammount { get; set; } = null!;
        public Guid UserTypeId { get; set; }
        public Guid UserId { get; set; }
        public Guid UserSellerId { get; set; }
        public Guid GymId { get; set; }
    }
}
