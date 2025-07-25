using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.EmployeeUser.Request
{
    public class AddEmployeeUserRequest : ApiRequest
    {
        public string Arl { get; set; } = null!;
        public string PensionFund { get; set; } = null!;
        public DateTime StartContract { get; set; }
        public DateTime? EndContract { get; set; }
        public string BankId { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string Salary { get; set; } = null!;
        public Guid EmployeeTypeId { get; set; }
    }
}