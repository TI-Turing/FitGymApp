using System;

namespace Gymmetry.Domain.DTO.AccessMethodType.Request
{
    public class AddAccessMethodTypeRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}
