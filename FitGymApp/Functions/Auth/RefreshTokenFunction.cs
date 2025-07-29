using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.Auth.Request;
using Gymmetry.Domain.DTO.Auth.Response;
using Gymmetry.Domain.DTO;
using Gymmetry.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;

namespace Gymmetry.Functions.Auth
{
    public class Auth_RefreshTokenFunction
    {
        private readonly ILogger<Auth_RefreshTokenFunction> _logger;
        private readonly IAuthService _authService;

        public Auth_RefreshTokenFunction(ILogger<Auth_RefreshTokenFunction> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [Function("Auth_RefreshTokenFunction")]
        public async Task<HttpResponseData> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "auth/refresh-token")] HttpRequestData req,
            FunctionContext executionContext)
        {
            _logger.LogInformation("Procesando solicitud de refresh token");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var refreshRequest = JsonConvert.DeserializeObject<RefreshTokenRequest>(requestBody);
                var validationResult = ModelValidator.ValidateModel<RefreshTokenRequest, RefreshTokenResponse>(refreshRequest, StatusCodes.Status400BadRequest);
                if (validationResult is not null)
                {
                    var badResponse = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                    await badResponse.WriteAsJsonAsync(validationResult);
                    return badResponse;
                }

                var result = await _authService.RefreshTokenAsync(refreshRequest);
                if (result == null)
                {
                    var unauthorizedResponse = req.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                    await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<RefreshTokenResponse>
                    {
                        Success = false,
                        Message = "Refresh token inválido o expirado.",
                        Data = null,
                        StatusCode = StatusCodes.Status401Unauthorized
                    });
                    return unauthorizedResponse;
                }
                var successResponse = req.CreateResponse(System.Net.HttpStatusCode.OK);
                await successResponse.WriteAsJsonAsync(new ApiResponse<RefreshTokenResponse>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                });
                return successResponse;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al refrescar el token.");
                var errorResponse = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<RefreshTokenResponse>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status500InternalServerError
                });
                return errorResponse;
            }
        }
    }
}
