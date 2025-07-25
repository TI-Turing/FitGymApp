using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.MachineCategory.Request
{
    public class AddMachineCategoryRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}
