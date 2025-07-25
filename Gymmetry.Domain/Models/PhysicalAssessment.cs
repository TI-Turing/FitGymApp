using System;
using System.Collections.Generic;

namespace Gymmetry.Domain.Models;

public partial class PhysicalAssessment
{
    public Guid Id { get; set; }

    public string Height { get; set; } = null!;

    public string Weight { get; set; } = null!;

    public string LeftArm { get; set; } = null!;

    public string RighArm { get; set; } = null!;

    public string LeftForearm { get; set; } = null!;

    public string RightForearm { get; set; } = null!;

    public string LeftThigh { get; set; } = null!;

    public string RightThigh { get; set; } = null!;

    public string LeftCalf { get; set; } = null!;

    public string RightCalf { get; set; } = null!;

    public string Abdomen { get; set; } = null!;

    public string Chest { get; set; } = null!;

    public string UpperBack { get; set; } = null!;

    public string LowerBack { get; set; } = null!;

    public string Neck { get; set; } = null!;

    public string Waist { get; set; } = null!;

    public string Hips { get; set; } = null!;

    public string Shoulders { get; set; } = null!;

    public string Wrist { get; set; } = null!;

    public string BodyFatPercentage { get; set; } = null!;

    public string MuscleMass { get; set; } = null!;

    public string Bmi { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
