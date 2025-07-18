namespace FitGymApp.Domain.DTO.Gym.Request
{
    public class GenerateGymQrRequest
    {
        public Guid GymId { get; set; }
        public string Url { get; set; } = string.Empty; // New field for URL
    }
}
