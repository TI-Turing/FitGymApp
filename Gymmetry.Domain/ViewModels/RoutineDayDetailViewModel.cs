using System;

namespace Gymmetry.Domain.ViewModels
{
    public class RoutineDayDetailViewModel
    {
        public Guid RoutineId { get; set; }
        public int DayNumber { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public int Sets { get; set; }
        public string Repetitions { get; set; }
        public bool RequiresEquipment { get; set; }
        public string CategoryName { get; set; }
        public bool IsBodyweight { get; set; }
        public bool IsCalisthenic { get; set; }
        public bool IsDefault { get; set; }
        public string? MachineName { get; set; }
    }
}