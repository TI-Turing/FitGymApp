using System;

namespace Gymmetry.Domain.DTO.CategoryExercise.Request
{
    public class AddCategoryExerciseRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}
