using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FitGymApp.Functions.AccessMethodTypeFunction;

public class DeleteAccessMethodTypeFunction
{
    private readonly ILogger<DeleteAccessMethodTypeFunction> _logger;
    private readonly IAccessMethodTypeService _service;

    public DeleteAccessMethodTypeFunction(ILogger<DeleteAccessMethodTypeFunction> logger, IAccessMethodTypeService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("AccessMethodType_DeleteAccessMethodTypeFunction")]
    public async Task<ApiResponse<Guid>> RunAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "accessmethodtype/{id:guid}")] HttpRequest req, Guid id)
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

        _logger.LogInformation($"Procesando solicitud de borrado para AccessMethodType {id}");
        try
        {
            var result = await _service.DeleteAccessMethodTypeAsync(id);
            if (!result.Success)
            {
                return new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            return new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = id,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar AccessMethodType.");
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
