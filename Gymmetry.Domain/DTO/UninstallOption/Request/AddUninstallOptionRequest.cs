using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.UninstallOption.Request
{
    public class AddUninstallOptionRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
    }
}
