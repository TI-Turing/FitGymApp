using System;

namespace Gymmetry.Domain.DTO.Brand.Request
{
    public class UpdateBrandRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
