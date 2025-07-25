using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IPasswordService
    {
        Task<ApplicationResponse<string>> HashPasswordAsync(string password);
        Task<ApplicationResponse<bool>> VerifyPasswordAsync(string password, string hashedPassword);
        ApplicationResponse<bool> ValidatePassword(string password, string email);
    }
}
