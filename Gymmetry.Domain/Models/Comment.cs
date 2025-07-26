using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Comment
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    public virtual Post Post { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
