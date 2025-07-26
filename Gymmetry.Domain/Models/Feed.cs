using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Feed
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? MediaUrl { get; set; }
    public string? MediaType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    public virtual User User { get; set; } = null!;
}
