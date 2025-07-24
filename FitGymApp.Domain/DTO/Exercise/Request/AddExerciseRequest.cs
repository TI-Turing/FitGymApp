using System;

namespace FitGymApp.Domain.DTO.Exercise.Request
{
    public class AddExerciseRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
        public Guid CategoryExerciseId { get; set; }
        public string? Description { get; set; } // Nuevo campo
    }
}
