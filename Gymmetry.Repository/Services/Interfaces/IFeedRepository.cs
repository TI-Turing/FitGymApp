using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.DTO.Feed.Request;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IFeedRepository
    {
        Task<Feed> AddFeedAsync(Feed feed, byte[]? media = null, string? fileName = null, string? mediaType = null);
        Task<bool> UpdateFeedAsync(Feed feed, byte[]? media = null, string? fileName = null, string? mediaType = null);
        Task<bool> DeleteFeedAsync(Guid feedId);
        Task<Feed?> GetFeedByIdAsync(Guid feedId);
        Task<IEnumerable<Feed>> GetFeedsByUserAsync(Guid userId);
        Task<IEnumerable<Feed>> GetAllFeedsAsync();
        Task<string> UploadFeedMediaToBlobAsync(Guid feedId, byte[] media, string? fileName, string? mediaType);
        Task<IEnumerable<Feed>> SearchFeedsAsync(SearchFeedRequest request);
    }
}
