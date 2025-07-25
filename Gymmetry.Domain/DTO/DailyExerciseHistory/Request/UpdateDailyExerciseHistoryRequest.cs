using System;

namespace Gymmetry.Domain.DTO.DailyExerciseHistory.Request
{
    public class UpdateDailyExerciseHistoryRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Set { get; set; } = null!;
        public string Repetitions { get; set; } = null!;
        public Guid DailyHistoryId { get; set; }
    }
}
