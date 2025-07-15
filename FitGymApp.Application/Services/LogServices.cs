using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitGymApp.Application.Services
{
    public class LogErrorService : ILogErrorService
    {
        private readonly ILogErrorRepository _repo;
        public LogErrorService(ILogErrorRepository repo) { _repo = repo; }
        public async Task<ApplicationResponse<bool>> LogErrorAsync(Exception ex, string? userId = null, string? ip = null)
        {
            var log = new LogError
            {
                Id = Guid.NewGuid(),
                Error = ex.ToString(),
                CreatedAt = DateTime.UtcNow,
                Ip = ip,
                UserId = userId != null ? Guid.Parse(userId) : Guid.Empty,
                IsActive = true
            };
            return new ApplicationResponse<bool> { Success = await _repo.AddAsync(log) };
        }
    }

    public class LogLoginService : ILogLoginService
    {
        private readonly ILogLoginRepository _repo;
        public LogLoginService(ILogLoginRepository repo) { _repo = repo; }
        public async Task<ApplicationResponse<bool>> LogLoginAsync(Guid? userId, bool success, string? ip = null, string? message = null)
        {
            var log = new LogLogin
            {
                Id = Guid.NewGuid(),
                UserId = userId ?? Guid.Empty,
                CreatedAt = DateTime.UtcNow,
                Ip = ip,
                IsActive = true,
                IsSuccess = success
            };
            return new ApplicationResponse<bool> { Success = await _repo.AddAsync(log) };
        }
    }

    public class LogChangeService : ILogChangeService
    {
        private readonly ILogChangeRepository _repo;
        public LogChangeService(ILogChangeRepository repo) { _repo = repo; }
        public async Task<ApplicationResponse<bool>> LogChangeAsync(string table, object pastObject, Guid? userId, string? ip = null, string invocationId = "")
        {
            var log = new LogChange
            {
                Id = Guid.NewGuid(),
                Table = table,
                PastObject = JsonSerializer.Serialize(pastObject),
                CreatedAt = DateTime.UtcNow,
                Ip = ip,
                UserId = userId ?? Guid.Empty,
                IsActive = true,
                InvocationId= invocationId
            };
            return new ApplicationResponse<bool> { Success = await _repo.AddAsync(log) };
        }
    }
}
