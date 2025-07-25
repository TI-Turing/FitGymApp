using System;
using Gymmetry.Domain.Models;

namespace Gymmetry.Domain.DTO.Gym.Response
{
    public class GenerateGymQrResponse
    {
        public string QrCode { get; set; } = string.Empty;
        public Gymmetry.Domain.Models.GymPlanSelectedType GymPlanSelectedType { get; set; } = null!;
    }
}
