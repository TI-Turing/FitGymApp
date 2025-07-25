using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.UninstallOption.Request
{
    public class UpdateUninstallOptionRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
