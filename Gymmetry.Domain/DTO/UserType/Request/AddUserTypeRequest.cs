using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.UserType.Request
{
    public class AddUserTypeRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}
