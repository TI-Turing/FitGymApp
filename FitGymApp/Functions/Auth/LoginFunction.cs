using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.Auth.Request;
using Gymmetry.Domain.DTO.Auth.Response;
using Gymmetry.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Gymmetry.Functions.Auth
{
    public class Auth_LoginFunction
    {
        private readonly ILogger<Auth_LoginFunction> _logger;
        private readonly IAuthService _authService;

        public Auth_LoginFunction(ILogger<Auth_LoginFunction> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [Function("Auth_LoginFunction")]
        public async Task<HttpResponseData> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "auth/login")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Auth_LoginFunction");
            logger.LogInformation("Procesando login de usuario.");
            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var loginRequest = JsonConvert.DeserializeObject<LoginRequest>(requestBody);
                var validationResult = ModelValidator.ValidateModel<LoginRequest, LoginResponse>(loginRequest, StatusCodes.Status400BadRequest);
                if (validationResult is not null)
                {
                    var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badResponse.WriteAsJsonAsync(validationResult);
                    return badResponse;
                }

                string? ip = req.Headers.TryGetValues("X-Forwarded-For", out var values) ? values.FirstOrDefault()?.Split(',')[0]?.Trim()
                : req.Headers.TryGetValues("X-Original-For", out var originalForValues) ? originalForValues.FirstOrDefault()?.Split(':')[0]?.Trim()
                : req.Headers.TryGetValues("REMOTE_ADDR", out var remoteValues) ? remoteValues.FirstOrDefault()
                : null;

                var result = await _authService.LoginAsync(loginRequest, ip);
                if (result == null)
                {
                    var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                    await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<LoginResponse>
                    {
                        Success = false,
                        Message = "Credenciales incorrectas o usuario inactivo.",
                        Data = null,
                        StatusCode = StatusCodes.Status401Unauthorized
                    });
                    return unauthorizedResponse;
                }
                var successResponse = req.CreateResponse(HttpStatusCode.OK);
                await successResponse.WriteAsJsonAsync(new ApiResponse<LoginResponse>
                {
                    Success = true,
                    Message = "Login exitoso.",
                    Data = result,
                    StatusCode = StatusCodes.Status200OK
                });
                return successResponse;
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "Error en login.");
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<LoginResponse>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return errorResponse;
            }
        }
    }
}
