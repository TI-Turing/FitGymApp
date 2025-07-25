using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class NotificationOption
{
    public Guid Id { get; set; }

    public string Mail { get; set; } = null!;

    public string Push { get; set; } = null!;

    public string App { get; set; } = null!;

    public string WhatsaApp { get; set; } = null!;

    public string Sms { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public Guid NotificationOptionNotificationNotificationOptionId { get; set; }

    public virtual Notification NotificationOptionNotificationNotificationOption { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
