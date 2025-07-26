using System;

namespace Gymmetry.Domain.DTO.Notification.Response
{
    public class NotificationResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Urloption1 { get; set; }
        public string? Urloption2 { get; set; }
        public string? ImageUrl { get; set; }
        public bool Seen { get; set; }
        public bool Opened { get; set; }
        public DateTime? ShowDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
