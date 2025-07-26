using System;

namespace Gymmetry.Domain.DTO.Feed.Response
{
    public class FeedResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? MediaUrl { get; set; }
        public string? MediaType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
