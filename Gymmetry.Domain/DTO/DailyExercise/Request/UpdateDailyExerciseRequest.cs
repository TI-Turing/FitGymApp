using System;

namespace Gymmetry.Domain.DTO.DailyExercise.Request
{
    public class UpdateDailyExerciseRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Set { get; set; } = null!;
        public string Repetitions { get; set; } = null!;
        public Guid DailyId { get; set; }
        public Guid ExerciseId { get; set; }
    }
}
