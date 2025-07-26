using System;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.LikeFunction
{
    public class LikeQueryFunction
    {
        private readonly ILogger<LikeQueryFunction> _logger;
        private readonly ILikeService _likeService;

        public LikeQueryFunction(ILogger<LikeQueryFunction> logger, ILikeService likeService)
        {
            _logger = logger;
            _likeService = likeService;
        }

        [Function("Like_GetLikeByIdFunction")]
        public async Task<HttpResponseData> GetLikeByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "like/{id:guid}")] HttpRequestData req,
            Guid id)
        {
            var result = await _likeService.GetLikeByIdAsync(id);
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Like_GetLikesByPostFunction")]
        public async Task<HttpResponseData> GetLikesByPostAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "like/post/{postId:guid}")] HttpRequestData req,
            Guid postId)
        {
            var result = await _likeService.GetLikesByPostAsync(postId);
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Like_GetLikesByUserFunction")]
        public async Task<HttpResponseData> GetLikesByUserAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "like/user/{userId:guid}")] HttpRequestData req,
            Guid userId)
        {
            var result = await _likeService.GetLikesByUserAsync(userId);
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Like_GetAllLikesFunction")]
        public async Task<HttpResponseData> GetAllLikesAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "like")] HttpRequestData req)
        {
            var result = await _likeService.GetAllLikesAsync();
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Like_GetLikeByPostAndUserFunction")]
        public async Task<HttpResponseData> GetLikeByPostAndUserAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "like/post/{postId:guid}/user/{userId:guid}")] HttpRequestData req,
            Guid postId, Guid userId)
        {
            var result = await _likeService.GetLikeByPostAndUserAsync(postId, userId);
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
