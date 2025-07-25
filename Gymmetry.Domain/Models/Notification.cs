using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Notification
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

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<NotificationOption> NotificationOptions { get; set; } = new List<NotificationOption>();

    public virtual User User { get; set; } = null!;
}
