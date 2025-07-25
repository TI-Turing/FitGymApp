using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.Plan.Request
{
    public class AddPlanRequest : ApiRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid GymId { get; set; }
        public Guid PlanTypeId { get; set; }
    }
}
