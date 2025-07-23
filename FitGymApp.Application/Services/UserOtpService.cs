using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services
{
    public class UserOtpService : IUserOtpService
    {
        private readonly IUserOtpRepository _userOtpRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVerificationTypeRepository _verificationTypeRepository;

        public UserOtpService(IUserOtpRepository userOtpRepository, IUserRepository userRepository, IVerificationTypeRepository verificationTypeRepository)
        {
            _userOtpRepository = userOtpRepository;
            _userRepository = userRepository;
            _verificationTypeRepository = verificationTypeRepository;
        }

        public async Task<bool> ValidateOtpAsync(Guid userId, string otp)
        {
            var filters = new Dictionary<string, object>
            {
                { "UserId", userId },
                { "OTP", otp },
                { "IsVerified", false }
            };
            var otps = await _userOtpRepository.FindUserOtpByFieldsAsync(filters);
            var otpEntity = otps.FirstOrDefault();
            if (otpEntity != null)
            {
                otpEntity.IsVerified = true;
                otpEntity.UpdatedAt = DateTime.UtcNow;
                await _userOtpRepository.UpdateUserOtpAsync(otpEntity);
                return true;
            }
            return false;
        }

        public async Task<ApplicationResponse<string>> SendOtpAsync(Guid userId, string verificationType, string recipient, string method)
        {
            var filters = new Dictionary<string, object>
            {
                { "Name", verificationType }
            };
            var verificationTypeId = await _verificationTypeRepository.FindVerificationTypesByFieldsAsync(filters).ConfigureAwait(false);
            if (verificationTypeId is null)
            {
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "Verification type not found.",
                    Data = null
                };
            }
            var random = new Random();
            var otp = random.Next(10000, 99999).ToString();

            var message = $"Gymmetry te da tu codigo de verificación: {otp}";
            bool sent = false;
            if (verificationTypeId.FirstOrDefault().Id == Guid.Parse("2082D337-B3FD-4F9A-8C89-AF9C1038DA9C"))   //Phone
            {
                if (method.ToLower() == "whatsapp")
                    sent = await _userRepository.SendWhatsappAsync(recipient, message).ConfigureAwait(false);
                else if (method.ToLower() == "sms")
                    sent = await _userRepository.SendSmsAsync(recipient, message).ConfigureAwait(false);
                else
                    return new ApplicationResponse<string> { Success = false, Message = "Invalid method.", Data = null };
                if (!sent)
                    return new ApplicationResponse<string> { Success = false, Message = "Failed to send OTP.", Data = null };
            }
            if (verificationTypeId.FirstOrDefault().Id == Guid.Parse("DDA61A30-679D-4AFF-887C-69DF91E4D21E"))   //Email
            {
                //TODO: Implementar el envio de OTP por mail
            }
            var otpEntity = new UserOTP
            {
                Id = Guid.NewGuid(),
                OTP = otp,
                Method = method,
                IsVerified = false,
                VerificationTypeId = verificationTypeId.FirstOrDefault().Id,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
            await _userRepository.SaveUserOtpAsync(otpEntity).ConfigureAwait(false);
            return new ApplicationResponse<string> { Success = true, Message = "OTP sent and saved.", Data = otp };
        }
    }
}
