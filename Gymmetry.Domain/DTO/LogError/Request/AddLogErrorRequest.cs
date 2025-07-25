using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.LogError.Request
{
    public class AddLogErrorRequest : ApiRequest
    {
        public string Error { get; set; } = null!;
        public Guid UserId { get; set; }
        public Guid SubModuleId { get; set; }
    }
}
