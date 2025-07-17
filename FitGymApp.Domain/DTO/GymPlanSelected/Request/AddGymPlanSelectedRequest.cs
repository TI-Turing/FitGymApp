using System;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Domain.DTO.GymPlanSelected.Request
{
    public class AddGymPlanSelectedRequest : ApiRequest
    {
        public Guid GymId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid GymPlanSelectedTypeId { get; set; }
    }
}
