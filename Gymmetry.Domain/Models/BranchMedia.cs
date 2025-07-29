using System;

namespace Gymmetry.Domain.Models;

public partial class BranchMedia
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string Url { get; set; } = null!;
    public string MediaType { get; set; } = null!; // "image", "video", etc.
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Ip { get; set; }
    public bool IsActive { get; set; }

    public virtual Branch Branch { get; set; } = null!;
}
