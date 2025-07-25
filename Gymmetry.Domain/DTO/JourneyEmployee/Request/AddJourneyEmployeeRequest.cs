using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.JourneyEmployee.Request
{
    public class AddJourneyEmployeeRequest : ApiRequest
    {
        public string Name { get; set; } = null!;
        public string StartHour { get; set; } = null!;
        public string EndHour { get; set; } = null!;
        public Guid EmployeeUserId { get; set; }
    }
}
