using Gymmetry.Domain.DTO.Auth.Request;
using Gymmetry.Domain.DTO.Auth.Response;
using System.Threading.Tasks;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task<RefreshTokenResponse?> RefreshTokenAsync(RefreshTokenRequest request);
    }
}