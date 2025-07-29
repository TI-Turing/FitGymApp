namespace Gymmetry.Domain.DTO.Auth.Response
{
    public class RefreshTokenResponse
    {
        public string NewToken { get; set; } = string.Empty;
        public DateTime TokenExpiration { get; set; }
    }
}
