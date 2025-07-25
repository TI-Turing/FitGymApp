using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.GymPlanSelectedModule.Request
{
    public class AddGymPlanSelectedModuleRequest : ApiRequest
    {
        public Guid GymPlanSelectedId { get; set; }
    }
}
