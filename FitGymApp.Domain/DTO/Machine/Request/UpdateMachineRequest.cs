using System;
using System.Collections.Generic;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Domain.DTO.Machine.Request
{
    public class UpdateMachineRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Observations { get; set; }
        public Guid? MachineCategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public List<Guid>? MachineCategoryIds { get; set; }
    }
}
