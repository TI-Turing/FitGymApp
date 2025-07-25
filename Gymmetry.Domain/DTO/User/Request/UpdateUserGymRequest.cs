using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymmetry.Domain.DTO.User.Request
{
    public class UpdateUserGymRequest
    {
        public Guid UserId { get; set; }
        public Guid GymId { get; set; }
    }
}
