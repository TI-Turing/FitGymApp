using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Utils;

namespace Gymmetry.Functions.FeedFunction
{
    public class FeedUpdateFunction
    {
        private readonly ILogger<FeedUpdateFunction> _logger;
        private readonly IFeedService _feedService;

        public FeedUpdateFunction(ILogger<FeedUpdateFunction> logger, IFeedService feedService)
        {
            _logger = logger;
            _feedService = feedService;
        }

        [Function("Feed_UpdateFeedFunction")]
        public async Task<HttpResponseData> UpdateFeedAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "feed/{id:guid}")] HttpRequestData req,
            Guid id,
            FunctionContext executionContext)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteStringAsync("Unauthorized");
                return unauthorizedResponse;
            }
            var response = req.CreateResponse(HttpStatusCode.NotImplemented);
            await response.WriteStringAsync("Feed update not implemented yet.");
            return response;
        }
    }
}
