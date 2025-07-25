using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.NotificationOption.Request
{
    public class AddNotificationOptionRequest : ApiRequest
    {
        public string Mail { get; set; } = null!;
        public string Push { get; set; } = null!;
        public string App { get; set; } = null!;
        public string WhatsaApp { get; set; } = null!;
        public string Sms { get; set; } = null!;
        public Guid UserId { get; set; }
        public Guid NotificationOptionNotificationNotificationOptionId { get; set; }
    }
}
