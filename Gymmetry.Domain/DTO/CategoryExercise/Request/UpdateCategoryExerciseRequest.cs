using System;

namespace Gymmetry.Domain.DTO.CategoryExercise.Request
{
    public class UpdateCategoryExerciseRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
