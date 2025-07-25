using System;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IEmailRepository emailRepository, ILogger<EmailService> logger)
        {
            _emailRepository = emailRepository;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string? from = null)
        {
            try
            {
                _logger.LogInformation("Sending email to {To} with subject {Subject}", to, subject);
                return await _emailRepository.SendEmailAsync(to, subject, htmlContent, from).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                LogEmailError(ex, to);
                return false;
            }
        }

        private void LogEmailError(Exception ex, string to)
        {
            _logger.LogError(ex, "Error sending email to {To}", to);
        }
    }
}
