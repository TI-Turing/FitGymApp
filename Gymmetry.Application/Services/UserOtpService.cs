using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Application.Services
{
    public class UserOtpService : IUserOtpService
    {
        private readonly IUserOtpRepository _userOtpRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVerificationTypeRepository _verificationTypeRepository;
        private readonly ILogger<UserOtpService> _logger;

        public UserOtpService(
            IUserOtpRepository userOtpRepository,
            IUserRepository userRepository,
            IVerificationTypeRepository verificationTypeRepository,
            ILogger<UserOtpService> logger)
        {
            _userOtpRepository = userOtpRepository;
            _userRepository = userRepository;
            _verificationTypeRepository = verificationTypeRepository;
            _logger = logger;
        }

        public async Task<bool> ValidateOtpAsync(Guid userId, string otp)
        {
            // Para compatibilidad retro, delega a la nueva sobrecarga usando un VerificationType vacío
            return await ValidateOtpAsync(userId, otp, string.Empty);
        }

        public async Task<bool> ValidateOtpAsync(Guid userId, string otp, string verificationType)
        {
            try
            {
                var verificationTypeGuid = await GetVerificationTypeIdAsync(verificationType).ConfigureAwait(false);
                if (verificationTypeGuid == null)
                {
                    _logger.LogWarning("Verification type not found for ValidateOtpAsync: {VerificationType}", verificationType);
                    return false;
                }
                var filters = new Dictionary<string, object>
                {
                    { "UserId", userId },
                    { "OTP", otp },
                    { "IsVerified", false },
                    { "VerificationTypeId", verificationTypeGuid.Value }
                };
                var otps = await _userOtpRepository.FindUserOtpByFieldsAsync(filters).ConfigureAwait(false);
                var otpEntity = otps.FirstOrDefault();
                if (otpEntity == null) return false;
                otpEntity.IsVerified = true;
                otpEntity.UpdatedAt = DateTime.UtcNow;
                await _userOtpRepository.UpdateUserOtpAsync(otpEntity).ConfigureAwait(false);

                // Actualizar email o teléfono si corresponde
                var user = await _userRepository.GetUserByIdAsync(userId).ConfigureAwait(false);
                if (user != null)
                {
                    if (verificationTypeGuid.Value == Guid.Parse("DDA61A30-679D-4AFF-887C-69DF91E4D21E"))
                    {
                        user.Email = otpEntity.Recipient;
                        await _userRepository.UpdateUserAsync(user).ConfigureAwait(false);
                    }
                    else if (verificationTypeGuid.Value == Guid.Parse("2082D337-B3FD-4F9A-8C89-AF9C1038DA9C"))
                    {
                        user.Phone = otpEntity.Recipient;
                        await _userRepository.UpdateUserAsync(user).ConfigureAwait(false);
                    }
                }
                return true;    
            }
            catch (Exception ex)    
            {
                _logger.LogError(ex, "Error validating OTP for user {UserId}", userId);
                return false;
            }
        }

        public async Task<ApplicationResponse<bool>> SendOtpAsync(Guid userId, string verificationType, string recipient, string method)
        {
            try
            {
                var verificationTypeGuid = await GetVerificationTypeIdAsync(verificationType).ConfigureAwait(false);
                if (verificationTypeGuid == null)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Message = "Verification type not found.",
                        Data = false
                    };
                }
                await RemoveExistingOtpsAsync(userId, method, verificationTypeGuid.Value).ConfigureAwait(false);
                var otp = GenerateOtpCode();
                var message = $"Gymmetry te da tu codigo de verificación: {otp}";
                if (!await SendOtpMessageAsync(verificationTypeGuid.Value, method, recipient, message).ConfigureAwait(false))
                {
                    return new ApplicationResponse<bool> { Success = false, Message = "Failed to send OTP.", Data = false };
                }
                await SaveOtpAsync(userId, method, verificationTypeGuid.Value, otp, recipient).ConfigureAwait(false);
                return new ApplicationResponse<bool> { Success = true, Message = "OTP sent and saved.", Data = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending OTP for user {UserId}", userId);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Message = "Technical error while sending OTP.",
                    Data = false
                };
            }
        }

        private async Task<Guid?> GetVerificationTypeIdAsync(string verificationType)
        {
            var filters = new Dictionary<string, object> { { "Name", verificationType } };
            var verificationTypes = await _verificationTypeRepository.FindVerificationTypesByFieldsAsync(filters).ConfigureAwait(false);
            return verificationTypes?.FirstOrDefault()?.Id;
        }

        private async Task RemoveExistingOtpsAsync(Guid userId, string method, Guid verificationTypeId)
        {
            var otpFilters = new Dictionary<string, object>
            {
                { "UserId", userId },
                { "Method", method },
                { "VerificationTypeId", verificationTypeId },
                { "IsActive", true }
            };
            var existingOtps = await _userOtpRepository.FindUserOtpByFieldsAsync(otpFilters).ConfigureAwait(false);
            if (existingOtps.Any())
            {
                await _userOtpRepository.DeleteUserOtpsAsync(existingOtps).ConfigureAwait(false);
            }
        }

        private static string GenerateOtpCode()
        {
            var random = new Random();
            return random.Next(10000, 99999).ToString();
        }

        private async Task<bool> SendOtpMessageAsync(Guid verificationTypeId, string method, string recipient, string message)
        {
            if (verificationTypeId == Guid.Parse("2082D337-B3FD-4F9A-8C89-AF9C1038DA9C")) // Phone
            {
                if (method.Equals("whatsapp", StringComparison.OrdinalIgnoreCase))
                    return await _userRepository.SendWhatsappAsync(recipient, message).ConfigureAwait(false);
                if (method.Equals("sms", StringComparison.OrdinalIgnoreCase))
                    return await _userRepository.SendSmsAsync(recipient, message).ConfigureAwait(false);
                return false;
            }
            if (verificationTypeId == Guid.Parse("DDA61A30-679D-4AFF-887C-69DF91E4D21E")) // Email
            {
                // TODO: Implementar el envio de OTP por mail
                return true;
            }
            return false;
        }

        private async Task SaveOtpAsync(Guid userId, string method, Guid verificationTypeId, string otp, string recpient)
        {
            var otpEntity = new UserOTP
            {
                Id = Guid.NewGuid(),
                OTP = otp,
                Method = method,
                IsVerified = false,
                VerificationTypeId = verificationTypeId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                Recipient = recpient
            };
            await _userRepository.SaveUserOtpAsync(otpEntity).ConfigureAwait(false);
        }
    }
}
