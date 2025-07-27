using System;
using System.Threading.Tasks;
using StackExchange.Redis;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Repository.Services.Cache
{
    public interface IRedisCacheService
    {
        Task SetAsync(string key, string value, TimeSpan? expiry = null);
        Task<string?> GetAsync(string key);
        Task RemoveAsync(string key);
    }

    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _db;
        private readonly ILogger<RedisCacheService> _logger;

        public RedisCacheService(string connectionString, ILogger<RedisCacheService> logger)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Redis connection string cannot be null or empty.", nameof(connectionString));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            try
            {
                var redis = ConnectionMultiplexer.Connect(connectionString);
                _db = redis.GetDatabase();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Failed to connect to Redis. Redis will be disabled for this session.");
                _db = null!; // Mark as unavailable
            }
        }

        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            if (string.IsNullOrWhiteSpace(key)) return;
            if (_db == null) { _logger.LogWarning("Redis unavailable. Skipping SetAsync for key {Key}", key); return; }
            try
            {
                await _db.StringSetAsync(key, value, expiry).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting value in Redis for key {Key}. Continuing without cache.", key);
            }
        }

        public async Task<string?> GetAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return null;
            if (_db == null) { _logger.LogWarning("Redis unavailable. Skipping GetAsync for key {Key}", key); return null; }
            try
            {
                var value = await _db.StringGetAsync(key).ConfigureAwait(false);
                return value.HasValue ? value.ToString() : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting value from Redis for key {Key}. Continuing without cache.", key);
                return null;
            }
        }

        public async Task RemoveAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return;
            if (_db == null) { _logger.LogWarning("Redis unavailable. Skipping RemoveAsync for key {Key}", key); return; }
            try
            {
                await _db.KeyDeleteAsync(key).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing key from Redis: {Key}. Continuing without cache.", key);
            }
        }
    }
}
