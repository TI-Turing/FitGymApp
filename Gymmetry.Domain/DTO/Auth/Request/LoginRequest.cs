namespace Gymmetry.Domain.DTO.Auth.Request
{
    public class LoginRequest
    {
        public string UserNameOrEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}