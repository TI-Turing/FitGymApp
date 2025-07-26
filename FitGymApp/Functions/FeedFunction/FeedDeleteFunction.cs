using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Utils;

namespace Gymmetry.Functions.FeedFunction
{
    public class FeedDeleteFunction
    {
        private readonly ILogger<FeedDeleteFunction> _logger;
        private readonly IFeedService _feedService;

        public FeedDeleteFunction(ILogger<FeedDeleteFunction> logger, IFeedService feedService)
        {
            _logger = logger;
            _feedService = feedService;
        }

        [Function("Feed_DeleteFeedFunction")]
        public async Task<HttpResponseData> DeleteFeedAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "feed/{id:guid}")] HttpRequestData req,
            Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteStringAsync("Unauthorized");
                return unauthorizedResponse;
            }
            var response = req.CreateResponse(HttpStatusCode.NotImplemented);
            await response.WriteStringAsync("Feed delete not implemented yet.");
            return response;
        }
    }
}
