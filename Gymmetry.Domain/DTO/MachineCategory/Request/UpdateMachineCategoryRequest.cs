using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.MachineCategory.Request
{
    public class UpdateMachineCategoryRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
