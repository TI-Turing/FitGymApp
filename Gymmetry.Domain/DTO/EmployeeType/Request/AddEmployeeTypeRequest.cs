using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.EmployeeType.Request
{
    public class AddEmployeeTypeRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}