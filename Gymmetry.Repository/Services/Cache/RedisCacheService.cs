using StackExchange.Redis;
using System;
using System.Threading.Tasks;

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
        public RedisCacheService(string connectionString)
        {
            var redis = ConnectionMultiplexer.Connect(connectionString);
            _db = redis.GetDatabase();
        }
        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
            => await _db.StringSetAsync(key, value, expiry);
        public async Task<string?> GetAsync(string key)
            => await _db.StringGetAsync(key);
        public async Task RemoveAsync(string key)
            => await _db.KeyDeleteAsync(key);
    }
}
