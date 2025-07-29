using System;

namespace Gymmetry.Domain.DTO.GymImage
{
    public class UploadGymImageRequest
    {
        public Guid? GymId { get; set; }
        public Guid? BranchId { get; set; }
        public byte[] Image { get; set; } = null!;
        public string? Description { get; set; }
        public string? Ip { get; set; }
    }
}
