using System;

namespace Gymmetry.Domain.DTO.Like.Response
{
    public class LikeResponseDto
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
