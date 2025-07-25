using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.LogChange.Request
{
    public class UpdateLogChangeRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string Table { get; set; } = null!;
        public string PastObject { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
