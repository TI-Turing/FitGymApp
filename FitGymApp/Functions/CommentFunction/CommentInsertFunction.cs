using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.Comment.Request;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.CommentFunction
{
    public class CommentInsertFunction
    {
        private readonly ILogger<CommentInsertFunction> _logger;
        private readonly ICommentService _commentService;

        public CommentInsertFunction(ILogger<CommentInsertFunction> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [Function("Comment_CreateCommentFunction")]
        public async Task<HttpResponseData> CreateCommentAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "comment")] HttpRequestData req,
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

            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var dto = JsonSerializer.Deserialize<CommentCreateRequestDto>(body);
            if (dto == null)
            {
                var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                await badRequest.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Datos de comentario inválidos.",
                    Data = null,
                    StatusCode = 400
                });
                return badRequest;
            }
            dto.UserId = userId ?? Guid.Empty;
            var result = await _commentService.CreateCommentAsync(dto);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
