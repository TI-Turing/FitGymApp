using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.GymPlanSelectedType.Request
{
    public class UpdateGymPlanSelectedTypeRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
