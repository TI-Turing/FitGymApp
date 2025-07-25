using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gymmetry.Application.Services
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
        private readonly ILogErrorService _logErrorService;

        public LogChangeService(ILogChangeRepository repo, ILogErrorService logErrorService)
        {
            _repo = repo;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<bool>> LogChangeAsync(string table, object pastObject, Guid? userId, string? ip = null, string invocationId = "")
        {
            var log = new LogChange
            {
                Id = Guid.NewGuid(),
                Table = table,
                PastObject = JsonSerializer.Serialize(pastObject, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve }),
                CreatedAt = DateTime.UtcNow,
                Ip = ip,
                UserId = userId ?? Guid.Empty,
                IsActive = true,
                InvocationId = invocationId
            };
            return new ApplicationResponse<bool> { Success = await _repo.AddAsync(log) };
        }

        public async Task<ApplicationResponse<bool>> LogChangeAsync(string table, IEnumerable<object> pastObjects, Guid? userId, string? ip = null, string invocationId = "")
        {
            var logChanges = pastObjects.Select(pastObject => new LogChange
            {
                Id = Guid.NewGuid(),
                Table = table,
                PastObject = JsonSerializer.Serialize(pastObject, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve }),
                CreatedAt = DateTime.UtcNow,
                UserId = userId ?? Guid.Empty,
                Ip = ip,
                InvocationId = invocationId,
                IsActive = true
            }).ToList();

            var success = await _repo.AddRangeAsync(logChanges);

            return new ApplicationResponse<bool>
            {
                Success = success,
                Data = success,
                Message = success ? "Log changes inserted successfully." : "Failed to insert log changes."
            };

        }
    }
}
