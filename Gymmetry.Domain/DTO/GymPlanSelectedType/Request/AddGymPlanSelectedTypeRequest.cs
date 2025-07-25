using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.GymPlanSelectedType.Request
{
    public class AddGymPlanSelectedTypeRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}
