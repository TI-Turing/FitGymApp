using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.User.Request;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace Gymmetry.Functions.UserFunctions;

public class UtilsUserFunction
{
    private readonly ILogger<UtilsUserFunction> _logger;
    private readonly IUserService _userService;
    private readonly IUserOtpService _userOtpService;

    public UtilsUserFunction(ILogger<UtilsUserFunction> logger, IUserService userService, IUserOtpService userOtpService)
    {
        _logger = logger;
        _userService = userService;
        _userOtpService = userOtpService;
    }

    [Function("User_UploadProfileImageFunction")]
    public async Task<HttpResponseData> UploadProfileImageAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/upload-profile-image")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("User_UploadProfileImageFunction");
        logger.LogInformation("Processing request to upload user profile image");

        try
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return unauthorizedResponse;
            }

            string? contentType = req.Headers.TryGetValues("Content-Type", out var ctValues) ? ctValues.FirstOrDefault() : null;
            var boundary = MultipartRequestHelper.GetBoundary(contentType ?? string.Empty, 4096);
            var sections = await MultipartRequestHelper.GetSectionsAsync(req.Body, boundary);
            var userIdGuid = Guid.Empty;
            byte[]? imageBytes = null;
            string? fileName = null;

            foreach (var section in sections)
            {
                if (section.Name == "UserId")
                {
                    userIdGuid = Guid.Parse(section.Value);
                }
                if (section.Name == "ProfileImage" && section.FileContent != null)
                {
                    imageBytes = section.FileContent;
                    fileName = section.FileName;
                    contentType = section.ContentType;
                }
            }

            if (userIdGuid == Guid.Empty || imageBytes == null)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "UserId and ProfileImage are required.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return badResponse;
            }

            var dto = new UploadUserProfileImageRequest
            {
                UserId = userIdGuid,
                Image = imageBytes
            };

            var result = await _userService.UploadUserProfileImageAsync(dto);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error uploading user profile image");
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<string>
            {
                Success = false,
                Message = "Unexpected error uploading user profile image.",
                Data = null,
                StatusCode = StatusCodes.Status500InternalServerError
            });
            return errorResponse;
        }
    }
}