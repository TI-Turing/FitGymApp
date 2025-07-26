using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class Post
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; } = null!;
    public string? MediaUrl { get; set; }
    public string? MediaType { get; set; } // e.g. "image", "video"
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    public virtual User User { get; set; } = null!;
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
