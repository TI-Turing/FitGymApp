using System;

namespace Gymmetry.Domain.DTO.Like.Request
{
    public class LikeCreateRequestDto
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
