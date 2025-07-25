using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker.Http;
using System;
using Gymmetry.Application.Services;

namespace Gymmetry.Utils
{
    public static class JwtValidator
    {
        public static bool ValidateJwt(HttpRequest req, out string? error, out Guid? userId)
        {
            error = null;
            userId = null;
            if (!req.Headers.TryGetValue("Authorization", out var authHeader) || string.IsNullOrWhiteSpace(authHeader))
            {
                error = "Token no proporcionado.";
                return false;
            }
            var token = authHeader.ToString().Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase);
            var principalTask = JwtTokenGenerator.ValidateTokenAsync(token);
            var principal = principalTask?.Result;
            if (principal == null)
            {
                error = "Token inválido o expirado.";
                return false;
            }
            var subClaim = principal.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)
                ?? principal.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (subClaim != null && Guid.TryParse(subClaim.Value, out var parsedId))
                userId = parsedId;
            return true;
        }

        public static bool ValidateJwt(HttpRequest req, out string? error)
        {
            error = null;
            if (!req.Headers.TryGetValue("Authorization", out var authHeader) || string.IsNullOrWhiteSpace(authHeader))
            {
                error = "Token no proporcionado.";
                return false;
            }
            var token = authHeader.ToString().Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase);
            var principal = JwtTokenGenerator.ValidateTokenAsync(token);
            if (principal == null)
            {
                error = "Token inválido o expirado.";
                return false;
            }
            return true;
        }

        public static bool ValidateJwt(HttpRequestData req, out string? error, out Guid? userId)
        {
            error = null;
            userId = null;
            if (!req.Headers.TryGetValues("Authorization", out var authHeaders))
            {
                error = "Token no proporcionado.";
                return false;
            }
            var authHeader = string.Join("", authHeaders);
            if (string.IsNullOrWhiteSpace(authHeader))
            {
                error = "Token no proporcionado.";
                return false;
            }
            var token = authHeader.Replace("Bearer ", string.Empty, StringComparison.OrdinalIgnoreCase);
            var principalTask = JwtTokenGenerator.ValidateTokenAsync(token);
            var principal = principalTask?.Result;
            if (principal == null)
            {
                error = "Token inválido o expirado.";
                return false;
            }
            var subClaim = principal.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)
                ?? principal.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (subClaim != null && Guid.TryParse(subClaim.Value, out var parsedId))
                userId = parsedId;
            return true;
        }

        public static bool ValidateJwt(HttpRequestData req, out string? error)
        {
            error = null;
            if (!req.Headers.TryGetValues("Authorization", out var authHeaders))
            {
                error = "Token no proporcionado.";
                return false;
            }
            var authHeader = string.Join("", authHeaders);
            if (string.IsNullOrWhiteSpace(authHeader))
            {
                error = "Token no proporcionado.";
                return false;
            }
            var token = authHeader.Replace("Bearer ", string.Empty, StringComparison.OrdinalIgnoreCase);
            var principal = JwtTokenGenerator.ValidateTokenAsync(token);
            if (principal == null)
            {
                error = "Token inválido o expirado.";
                return false;
            }
            return true;
        }
    }
}
