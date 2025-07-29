using System;

namespace Gymmetry.Domain.DTO.GymImage
{
    public class UpdateGymImageRequest
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid? GymId { get; set; }
        public Guid? BranchId { get; set; }
        public string? Ip { get; set; }
    }
}
