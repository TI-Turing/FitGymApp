using System;

namespace Gymmetry.Domain.DTO.GymImage
{
    public class GymImageResponse
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = null!;
        public string? Description { get; set; }
        public Guid? GymId { get; set; }
        public Guid? BranchId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? Ip { get; set; }
    }
}
