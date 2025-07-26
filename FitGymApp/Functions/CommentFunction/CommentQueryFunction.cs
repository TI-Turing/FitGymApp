using System;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.CommentFunction
{
    public class CommentQueryFunction
    {
        private readonly ILogger<CommentQueryFunction> _logger;
        private readonly ICommentService _commentService;

        public CommentQueryFunction(ILogger<CommentQueryFunction> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [Function("Comment_GetCommentByIdFunction")]
        public async Task<HttpResponseData> GetCommentByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "comment/{id:guid}")] HttpRequestData req,
            Guid id)
        {
            var result = await _commentService.GetCommentByIdAsync(id);
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Comment_GetCommentsByPostFunction")]
        public async Task<HttpResponseData> GetCommentsByPostAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "comment/post/{postId:guid}")] HttpRequestData req,
            Guid postId)
        {
            var result = await _commentService.GetCommentsByPostAsync(postId);
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Comment_GetCommentsByUserFunction")]
        public async Task<HttpResponseData> GetCommentsByUserAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "comment/user/{userId:guid}")] HttpRequestData req,
            Guid userId)
        {
            var result = await _commentService.GetCommentsByUserAsync(userId);
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        [Function("Comment_GetAllCommentsFunction")]
        public async Task<HttpResponseData> GetAllCommentsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "comment")] HttpRequestData req)
        {
            var result = await _commentService.GetAllCommentsAsync();
            var response = req.CreateResponse(result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
