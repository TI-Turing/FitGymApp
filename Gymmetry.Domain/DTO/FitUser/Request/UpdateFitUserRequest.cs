using System;

namespace Gymmetry.Domain.DTO.FitUser.Request
{
    public class UpdateFitUserRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Goal { get; set; } = null!;
        public string ExperienceLevel { get; set; } = null!;
    }
}
