using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class EmployeeUser
{
    public Guid Id { get; set; }

    public string Arl { get; set; } = null!;

    public string PensionFund { get; set; } = null!;

    public DateTime StartContract { get; set; }

    public DateTime? EndContract { get; set; }

    public string BankId { get; set; } = null!;

    public string AccountType { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string Salary { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid EmployeeTypeId { get; set; }

    public virtual EmployeeType EmployeeType { get; set; } = null!;

    public virtual ICollection<JourneyEmployee> JourneyEmployees { get; set; } = new List<JourneyEmployee>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
