using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.PlanType.Request
{
    public class AddPlanTypeRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}
