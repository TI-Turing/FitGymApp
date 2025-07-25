using System.Collections.Generic;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.RoutineDay.Request
{
    public class AddRoutineDaysRequest : ApiRequest
    {
        public List<AddRoutineDayRequest> RoutineDays { get; set; } = new();
    }
}
