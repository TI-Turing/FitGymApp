using System;

namespace Gymmetry.Domain.DTO.FitUser.Request
{
    public class AddFitUserRequest : ApiRequest
    {
        public string Goal { get; set; } = null!;
        public string ExperienceLevel { get; set; } = null!;
    }
}
