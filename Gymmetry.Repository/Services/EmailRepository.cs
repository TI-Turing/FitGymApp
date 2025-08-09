using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp; // RestSharp v112.1.0
using RestSharp.Authenticators;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Gymmetry.Repository.Services
{
    public class EmailRepository : IEmailRepository
    {
        private readonly string _mailGunApiKey;
        private readonly string _mailGunDomain;
        private readonly string _defaultFrom;


        public EmailRepository(IConfiguration configuration)
        {
            _mailGunApiKey = GetApiKey(configuration);
            _mailGunDomain = GetDomain(configuration);
            _defaultFrom = GetDefaultFrom(configuration);
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string? from = null)
        {
            var options = new RestClientOptions("https://api.mailgun.net")
            {
                Authenticator = new HttpBasicAuthenticator("api", Environment.GetEnvironmentVariable("API_KEY") ?? "API_KEY")
            };

            using var client = new RestClient(options);
            var request = new RestRequest("/v3/gymmetry.fit/messages", Method.Post);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("from", "Mailgun Sandbox <postmaster@gymmetry.fit>");
            request.AddParameter("to", "Jose Luis Avila <jlap.11@hotmail.com>");
            request.AddParameter("subject", "Hello Jose Luis Avila");
            request.AddParameter("text", "Congratulations Jose Luis Avila, you just sent an email with Mailgun! You are truly awesome!");


            return client.ExecuteAsync(request).Result.IsSuccessful;
        }

        private static string GetApiKey(IConfiguration configuration)
        {
            return Environment.GetEnvironmentVariable("MAILGUN_API_KEY") ?? configuration["MailGun:ApiKey"] ?? throw new InvalidOperationException("MailGun API Key not configured.");
        }

        private static string GetDomain(IConfiguration configuration)
        {
            return Environment.GetEnvironmentVariable("MAILGUN_DOMAIN") ?? configuration["MailGun:Domain"] ?? throw new InvalidOperationException("MailGun domain not configured.");
        }

        private static string GetDefaultFrom(IConfiguration configuration)
        {
            return Environment.GetEnvironmentVariable("MAILGUN_FROM") ?? configuration["MailGun:From"] ?? throw new InvalidOperationException("MailGun From address not configured.");
        }
    }
}
