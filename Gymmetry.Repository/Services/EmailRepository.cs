using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Repository.Services
{
    public class EmailRepository : IEmailRepository
    {
        private readonly string _sendGridApiKey;
        private readonly string _defaultFrom;

        public EmailRepository(IConfiguration configuration)
        {
            _sendGridApiKey = GetApiKey(configuration);
            _defaultFrom = GetDefaultFrom(configuration);
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string? from = null)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var fromEmail = new EmailAddress(from ?? _defaultFrom);
            var toEmail = new EmailAddress(to);
            var msg = MailHelper.CreateSingleEmail(fromEmail, toEmail, subject, null, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        private static string GetApiKey(IConfiguration configuration)
        {
            return Environment.GetEnvironmentVariable("SENDGRID_API_KEY") ?? configuration["SendGrid:ApiKey"] ?? throw new InvalidOperationException("SendGrid API Key not configured.");
        }

        private static string GetDefaultFrom(IConfiguration configuration)
        {
            return Environment.GetEnvironmentVariable("SENDGRID_FROM") ?? configuration["SendGrid:From"] ?? throw new InvalidOperationException("SendGrid From address not configured.");
        }
    }
}
