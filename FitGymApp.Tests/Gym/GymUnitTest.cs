using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services;
using FitGymApp.Repository.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO.Gym.Request;
using FitGymApp.Domain.DTO.Gym.Response;
using AutoMapper;

using GymModel = FitGymApp.Domain.Models.Gym;

namespace FitGymApp.Tests.Gym
{
    public class GymUnitTest
    {
        public class GymServiceTests
        {
            private readonly Mock<IGymRepository> _gymRepositoryMock = new();
            private readonly Mock<ILogChangeService> _logChangeServiceMock = new();
            private readonly Mock<ILogErrorService> _logErrorServiceMock = new();
            private readonly Mock<IMapper> _mapperMock = new();
            private readonly Mock<IUserRepository> _userRepositoryMock = new();
            private readonly Mock<IPlanRepository> _planRepositoryMock = new();
            private readonly Mock<IBranchService> _branchServiceMock = new();
            private readonly Mock<IRoutineTemplateService> _routineTemplateServiceMock = new();
            private readonly Mock<IUserService> _userServiceMock = new();
            private readonly Mock<ILogger<GymService>> _loggerMock = new();
            private readonly GymService _service;

            public GymServiceTests()
            {
                _service = new GymService(
                    _gymRepositoryMock.Object,
                    _logChangeServiceMock.Object,
                    _logErrorServiceMock.Object,
                    _mapperMock.Object,
                    _userRepositoryMock.Object,
                    _planRepositoryMock.Object,
                    _branchServiceMock.Object,
                    _routineTemplateServiceMock.Object,
                    _userServiceMock.Object,
                    _loggerMock.Object
                );
            }

            [Fact]
            public async Task CreateGymAsync_ReturnsSuccess()
            {
                var req = new AddGymRequest { Name = "Test", Nit = "123", Email = "a@b.com", CountryId = Guid.NewGuid(), GymPlanSelectedId = Guid.NewGuid(), GymTypeId = Guid.NewGuid() };
                var gym = new GymModel { Id = Guid.NewGuid(), Name = req.Name };
                _mapperMock.Setup(m => m.Map<GymModel>(req)).Returns(gym);
                _gymRepositoryMock.Setup(r => r.CreateGymAsync(gym)).ReturnsAsync(gym);
                var result = await _service.CreateGymAsync(req);
                Assert.True(result.Success);
                Assert.Equal(gym.Name, result.Data.Name);
            }

            [Fact]
            public async Task GetGymByIdAsync_ReturnsNotFound()
            {
                var id = Guid.NewGuid();
                _gymRepositoryMock.Setup(r => r.GetGymByIdAsync(id)).ReturnsAsync((GymModel?)null);
                var result = await _service.GetGymByIdAsync(id);
                Assert.False(result.Success);
                Assert.Equal("Gimnasio no encontrado.", result.Message);
            }

            [Fact]
            public async Task GetAllGymsAsync_ReturnsGyms()
            {
                var gyms = new List<GymModel> { new GymModel { Id = Guid.NewGuid(), Name = "G1" } };
                _gymRepositoryMock.Setup(r => r.GetAllGymsAsync()).ReturnsAsync((IEnumerable<GymModel>)gyms);
                var result = await _service.GetAllGymsAsync();
                Assert.True(result.Success);
                Assert.Single(result.Data);
            }

            [Fact]
            public async Task UpdateGymAsync_ReturnsNotFound()
            {
                var req = new UpdateGymRequest { Id = Guid.NewGuid(), Name = "Test", Nit = "123", Email = "a@b.com", CountryId = Guid.NewGuid(), GymPlanSelectedId = Guid.NewGuid(), GymTypeId = Guid.NewGuid() };
                _gymRepositoryMock.Setup(r => r.GetGymByIdAsync(req.Id)).ReturnsAsync((GymModel?)null);
                var result = await _service.UpdateGymAsync(req, null);
                Assert.False(result.Success);
                Assert.Equal("Gimnasio no encontrado.", result.Message);
            }

            [Fact]
            public async Task DeleteGymAsync_ReturnsNotFound()
            {
                var id = Guid.NewGuid();
                _planRepositoryMock.Setup(r => r.FindPlansByFieldsAsync(It.IsAny<Dictionary<string, object>>())).ReturnsAsync(new List<Plan>());
                _gymRepositoryMock.Setup(r => r.DeleteGymAsync(id)).ReturnsAsync(false);
                _userServiceMock.Setup(u => u.UpdateUsersGymToNullAsync(id, It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new ApplicationResponse<bool> { Success = true });
                _branchServiceMock.Setup(b => b.DeleteBranchesByGymIdAsync(id)).ReturnsAsync(new ApplicationResponse<bool> { Success = true });
                _routineTemplateServiceMock.Setup(r => r.DeleteRoutineTemplatesByGymIdAsync(id)).ReturnsAsync(new ApplicationResponse<bool> { Success = true });
                var result = await _service.DeleteGymAsync(id);
                Assert.False(result.Success);
            }

            [Fact]
            public async Task FindGymsByFieldsAsync_ReturnsGyms()
            {
                var gyms = new List<GymModel> { new GymModel { Id = Guid.NewGuid(), Name = "G1" } };
                var filters = new Dictionary<string, object> { { "Name", "G1" } };
                _gymRepositoryMock.Setup(r => r.FindGymsByFieldsAsync(filters)).ReturnsAsync((IEnumerable<GymModel>)gyms);
                var result = await _service.FindGymsByFieldsAsync(filters);
                Assert.True(result.Success);
                Assert.Single(result.Data);
            }

            [Fact]
            public async Task GenerateGymQrAsync_ReturnsNotFound()
            {
                var id = Guid.NewGuid();
                _gymRepositoryMock.Setup(r => r.GetGymByIdAsync(id)).ReturnsAsync((GymModel?)null);
                var result = await _service.GenerateGymQrAsync(id);
                Assert.False(result.Success);
            }

            [Fact]
            public async Task UploadGymLogoAsync_ReturnsNotFound()
            {
                var req = new UploadGymLogoRequest { GymId = Guid.NewGuid(), Image = new byte[10] };
                _gymRepositoryMock.Setup(r => r.GetGymByIdAsync(req.GymId)).ReturnsAsync((GymModel?)null);
                var result = await _service.UploadGymLogoAsync(req);
                Assert.False(result.Success);
                Assert.Equal("Gimnasio no encontrado.", result.Message);
            }
        }
    }
}
