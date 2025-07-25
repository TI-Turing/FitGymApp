using System;

namespace Gymmetry.Domain.DTO.DailyHistory.Request
{
    public class UpdateDailyHistoryRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public Guid BranchId { get; set; }
        public Guid RoutineExerciseId { get; set; }
    }
}
