using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.LogUninstall.Request
{
    public class AddLogUninstallRequest : ApiRequest
    {
        public string? Comments { get; set; }
        public Guid UserId { get; set; }
        public Guid UnnistallOptionsId { get; set; }
    }
}
