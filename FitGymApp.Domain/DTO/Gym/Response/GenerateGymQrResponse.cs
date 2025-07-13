using System;
using FitGymApp.Domain.Models;

namespace FitGymApp.Domain.DTO.Gym.Response
{
    public class GenerateGymQrResponse
    {
        public byte[] QrCode { get; set; } = Array.Empty<byte>();
        public FitGymApp.Domain.Models.GymPlanSelectedType GymPlanSelectedType { get; set; } = null!;
    }
}
