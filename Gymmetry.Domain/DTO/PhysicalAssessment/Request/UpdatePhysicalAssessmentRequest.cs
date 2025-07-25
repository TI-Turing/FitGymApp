using System;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Domain.DTO.PhysicalAssessment.Request
{
    public class UpdatePhysicalAssessmentRequest : ApiRequest
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
        public Guid UserId { get; set; }
    }
}
