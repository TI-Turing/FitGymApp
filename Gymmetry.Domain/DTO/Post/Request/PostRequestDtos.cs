namespace Gymmetry.Domain.DTO.Post.Request
{
    public class PostCreateRequestDto
    {
        public Guid UserId { get; set; }
        public string Content { get; set; } = null!;
        public byte[]? Media { get; set; }
        public string? MediaType { get; set; } // e.g. "image", "video"
        public string? FileName { get; set; }
    }

    public class PostUpdateRequestDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public byte[]? Media { get; set; }
        public string? MediaType { get; set; }
        public string? FileName { get; set; }
    }
}