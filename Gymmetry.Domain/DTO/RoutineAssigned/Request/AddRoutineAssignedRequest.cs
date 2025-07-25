using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.RoutineAssigned.Request
{
    public class AddRoutineAssignedRequest : ApiRequest
    {
        public string? Comments { get; set; }
        public Guid UserId { get; set; }
    }
}
