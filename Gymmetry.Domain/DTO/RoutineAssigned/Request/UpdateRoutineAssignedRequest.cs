using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.RoutineAssigned.Request
{
    public class UpdateRoutineAssignedRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string? Comments { get; set; }
        public Guid UserId { get; set; }
    }
}
