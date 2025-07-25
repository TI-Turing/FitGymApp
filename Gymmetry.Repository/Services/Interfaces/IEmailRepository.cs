using System.Threading.Tasks;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IEmailRepository
    {
        Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string? from = null);
    }
}
