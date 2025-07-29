using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.Gym.Request
{
    public class AddGymRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid CountryId { get; set; }
        public Guid Owner_UserId { get; set; }
    }
}
