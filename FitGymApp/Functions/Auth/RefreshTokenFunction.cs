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
        public async Task<ApiResponse<RefreshTokenResponse>> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "auth/refresh-token")] HttpRequest req)
        {
            _logger.LogInformation("Procesando solicitud de refresh token");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var refreshRequest = JsonConvert.DeserializeObject<RefreshTokenRequest>(requestBody);
                var validationResult = ModelValidator.ValidateModel<RefreshTokenRequest, RefreshTokenResponse>(refreshRequest, StatusCodes.Status400BadRequest);
                if (validationResult is not null) return validationResult;

                var result = await _authService.RefreshTokenAsync(refreshRequest);
                if (result == null)
                {
                    return new ApiResponse<RefreshTokenResponse>
                    {
                        Success = false,
                        Message = "Refresh token inválido o expirado.",
                        Data = null,
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                }
                return new ApiResponse<RefreshTokenResponse>
                {
                    Success = true,
                    Message = "Token refrescado correctamente.",
                    Data = result,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al refrescar el token.");
                return new ApiResponse<RefreshTokenResponse>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
