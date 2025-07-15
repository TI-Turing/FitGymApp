using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;

namespace FitGymApp.Application.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly int _minPasswordLength;
        private readonly int _maxPasswordLength;

        public PasswordService(IConfiguration configuration)
        {
            var basicConfig = configuration.GetSection("BasicConfig");
            _minPasswordLength = basicConfig.GetValue<int>("MinPasswordLength", 8);
            _maxPasswordLength = basicConfig.GetValue<int>("MaxPasswordLength", 50);
        }

        public async Task<ApplicationResponse<string>> HashPasswordAsync(string password)
        {
            try
            {
                var hash = BCrypt.Net.BCrypt.HashPassword(password);
                return new ApplicationResponse<string>
                {
                    Success = true,
                    Data = hash
                };
            }
            catch (System.Exception ex)
            {
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "Error al hashear el password.",
                    ErrorCode = "HashError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> VerifyPasswordAsync(string password, string hashedPassword)
        {
            try
            {
                var result = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                return new ApplicationResponse<bool>
                {
                    Success = true,
                    Data = result
                };
            }
            catch (System.Exception ex)
            {
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Message = "Error al verificar el password.",
                    ErrorCode = "VerifyError"
                };

            }
        }

        public ApplicationResponse<bool> ValidatePassword(string password, string email)
        {
            var errors = new List<(bool Condition, string Message, string ErrorCode)>
            {
                (string.IsNullOrWhiteSpace(password), "La contraseña no puede estar vacía.", "PasswordEmpty"),
                (password.Length < _minPasswordLength || password.Length > _maxPasswordLength, $"La contraseña debe tener entre {_minPasswordLength} y {_maxPasswordLength} caracteres.", "PasswordLength"),
                (!password.Any(char.IsLetter), "La contraseña debe contener al menos una letra.", "PasswordLetter"),
                (!password.Any(char.IsDigit), "La contraseña debe contener al menos un número.", "PasswordDigit"),
                (!password.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || char.IsDigit(c)), "La contraseña solo puede contener letras y números del alfabeto inglés.", "PasswordCharset"),
                (password.Contains(" "), "La contraseña no puede contener espacios.", "PasswordSpace"),
                (password.Equals(email, StringComparison.OrdinalIgnoreCase), "La contraseña no puede ser igual al correo electrónico.", "PasswordEqualsEmail")
            };
            var firstError = errors.FirstOrDefault(e => e.Condition);
            if (firstError != default)
            {
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Message = firstError.Message,
                    ErrorCode = firstError.ErrorCode,
                    Data = false
                };
            }
            return new ApplicationResponse<bool> { Success = true, Data = true };
        }
    }
}
