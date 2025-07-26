using System;

namespace Gymmetry.Domain.DTO.Post.Response
{
    public class PostResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = null!;
        public string? MediaUrl { get; set; }
        public string? MediaType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}