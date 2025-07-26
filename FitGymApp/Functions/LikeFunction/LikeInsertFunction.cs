using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.Like.Request;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Functions.LikeFunction
{
    public class LikeInsertFunction
    {
        private readonly ILogger<LikeInsertFunction> _logger;
        private readonly ILikeService _likeService;

        public LikeInsertFunction(ILogger<LikeInsertFunction> logger, ILikeService likeService)
        {
            _logger = logger;
            _likeService = likeService;
        }

        [Function("Like_CreateLikeFunction")]
        public async Task<HttpResponseData> CreateLikeAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "like")] HttpRequestData req,
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
            var dto = JsonSerializer.Deserialize<LikeCreateRequestDto>(body);
            if (dto == null)
            {
                var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                await badRequest.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Datos de like inválidos.",
                    Data = null,
                    StatusCode = 400
                });
                return badRequest;
            }
            dto.UserId = userId ?? Guid.Empty;
            var result = await _likeService.CreateLikeAsync(dto);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
