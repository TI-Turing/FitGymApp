using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.RoutineTemplate.Request
{
    public class AddRoutineTemplateRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
        public string Comments { get; set; } = null!;
        public Guid GymId { get; set; }
        public Guid RoutineUserRoutineId { get; set; }
        public Guid RoutineAssignedId { get; set; }
    }
}
