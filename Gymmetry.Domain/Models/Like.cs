using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Like
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    public virtual Post Post { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
