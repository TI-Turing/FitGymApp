using System;

namespace Gymmetry.Domain.DTO.RoutineExercise.Request
{
    public class UpdateRoutineExerciseRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Sets { get; set; } = null!;
        public string Repetitions { get; set; } = null!;
        public Guid RoutineTemplateId { get; set; }
        public Guid ExerciseId { get; set; }
    }
}
