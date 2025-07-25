using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.GymPlanSelectedModule.Request
{
    public class UpdateGymPlanSelectedModuleRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public Guid GymPlanSelectedId { get; set; }
    }
}
