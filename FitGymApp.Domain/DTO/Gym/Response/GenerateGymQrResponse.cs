using System;
using FitGymApp.Domain.Models;

namespace FitGymApp.Domain.DTO.Gym.Response
{
    public class GenerateGymQrResponse
    {
        public string QrCode { get; set; } = string.Empty;
        public FitGymApp.Domain.Models.GymPlanSelectedType GymPlanSelectedType { get; set; } = null!;
    }
}
