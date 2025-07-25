using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.Permission.Request
{
    public class UpdatePermissionRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string See { get; set; } = null!;
        public string Create { get; set; } = null!;
        public string Read { get; set; } = null!;
        public string Update { get; set; } = null!;
        public string Delete { get; set; } = null!;
        public Guid UserTypeId { get; set; }
        public Guid UserId { get; set; }
    }
}
