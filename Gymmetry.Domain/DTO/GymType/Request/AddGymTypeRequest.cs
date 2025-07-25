using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.GymType.Request
{
    public class AddGymTypeRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
