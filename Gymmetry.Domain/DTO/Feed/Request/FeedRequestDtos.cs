namespace Gymmetry.Domain.DTO.Feed.Request
{
    public class FeedCreateRequestDto :ApiRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Media { get; set; }
        public string? MediaType { get; set; }
        public string? FileName { get; set; }
    }

    public class FeedUpdateRequestDto : ApiRequest
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public byte[]? Media { get; set; }
        public string? MediaType { get; set; }
        public string? FileName { get; set; }
    }

    public class UploadFeedMediaRequest : ApiRequest
    {
        public Guid FeedId { get; set; }
        public byte[] Media { get; set; } = null!;
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
    }

    public class SearchFeedRequest : ApiRequest
    {
        // Puedes buscar por título, descripción, usuario, hashtags, etc.
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? UserId { get; set; }
        public string? Hashtag { get; set; }
    }
}
