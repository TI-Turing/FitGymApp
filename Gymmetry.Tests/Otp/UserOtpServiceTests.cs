using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services;
using Gymmetry.Repository.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Tests.Otp
{
    public class UserOtpServiceTests
    {
        private readonly Mock<IUserOtpRepository> _userOtpRepositoryMock = new();
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IVerificationTypeRepository> _verificationTypeRepositoryMock = new();
        private readonly Mock<ILogger<UserOtpService>> _loggerMock = new();
        private readonly UserOtpService _service;

        public UserOtpServiceTests()
        {
            _service = new UserOtpService(
                _userOtpRepositoryMock.Object,
                _userRepositoryMock.Object,
                _verificationTypeRepositoryMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task ValidateOtpAsync_ReturnsFalse_WhenVerificationTypeNotFound()
        {
            _verificationTypeRepositoryMock.Setup(r => r.FindVerificationTypesByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<VerificationType>());
            var result = await _service.ValidateOtpAsync(Guid.NewGuid(), "12345", "sms");
            Assert.False(result);
        }

        [Fact]
        public async Task ValidateOtpAsync_ReturnsFalse_WhenOtpNotFound()
        {
            var verificationTypeId = Guid.NewGuid();
            _verificationTypeRepositoryMock.Setup(r => r.FindVerificationTypesByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<VerificationType> { new VerificationType { Id = verificationTypeId, Name = "sms" } });
            _userOtpRepositoryMock.Setup(r => r.FindUserOtpByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<UserOTP>());
            var result = await _service.ValidateOtpAsync(Guid.NewGuid(), "12345", "sms");
            Assert.False(result);
        }

        [Fact]
        public async Task ValidateOtpAsync_ReturnsTrue_WhenOtpIsValid()
        {
            var verificationTypeId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var otp = "12345";
            var otpEntity = new UserOTP { Id = Guid.NewGuid(), OTP = otp, UserId = userId, VerificationTypeId = verificationTypeId, IsVerified = false };
            _verificationTypeRepositoryMock.Setup(r => r.FindVerificationTypesByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<VerificationType> { new VerificationType { Id = verificationTypeId, Name = "sms" } });
            _userOtpRepositoryMock.Setup(r => r.FindUserOtpByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<UserOTP> { otpEntity });
            _userOtpRepositoryMock.Setup(r => r.UpdateUserOtpAsync(It.IsAny<UserOTP>())).ReturnsAsync(true);
            var result = await _service.ValidateOtpAsync(userId, otp, "sms");
            Assert.True(result);
            Assert.True(otpEntity.IsVerified);
        }

        [Fact]
        public async Task ValidateOtpAsync_ReturnsFalse_OnException()
        {
            _verificationTypeRepositoryMock.Setup(r => r.FindVerificationTypesByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ThrowsAsync(new Exception("fail"));
            var result = await _service.ValidateOtpAsync(Guid.NewGuid(), "12345", "sms");
            Assert.False(result);
        }

        [Fact]
        public async Task SendOtpAsync_ReturnsError_WhenVerificationTypeNotFound()
        {
            _verificationTypeRepositoryMock.Setup(r => r.FindVerificationTypesByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<VerificationType>());
            var result = await _service.SendOtpAsync(Guid.NewGuid(), "sms", "1234567890", "sms");
            Assert.False(result.Success);
            Assert.Equal("Verification type not found.", result.Message);
        }

        [Fact]
        public async Task SendOtpAsync_ReturnsError_WhenSendOtpMessageFails()
        {
            var verificationTypeId = Guid.Parse("2082D337-B3FD-4F9A-8C89-AF9C1038DA9C");
            _verificationTypeRepositoryMock.Setup(r => r.FindVerificationTypesByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<VerificationType> { new VerificationType { Id = verificationTypeId, Name = "sms" } });
            _userOtpRepositoryMock.Setup(r => r.FindUserOtpByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<UserOTP>());
            _userRepositoryMock.Setup(r => r.SendSmsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);
            var result = await _service.SendOtpAsync(Guid.NewGuid(), "sms", "1234567890", "sms");
            Assert.False(result.Success);
            Assert.Equal("Failed to send OTP.", result.Message);
        }

        [Fact]
        public async Task SendOtpAsync_ReturnsSuccess_WhenOtpSentAndSaved()
        {
            var verificationTypeId = Guid.Parse("2082D337-B3FD-4F9A-8C89-AF9C1038DA9C");
            _verificationTypeRepositoryMock.Setup(r => r.FindVerificationTypesByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<VerificationType> { new VerificationType { Id = verificationTypeId, Name = "sms" } });
            _userOtpRepositoryMock.Setup(r => r.FindUserOtpByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(new List<UserOTP>());
            _userRepositoryMock.Setup(r => r.SendSmsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            _userRepositoryMock.Setup(r => r.SaveUserOtpAsync(It.IsAny<UserOTP>())).Returns(Task.CompletedTask);
            var result = await _service.SendOtpAsync(Guid.NewGuid(), "sms", "1234567890", "sms");
            Assert.True(result.Success);
            Assert.Equal("OTP sent and saved.", result.Message);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task SendOtpAsync_ReturnsError_OnException()
        {
            _verificationTypeRepositoryMock.Setup(r => r.FindVerificationTypesByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ThrowsAsync(new Exception("fail"));
            var result = await _service.SendOtpAsync(Guid.NewGuid(), "sms", "1234567890", "sms");
            Assert.False(result.Success);
            Assert.Equal("Technical error while sending OTP.", result.Message);
        }
    }
}
