using System;
using System.ComponentModel.DataAnnotations;

namespace FitGymApp.Domain.DTO.Gym.Request
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
