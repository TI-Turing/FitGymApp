using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.EmployeeRegisterDaily.Request
{
    public class UpdateEmployeeRegisterDailyRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
