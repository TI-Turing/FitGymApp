using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.User.Request;
using Gymmetry.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Gymmetry.Functions.UserFunctions;

public class PasswordUserFunction
{
    private readonly ILogger<PasswordUserFunction> _logger;
    private readonly IUserService _userService;

    public PasswordUserFunction(ILogger<PasswordUserFunction> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [Function("User_PasswordUserFunction")]
    public async Task<HttpResponseData> UpdatePasswordAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/password/update")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("User_PasswordUserFunction");
        logger.LogInformation("Processing user password change request.");
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
            await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<bool>
            {
                Success = false,
                Message = error!,
                Data = default,
                StatusCode = StatusCodes.Status401Unauthorized
            });
            return unauthorizedResponse;
        }
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var objRequest = JsonConvert.DeserializeObject<PasswordUserRequest>(requestBody);

        // Obtener el token del header Authorization si no viene en el body
        if (string.IsNullOrWhiteSpace(objRequest?.Token))
        {
            if (req.Headers.TryGetValues("Authorization", out var authHeaders))
            {
                var bearer = authHeaders.FirstOrDefault();
                if (!string.IsNullOrEmpty(bearer) && bearer.StartsWith("Bearer ", System.StringComparison.OrdinalIgnoreCase))
                {
                    objRequest.Token = bearer.Substring("Bearer ".Length).Trim();
                }
            }
        }

        var result = await _userService.UpdatePasswordAsync(objRequest);
        var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        await response.WriteAsJsonAsync(result);
        return response;
    }
}
