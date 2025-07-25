namespace Gymmetry.Domain.DTO.Auth.Response
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}