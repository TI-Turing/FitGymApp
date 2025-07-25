using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.RoutineDay.Request
{
    public class UpdateRoutineDayRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public int DayNumber { get; set; }
        public string Name { get; set; } = null!;
        public int Sets { get; set; }
        public string Repetitions { get; set; } = null!;
        public string? Notes { get; set; }
        public Guid RoutineTemplateId { get; set; }
        public Guid? ExerciseId { get; set; }
    }
}
