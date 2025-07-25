using System;

namespace Gymmetry.Domain.DTO.RoutineExercise.Request
{
    public class AddRoutineExerciseRequest : ApiRequest
    {
        public string Sets { get; set; } = null!;
        public string Repetitions { get; set; } = null!;
        public Guid RoutineTemplateId { get; set; }
        public Guid ExerciseId { get; set; }
    }
}
