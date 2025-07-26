using System;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.LikeFunction
{
    public class LikeDeleteFunction
    {
        private readonly ILogger<LikeDeleteFunction> _logger;
        private readonly ILikeService _likeService;

        public LikeDeleteFunction(ILogger<LikeDeleteFunction> logger, ILikeService likeService)
        {
            _logger = logger;
            _likeService = likeService;
        }

        [Function("Like_DeleteLikeFunction")]
        public async Task<HttpResponseData> DeleteLikeAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "like/{id:guid}")] HttpRequestData req,
            Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = 401
                });
                return unauthorizedResponse;
            }

            var result = await _likeService.DeleteLikeAsync(id);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
