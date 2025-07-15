using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FitGymApp.Application.Services
{
    public static class JwtTokenGenerator
    {
        private static string? _secretKey;
        private static string? _issuer;
        private static string? _audience;
        private static bool _initialized = false;

        private static void Initialize()
        {
            if (_initialized) return;

            var azureEnv = Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");
            string? secretKey = null;
            string? issuer = null;
            string? audience = null;

            if (azureEnv == null)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .Build();
                // Buscar todas las variantes posibles en Values y raíz
                secretKey = config["Jwt:SecretKey"]
                    ?? config["Values:Jwt:SecretKey"]
                    ?? config["JwtSecretKey"]
                    ?? config["Values:JwtSecretKey"];
                issuer = config["Jwt:Issuer"]
                    ?? config["Values:Jwt:Issuer"]
                    ?? config["JwtIssuer"]
                    ?? config["Values:JwtIssuer"];
                audience = config["Jwt:Audience"]
                    ?? config["Values:Jwt:Audience"]
                    ?? config["JwtAudience"]
                    ?? config["Values:JwtAudience"];
            }
            else
            {
                secretKey = Environment.GetEnvironmentVariable("Jwt__SecretKey")
                    ?? Environment.GetEnvironmentVariable("Jwt:SecretKey")
                    ?? Environment.GetEnvironmentVariable("Values__JwtSecretKey")
                    ?? Environment.GetEnvironmentVariable("Values:JwtSecretKey")
                    ?? Environment.GetEnvironmentVariable("JwtSecretKey");
                issuer = Environment.GetEnvironmentVariable("Jwt__Issuer")
                    ?? Environment.GetEnvironmentVariable("Jwt:Issuer")
                    ?? Environment.GetEnvironmentVariable("Values__JwtIssuer")
                    ?? Environment.GetEnvironmentVariable("Values:JwtIssuer")
                    ?? Environment.GetEnvironmentVariable("JwtIssuer");
                audience = Environment.GetEnvironmentVariable("Jwt__Audience")
                    ?? Environment.GetEnvironmentVariable("Jwt:Audience")
                    ?? Environment.GetEnvironmentVariable("Values__JwtAudience")
                    ?? Environment.GetEnvironmentVariable("Values:JwtAudience")
                    ?? Environment.GetEnvironmentVariable("JwtAudience");
            }

            _secretKey = secretKey ?? "SuperSecretKeyForJwtToken123!";
            _issuer = issuer ?? "FitGymApp";
            _audience = audience ?? "FitGymAppUsers";
            _initialized = true;
        }

        public static Task<string> GenerateTokenAsync(Guid userId, string userName, string email, int expireMinutes = 60)
        {
            Initialize();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim(JwtRegisteredClaimNames.Email, email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(tokenString);
        }

        public static Task<ClaimsPrincipal?> ValidateTokenAsync(string token)
        {
            Initialize();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey!);
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true
                }, out _);
                return Task.FromResult<ClaimsPrincipal?>(principal);
            }
            catch
            {
                return Task.FromResult<ClaimsPrincipal?>(null);
            }
        }
    }
}
