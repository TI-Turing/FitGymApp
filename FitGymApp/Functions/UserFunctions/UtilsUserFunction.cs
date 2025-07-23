using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace FitGymApp.Functions.UserFunctions;

public class UtilsUserFunction
{
    private readonly ILogger<UtilsUserFunction> _logger;
    private readonly IUserService _userService;

    public UtilsUserFunction(ILogger<UtilsUserFunction> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
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

    [Function("User_GenerateOtpFunction")]
    public async Task<HttpResponseData> GenerateOtpAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/generate-otp")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("User_GenerateOtpFunction");
        logger.LogInformation("Generating OTP code for user");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = System.Text.Json.JsonSerializer.Deserialize<OtpRequest>(requestBody);
            if (data == null || data.UserId == Guid.Empty || string.IsNullOrEmpty(data.VerificationType) || string.IsNullOrEmpty(data.Recipient) || string.IsNullOrEmpty(data.Method))
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "UserId, VerificationType, Recipient, and Method are required.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return badResponse;
            }
            // Generar OTP de 5 dígitos
            var random = new Random();
            var otp = random.Next(10000, 99999).ToString();
            var result = await _userService.SendOtpAsync(data.UserId, data.VerificationType, data.Recipient, data.Method, otp);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error generating OTP");
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<string>
            {
                Success = false,
                Message = "Unexpected error generating OTP.",
                Data = null,
                StatusCode = StatusCodes.Status500InternalServerError
            });
            return errorResponse;
        }
    }

    public class OtpRequest
    {
        public Guid UserId { get; set; }
        public string VerificationType { get; set; } = null!;
        public string Recipient { get; set; } = null!;
        public string Method { get; set; } = null!;
    }
}