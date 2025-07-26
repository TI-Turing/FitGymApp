using System;

namespace Gymmetry.Domain.DTO.Comment.Request
{
    public class CommentCreateRequestDto
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    public class CommentUpdateRequestDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
    }
}
