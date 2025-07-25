using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.GymType.Request
{
    public class UpdateGymTypeRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
