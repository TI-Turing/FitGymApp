using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.SubModule.Request
{
    public class UpdateSubModuleRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid ModuleId { get; set; }
        public Guid BranchId { get; set; }
    }
}
