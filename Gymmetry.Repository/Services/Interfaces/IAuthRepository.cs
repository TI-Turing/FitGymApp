using System.Threading.Tasks;
using Gymmetry.Domain.DTO.Auth.Request;
using Gymmetry.Domain.DTO.Auth.Response;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
    }
}