using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.GymPlanSelected.Request
{
    public class AddGymPlanSelectedRequest : ApiRequest
    {
        public Guid GymId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid GymPlanSelectedTypeId { get; set; }
    }
}
