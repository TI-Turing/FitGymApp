using System.Threading.Tasks;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string? from = null);
    }
}
