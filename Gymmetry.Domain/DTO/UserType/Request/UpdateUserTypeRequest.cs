using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.UserType.Request
{
    public class UpdateUserTypeRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
