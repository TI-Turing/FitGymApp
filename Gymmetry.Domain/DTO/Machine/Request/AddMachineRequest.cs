using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.Machine.Request
{
    public class AddMachineRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? Observations { get; set; }
        public Guid MachineCategoryId { get; set; }
        public Guid BrandId { get; set; }
        public List<Guid>? MachineCategoryIds { get; set; }
    }
}
