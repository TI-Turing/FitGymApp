using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.User.Request;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace Gymmetry.Functions.OtpFunction;

public class OtpUtilsFunction
{
    private readonly ILogger<OtpUtilsFunction> _logger;
    private readonly IUserOtpService _userOtpService;

    public OtpUtilsFunction(ILogger<OtpUtilsFunction> logger, IUserOtpService userOtpService)
    {
        _logger = logger;
        _userOtpService = userOtpService;
    }

    [Function("Otp_GenerateOtpFunction")]
    public async Task<HttpResponseData> GenerateOtpAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "otp/generate-otp")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("User_GenerateOtpFunction");
        logger.LogInformation("Generating OTP code for user");

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
            var result = await _userOtpService.SendOtpAsync(data.UserId, data.VerificationType, data.Recipient, data.Method);
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

    [Function("Otp_ValidateOtpFunction")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "otp/validate-otp")] HttpRequestData req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var request = JsonConvert.DeserializeObject<ValidateOtpRequest>(requestBody);
        if (request == null || request.UserId == Guid.Empty || string.IsNullOrEmpty(request.Otp) || string.IsNullOrEmpty(request.VerificationType))
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteAsJsonAsync(new ApiResponse<bool>
            {
                Success = false,
                Message = "Datos de entrada inválidos.",
                Data = false,
                StatusCode = 400
            });
            return badResponse;
        }
        var isValid = await _userOtpService.ValidateOtpAsync(request.UserId, request.Otp, request.VerificationType);
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(new ApiResponse<bool>
        {
            Success = isValid,
            Message = isValid ? "OTP válido." : "OTP inválido o expirado.",
            Data = isValid,
            StatusCode = isValid ? 200 : 400
        });
        return response;
    }
}
