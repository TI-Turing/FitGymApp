using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.EmployeeRegisterDaily.Request
{
    public class AddEmployeeRegisterDailyRequest : ApiRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
