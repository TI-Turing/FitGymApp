using System;

namespace Gymmetry.Domain.DTO.GymImage
{
    public class AddGymImageRequest
    {
        public string Url { get; set; } = null!;
        public string? Description { get; set; }
        public Guid? GymId { get; set; }
        public Guid? BranchId { get; set; }
        public byte[]? Image { get; set; } // Para subida
        public string? Ip { get; set; }
    }
}
