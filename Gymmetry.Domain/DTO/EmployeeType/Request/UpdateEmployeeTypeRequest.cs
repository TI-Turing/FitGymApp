using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.EmployeeType.Request
{
    public class UpdateEmployeeTypeRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
