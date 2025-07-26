using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.Feed.Request;
using Gymmetry.Utils;

namespace Gymmetry.Functions.FeedFunction
{
    public class FeedInsertFunction
    {
        private readonly ILogger<FeedInsertFunction> _logger;
        private readonly IFeedService _feedService;

        public FeedInsertFunction(ILogger<FeedInsertFunction> logger, IFeedService feedService)
        {
            _logger = logger;
            _feedService = feedService;
        }

        [Function("Feed_CreateFeedFunction")]
        public async Task<HttpResponseData> CreateFeedAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "feed")] HttpRequestData req,
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

            // var body = await new StreamReader(req.Body).ReadToEndAsync();
            // var dto = JsonSerializer.Deserialize<FeedCreateRequestDto>(body); // Descomentar cuando exista el DTO
            // if (dto == null)
            // {
            //     var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
            //     await badRequest.WriteAsJsonAsync(new ApiResponse<string>
            //     {
            //         Success = false,
            //         Message = "Datos de feed inválidos.",
            //         Data = null,
            //         StatusCode = 400
            //     });
            //     return badRequest;
            // }
            // dto.UserId = userId ?? Guid.Empty;
            // var result = await _feedService.CreateFeedAsync(dto);
            // var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            // await response.WriteAsJsonAsync(result);
            // return response;

            // Placeholder response
            var response = req.CreateResponse(HttpStatusCode.NotImplemented);
            await response.WriteStringAsync("Feed creation not implemented yet.");
            return response;
        }

        [Function("Feed_UploadMediaFunction")]
        public async Task<HttpResponseData> UploadFeedMediaAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "feed/upload-media")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Feed_UploadMediaFunction");
            logger.LogInformation("Processing request to upload feed media");

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
            var feedId = Guid.Empty;
            byte[]? mediaBytes = null;
            string? fileName = null;
            string? mediaType = null;

            foreach (var section in sections)
            {
                if (section.Name == "FeedId")
                {
                    feedId = Guid.Parse(section.Value);
                }
                if (section.Name == "Media" && section.FileContent != null)
                {
                    mediaBytes = section.FileContent;
                    fileName = section.FileName;
                    mediaType = section.ContentType;
                }
            }

            if (feedId == Guid.Empty || mediaBytes == null)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "FeedId y Media son requeridos.",
                    Data = null,
                    StatusCode = 400
                });
                return badResponse;
            }

            var dto = new UploadFeedMediaRequest
            {
                FeedId = feedId,
                Media = mediaBytes,
                FileName = fileName,
                ContentType = mediaType
            };
            var result = await _feedService.UploadFeedMediaAsync(dto);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
    }
}
