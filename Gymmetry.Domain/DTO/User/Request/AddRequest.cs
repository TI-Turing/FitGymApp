using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymmetry.Domain.DTO.User.Request
{
    public class AddRequest
    {   
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;            
    }
}
