using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.DTO.Feed.Request;
using Gymmetry.Domain.DTO.Feed.Response;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IFeedService
    {
        Task<ApplicationResponse<FeedResponseDto>> CreateFeedAsync(FeedCreateRequestDto request);
        Task<ApplicationResponse<bool>> UpdateFeedAsync(FeedUpdateRequestDto request);
        Task<ApplicationResponse<bool>> DeleteFeedAsync(Guid feedId);
        Task<ApplicationResponse<FeedResponseDto>> GetFeedByIdAsync(Guid feedId);
        Task<ApplicationResponse<IEnumerable<FeedResponseDto>>> GetFeedsByUserAsync(Guid userId);
        Task<ApplicationResponse<IEnumerable<FeedResponseDto>>> GetAllFeedsAsync();
        Task<ApplicationResponse<string>> UploadFeedMediaAsync(UploadFeedMediaRequest request);
        Task<ApplicationResponse<IEnumerable<FeedResponseDto>>> SearchFeedsAsync(SearchFeedRequest request);
    }
}
