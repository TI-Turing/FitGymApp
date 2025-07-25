using System;

namespace Gymmetry.Domain.DTO.Daily.Request
{
    public class UpdateDailyRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public Guid RoutineExerciseId { get; set; }
    }
}
