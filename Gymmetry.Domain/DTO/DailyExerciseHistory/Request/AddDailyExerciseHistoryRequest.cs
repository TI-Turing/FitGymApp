using System;

namespace Gymmetry.Domain.DTO.DailyExerciseHistory.Request
{
    public class AddDailyExerciseHistoryRequest : ApiRequest
    {
        public string Set { get; set; } = null!;
        public string Repetitions { get; set; } = null!;
        public Guid DailyHistoryId { get; set; }
    }
}
