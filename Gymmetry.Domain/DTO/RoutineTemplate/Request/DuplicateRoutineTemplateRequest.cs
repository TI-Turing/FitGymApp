namespace Gymmetry.Domain.DTO.RoutineTemplate.Request
{
    public class DuplicateRoutineTemplateRequest
    {
        public Guid RoutineTemplateId { get; set; }
        public Guid GymId { get; set; }
    }
}
