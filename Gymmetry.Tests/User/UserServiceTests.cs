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
using Gymmetry.Domain.DTO.User.Request;
using Gymmetry.Domain.DTO.User.Response;
using Gymmetry.Application.Services.Interfaces;

namespace Gymmetry.Tests.User
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IPasswordService> _passwordServiceMock;
        private readonly Mock<ILogChangeService> _logChangeServiceMock;
        private readonly Mock<ILogErrorService> _logErrorServiceMock;
        private readonly Mock<ILogger<UserService>> _loggerMock;
        private readonly Mock<IGymRepository> _gymRepositoryMock;
        private readonly Mock<IVerificationTypeRepository> _verificationTypeRepositoryMock;
        private readonly UserService _service;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _passwordServiceMock = new Mock<IPasswordService>();
            _logChangeServiceMock = new Mock<ILogChangeService>();
            _logErrorServiceMock = new Mock<ILogErrorService>();
            _loggerMock = new Mock<ILogger<UserService>>();
            _gymRepositoryMock = new Mock<IGymRepository>();
            _verificationTypeRepositoryMock = new Mock<IVerificationTypeRepository>();
            _service = new UserService(
                _userRepositoryMock.Object,
                _passwordServiceMock.Object,
                _logChangeServiceMock.Object,
                _logErrorServiceMock.Object,
                _loggerMock.Object,
                _gymRepositoryMock.Object,
                _verificationTypeRepositoryMock.Object
            );
        }

        [Fact]
        public async Task CreateUserAsync_ReturnsError_WhenEmailExists()
        {
            var request = new AddRequest { Email = "test@email.com", Password = "Password123!" };
            _userRepositoryMock.Setup(r => r.FindUsersByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync((IEnumerable<Gymmetry.Domain.Models.User>)new List<Gymmetry.Domain.Models.User> { new Gymmetry.Domain.Models.User { Email = request.Email } });

            var result = await _service.CreateUserAsync(request);

            Assert.False(result.Success);
            Assert.Equal("The email is already registered.", result.Message);
        }

        [Fact]
        public async Task CreateUserAsync_ReturnsError_WhenPasswordHashFails()
        {
            var request = new AddRequest { Email = "new@email.com", Password = "Password123!" };
            _userRepositoryMock.Setup(r => r.FindUsersByFieldsAsync(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync((IEnumerable<Gymmetry.Domain.Models.User>)new List<Gymmetry.Domain.Models.User>());
            _passwordServiceMock.Setup(p => p.HashPasswordAsync(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationResponse<string> { Success = false, Message = "Hash error" });

            var result = await _service.CreateUserAsync(request);

            Assert.False(result.Success);
            Assert.Equal("Hash error", result.Message);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser_WhenFound()
        {
            var userId = Guid.NewGuid();
            var user = new Gymmetry.Domain.Models.User { Id = userId, Email = "a@b.com", Password = "hash" };
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync(user);
            var result = await _service.GetUserByIdAsync(userId);
            Assert.True(result.Success);
            Assert.Equal(userId, result.Data.Id);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsNotFound_WhenUserDoesNotExist()
        {
            var userId = Guid.NewGuid();
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync((Gymmetry.Domain.Models.User?)null);
            var result = await _service.GetUserByIdAsync(userId);
            Assert.False(result.Success);
            Assert.Equal("User not found.", result.Message);
        }

        [Fact]
        public async Task GetAllUsersAsync_ReturnsUsers()
        {
            var users = new List<Gymmetry.Domain.Models.User> { new Gymmetry.Domain.Models.User { Email = "a@b.com", Password = "hash" } };
            _userRepositoryMock.Setup(r => r.GetAllUsersAsync()).ReturnsAsync(users);
            var result = await _service.GetAllUsersAsync();
            Assert.True(result.Success);
            Assert.Single(result.Data);
        }

        [Fact]
        public async Task UpdateUserAsync_ReturnsNotFound_WhenUserDoesNotExist()
        {
            var req = new UpdateRequest { Id = Guid.NewGuid() };
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(req.Id)).ReturnsAsync((Gymmetry.Domain.Models.User?)null);
            var result = await _service.UpdateUserAsync(req);
            Assert.False(result.Success);
            Assert.Equal("User not found.", result.Message);
        }

        [Fact]
        public async Task UpdateUserAsync_ReturnsSuccess_WhenUserIsUpdated()
        {
            var userId = Guid.NewGuid();
            var before = new Gymmetry.Domain.Models.User { Id = userId, Email = "a@b.com", Password = "hash" };
            var req = new UpdateRequest { Id = userId };
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync(before);
            _userRepositoryMock.Setup(r => r.UpdateUserAsync(It.IsAny<Gymmetry.Domain.Models.User>())).ReturnsAsync(true);
            _logChangeServiceMock.Setup(l => l.LogChangeAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<Guid?>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new ApplicationResponse<bool> { Success = true });
            var result = await _service.UpdateUserAsync(req);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task UpdateUserAsync_ReturnsError_WhenUpdateFails()
        {
            var userId = Guid.NewGuid();
            var before = new Gymmetry.Domain.Models.User { Id = userId, Email = "a@b.com", Password = "hash" };
            var req = new UpdateRequest { Id = userId };
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync(before);
            _userRepositoryMock.Setup(r => r.UpdateUserAsync(It.IsAny<Gymmetry.Domain.Models.User>())).ReturnsAsync(false);
            var result = await _service.UpdateUserAsync(req);
            Assert.False(result.Success);
        }

        [Fact]
        public async Task UpdateUserGymAsync_ReturnsError_WhenValidationFails()
        {
            var userId = Guid.NewGuid();
            var gymId = Guid.NewGuid();
            // Forzar fallo en validación
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync((Gymmetry.Domain.Models.User?)null);
            var result = await _service.UpdateUserGymAsync(userId, gymId);
            Assert.False(result.Success);
        }

        [Fact]
        public async Task DeleteUserAsync_ReturnsSuccess_WhenDeleted()
        {
            var userId = Guid.NewGuid();
            _userRepositoryMock.Setup(r => r.DeleteUserAsync(userId)).ReturnsAsync(true);
            var result = await _service.DeleteUserAsync(userId);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task DeleteUserAsync_ReturnsError_WhenNotFound()
        {
            var userId = Guid.NewGuid();
            _userRepositoryMock.Setup(r => r.DeleteUserAsync(userId)).ReturnsAsync(false);
            var result = await _service.DeleteUserAsync(userId);
            Assert.False(result.Success);
        }

        [Fact]
        public async Task FindUsersByFieldsAsync_ReturnsUsers()
        {
            var filters = new Dictionary<string, object> { { "Email", "a@b.com" } };
            var users = new List<Gymmetry.Domain.Models.User> { new Gymmetry.Domain.Models.User { Email = "a@b.com", Password = "hash" } };
            _userRepositoryMock.Setup(r => r.FindUsersByFieldsAsync(filters)).ReturnsAsync(users);
            var result = await _service.FindUsersByFieldsAsync(filters);
            Assert.True(result.Success);
            Assert.Single(result.Data);
        }

        [Fact]
        public async Task UpdatePasswordAsync_ReturnsError_WhenUserNotFound()
        {
            var req = new PasswordUserRequest { Email = "a@b.com", NewPassword = "newpass", Token = "t" };
            _userRepositoryMock.Setup(r => r.FindUsersByFieldsAsync(It.IsAny<Dictionary<string, object>>())).ReturnsAsync(new List<Gymmetry.Domain.Models.User>());
            var result = await _service.UpdatePasswordAsync(req);
            Assert.False(result.Success);
            Assert.Equal("User not found.", result.Message);
        }

        [Fact]
        public async Task UpdatePasswordAsync_ReturnsError_WhenPasswordValidationFails()
        {
            var req = new PasswordUserRequest { Email = "a@b.com", NewPassword = "newpass", Token = "t" };
            var user = new Gymmetry.Domain.Models.User { Email = req.Email, Password = "oldhash" };
            _userRepositoryMock.Setup(r => r.FindUsersByFieldsAsync(It.IsAny<Dictionary<string, object>>())).ReturnsAsync(new List<Gymmetry.Domain.Models.User> { user });
            _passwordServiceMock.Setup(p => p.ValidatePassword(req.NewPassword, req.Email)).Returns(new ApplicationResponse<bool> { Success = false, Message = "Invalid password" });
            var result = await _service.UpdatePasswordAsync(req);
            Assert.False(result.Success);
            Assert.Equal("Invalid password", result.Message);
        }

        [Fact]
        public async Task UpdatePasswordAsync_ReturnsSuccess_WhenPasswordUpdated()
        {
            var req = new PasswordUserRequest { Email = "a@b.com", NewPassword = "newpass", Token = "t" };
            var user = new Gymmetry.Domain.Models.User { Email = req.Email, Password = "oldhash" };
            _userRepositoryMock.Setup(r => r.FindUsersByFieldsAsync(It.IsAny<Dictionary<string, object>>())).ReturnsAsync(new List<Gymmetry.Domain.Models.User> { user });
            _passwordServiceMock.Setup(p => p.ValidatePassword(req.NewPassword, req.Email)).Returns(new ApplicationResponse<bool> { Success = true });
            _passwordServiceMock.Setup(p => p.HashPasswordAsync(req.NewPassword)).ReturnsAsync(new ApplicationResponse<string> { Success = true, Data = "newhash" });
            _userRepositoryMock.Setup(r => r.UpdateUserAsync(user)).ReturnsAsync(true);
            var result = await _service.UpdatePasswordAsync(req);
            Assert.True(result.Success);
            Assert.Equal("Password updated successfully.", result.Message);
        }

        [Fact]
        public async Task UpdateUsersGymToNullAsync_ReturnsSuccess_WhenUsersUpdated()
        {
            var gymId = Guid.NewGuid();
            var users = new List<Gymmetry.Domain.Models.User> { new Gymmetry.Domain.Models.User { Id = Guid.NewGuid() } };
            _userRepositoryMock.Setup(r => r.FindUsersByFieldsAsync(It.IsAny<Dictionary<string, object>>())).ReturnsAsync(users);
            _userRepositoryMock.Setup(r => r.BulkUpdateFieldAsync(It.IsAny<IEnumerable<Guid>>(), "GymId", null)).ReturnsAsync(true);
            _logChangeServiceMock.Setup(l => l.LogChangeAsync(It.IsAny<string>(), It.IsAny<IEnumerable<object>>(), It.IsAny<Guid?>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new ApplicationResponse<bool> { Success = true });
            var result = await _service.UpdateUsersGymToNullAsync(gymId);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task ValidateUserFieldsAsync_ReturnsIncomplete_WhenUserNotFound()
        {
            var userId = Guid.NewGuid();
            _userRepositoryMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync((Gymmetry.Domain.Models.User?)null);
            var result = await _service.ValidateUserFieldsAsync(userId);
            Assert.False(result.IsComplete);
            Assert.Contains("User not found", result.MissingFields);
        }

        [Fact]
        public async Task UploadUserProfileImageAsync_ReturnsSuccess()
        {
            var req = new Gymmetry.Domain.DTO.User.Request.UploadUserProfileImageRequest { UserId = Guid.NewGuid(), Image = new byte[] { 1, 2, 3 } };
            _userRepositoryMock.Setup(r => r.UploadUserProfileImageAsync(req.UserId, req.Image)).ReturnsAsync("url");
            var result = await _service.UploadUserProfileImageAsync(req);
            Assert.True(result.Success);
            Assert.Equal("url", result.Data);
        }

        [Fact]
        public async Task PhoneExistsAsync_ReturnsTrue_WhenPhoneExists()
        {
            _userRepositoryMock.Setup(r => r.PhoneExistsAsync("123")).ReturnsAsync(true);
            var result = await _service.PhoneExistsAsync("123");
            Assert.True(result.Success);
            Assert.True(result.Data);
        }
    }
}
