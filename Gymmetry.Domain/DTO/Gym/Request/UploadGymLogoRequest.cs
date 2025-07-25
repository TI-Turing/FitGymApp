using System;
using System.ComponentModel.DataAnnotations;

namespace Gymmetry.Domain.DTO.Gym.Request
{
    public class UploadGymLogoRequest
    {
        [Required]
        public Guid GymId { get; set; }
        [Required]
        public byte[] Image { get; set; } = null!;
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
    }
}

namespace Gymmetry.Domain.DTO.User.Request
{
    public class UploadUserProfileImageRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public byte[] Image { get; set; } = null!;
    }
}
