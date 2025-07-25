using System;

namespace Gymmetry.Domain.DTO.DailyExercise.Request
{
    public class AddDailyExerciseRequest : ApiRequest
    {
        public string Set { get; set; } = null!;
        public string Repetitions { get; set; } = null!;
        public Guid DailyId { get; set; }
        public Guid ExerciseId { get; set; }
    }
}
