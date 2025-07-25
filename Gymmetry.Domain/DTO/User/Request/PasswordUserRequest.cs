using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymmetry.Domain.DTO.User.Request
{
    public class PasswordUserRequest
    {
        public string Email { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
