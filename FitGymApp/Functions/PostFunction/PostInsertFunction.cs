using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.Post.Request;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.PostFunction
{
    public class PostInsertFunction
    {
        private readonly ILogger<PostInsertFunction> _logger;
        private readonly IPostService _postService;

        public PostInsertFunction(ILogger<PostInsertFunction> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [Function("Post_CreatePostFunction")]
        public async Task<HttpResponseData> CreatePostAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "post")] HttpRequestData req,
            FunctionContext executionContext)
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

            string? contentType = req.Headers.TryGetValues("Content-Type", out var ctValues) ? ctValues.FirstOrDefault() : null;
            var boundary = MultipartRequestHelper.GetBoundary(contentType ?? string.Empty, 4096);
            var sections = await MultipartRequestHelper.GetSectionsAsync(req.Body, boundary);
            var postRequest = new PostCreateRequestDto { UserId = userId ?? Guid.Empty };

            foreach (var section in sections)
            {
                if (section.Name == "Content")
                    postRequest.Content = section.Value ?? string.Empty;
                if (section.Name == "Media" && section.FileContent != null)
                {
                    postRequest.Media = section.FileContent;
                    postRequest.FileName = section.FileName;
                    postRequest.MediaType = section.ContentType;
                }
            }

            var result = await _postService.CreatePostAsync(postRequest);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
