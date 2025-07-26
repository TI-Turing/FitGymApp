using System;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.PostFunction
{
    public class PostDeleteFunction
    {
        private readonly ILogger<PostDeleteFunction> _logger;
        private readonly IPostService _postService;

        public PostDeleteFunction(ILogger<PostDeleteFunction> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [Function("Post_DeletePostFunction")]
        public async Task<HttpResponseData> DeletePostAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "post/{id:guid}")] HttpRequestData req,
            Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new Gymmetry.Domain.DTO.ApiResponse<string>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = 401
                });
                return unauthorizedResponse;
            }

            var result = await _postService.DeletePostAsync(id);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
