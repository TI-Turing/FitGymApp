using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.SubModule.Request
{
    public class AddSubModuleRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
        public Guid ModuleId { get; set; }
        public Guid BranchId { get; set; }
    }
}
