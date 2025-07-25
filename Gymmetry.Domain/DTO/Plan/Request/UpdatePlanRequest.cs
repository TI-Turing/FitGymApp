using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.Plan.Request
{
    public class UpdatePlanRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid GymId { get; set; }
        public Guid PlanTypeId { get; set; }
    }
}
