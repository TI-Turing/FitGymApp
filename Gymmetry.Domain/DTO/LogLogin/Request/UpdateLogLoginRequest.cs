using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.LogLogin.Request
{
    public class UpdateLogLoginRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public bool IsSuccess { get; set; }
        public Guid UserId { get; set; }
    }
}
