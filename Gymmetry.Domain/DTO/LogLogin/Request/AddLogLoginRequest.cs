using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.LogLogin.Request
{
    public class AddLogLoginRequest : ApiRequest
    {
        public bool IsSuccess { get; set; }
        public Guid UserId { get; set; }
    }
}
