using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using System.Text.Json;
using Gymmetry.Domain.DTO.Feed.Request;
using Gymmetry.Utils;

namespace Gymmetry.Functions.FeedFunction
{
    public class FeedQueryFunction
    {
        private readonly ILogger<FeedQueryFunction> _logger;
        private readonly IFeedService _feedService;

        public FeedQueryFunction(ILogger<FeedQueryFunction> logger, IFeedService feedService)
        {
            _logger = logger;
            _feedService = feedService;
        }

        [Function("Feed_GetFeedByIdFunction")]
        public async Task<HttpResponseData> GetFeedByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "feed/{id:guid}")] HttpRequestData req,
            Guid id)
        {
            var response = req.CreateResponse(HttpStatusCode.NotImplemented);
            await response.WriteStringAsync("Feed query by id not implemented yet.");
            return response;
        }

        [Function("Feed_GetAllFeedsFunction")]
        public async Task<HttpResponseData> GetAllFeedsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "feed")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.NotImplemented);
            await response.WriteStringAsync("Feed query all not implemented yet.");
            return response;
        }

        [Function("Feed_SearchFeedsFunction")]
        public async Task<HttpResponseData> SearchFeedsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "feed/search")] HttpRequestData req)
        {
            var logger = _logger;
            logger.LogInformation("Processing request to search feeds");

            var body = await req.ReadAsStringAsync();
            var searchRequest = JsonSerializer.Deserialize<SearchFeedRequest>(body);
            if (searchRequest == null)
            {
                var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                await badRequest.WriteAsJsonAsync(new { Success = false, Message = "Datos de búsqueda inválidos." });
                return badRequest;
            }
            var result = await _feedService.SearchFeedsAsync(searchRequest);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
