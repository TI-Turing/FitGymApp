using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.Schedule.Request
{
    public class UpdateScheduleRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsHoliday { get; set; }
        public Guid BranchId { get; set; }
    }
}
