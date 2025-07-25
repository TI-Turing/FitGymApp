using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.Notification.Request
{
    public class AddNotificationRequest : ApiRequest
    {
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
        public Guid UserId { get; set; }
    }
}
