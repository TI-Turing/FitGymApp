using System;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.PostFunction
{
    public class PostQueryFunction
    {
        private readonly ILogger<PostQueryFunction> _logger;
        private readonly IPostService _postService;

        public PostQueryFunction(ILogger<PostQueryFunction> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [Function("Post_GetPostByIdFunction")]
        public async Task<HttpResponseData> GetPostByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "post/{id:guid}")] HttpRequestData req,
            Guid id)
        {
            var result = await _postService.GetPostByIdAsync(id);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Post_GetPostsByUserFunction")]
        public async Task<HttpResponseData> GetPostsByUserAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "post/user/{userId:guid}")] HttpRequestData req,
            Guid userId)
        {
            var result = await _postService.GetPostsByUserAsync(userId);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Post_GetAllPostsFunction")]
        public async Task<HttpResponseData> GetAllPostsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "post")] HttpRequestData req)
        {
            var result = await _postService.GetAllPostsAsync();
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
