using System;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Domain.DTO.Machine.Request
{
    public class AddMachineRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? Observations { get; set; }
        public Guid MachineCategoryId { get; set; }
        public Guid BrandId { get; set; }
    }
}
