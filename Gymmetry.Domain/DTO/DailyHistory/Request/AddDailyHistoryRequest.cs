using System;

namespace Gymmetry.Domain.DTO.DailyHistory.Request
{
    public class AddDailyHistoryRequest : ApiRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public Guid BranchId { get; set; }
        public Guid RoutineExerciseId { get; set; }
    }
}
