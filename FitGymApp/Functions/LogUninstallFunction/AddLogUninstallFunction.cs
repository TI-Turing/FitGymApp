using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Gymmetry.Domain.DTO.LogUninstall.Request;
using Newtonsoft.Json;
using Gymmetry.Domain.DTO;
using Gymmetry.Application.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using Gymmetry.Utils;

namespace Gymmetry.Functions.LogUninstallFunction;

public class AddLogUninstallFunction
{
    private readonly ILogger<AddLogUninstallFunction> _logger;
    private readonly ILogUninstallService _service;

    public AddLogUninstallFunction(ILogger<AddLogUninstallFunction> logger, ILogUninstallService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("LogUninstall_AddLogUninstallFunction")]
    public async Task<ApiResponse<Guid>> AddAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "loguninstall/add")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new ApiResponse<Guid>
            {
                Success = false,
                Message = error!,
                Data = default,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        _logger.LogInformation("Procesando solicitud para agregar un LogUninstall.");

        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddLogUninstallRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<AddLogUninstallRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null) return validationResult;

            var result = await _service.CreateLogUninstallAsync(objRequest);
            if (!result.Success)
            {
                return new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            return new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = result.Data != null ? result.Data.Id : default,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar LogUninstall.");
            return new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
