using System;

namespace Gymmetry.Domain.DTO.Brand.Request
{
    public class AddBrandRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}
