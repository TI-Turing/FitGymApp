using System;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.CommentFunction
{
    public class CommentDeleteFunction
    {
        private readonly ILogger<CommentDeleteFunction> _logger;
        private readonly ICommentService _commentService;

        public CommentDeleteFunction(ILogger<CommentDeleteFunction> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [Function("Comment_DeleteCommentFunction")]
        public async Task<HttpResponseData> DeleteCommentAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "comment/{id:guid}")] HttpRequestData req,
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

            var result = await _commentService.DeleteCommentAsync(id);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
