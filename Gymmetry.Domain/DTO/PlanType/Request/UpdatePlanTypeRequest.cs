using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.PlanType.Request
{
    public class UpdatePlanTypeRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
