using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.Models;
using FitGymApp.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FitGymApp.Functions.AccessMethodTypeFunction;

public class GetAccessMethodTypeFunction
{
    private readonly ILogger<GetAccessMethodTypeFunction> _logger;
    private readonly IAccessMethodTypeService _service;

    public GetAccessMethodTypeFunction(ILogger<GetAccessMethodTypeFunction> logger, IAccessMethodTypeService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("AccessMethodType_GetAccessMethodTypeByIdFunction")]
    public async Task<ApiResponse<AccessMethodType>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "accessmethodtype/{id:guid}")] HttpRequest req, Guid id)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new ApiResponse<AccessMethodType>
            {
                Success = false,
                Message = error!,
                Data = null,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
        _logger.LogInformation($"Consultando AccessMethodType por Id: {id}");
        try
        {
            var result = await _service.GetAccessMethodTypeByIdAsync(id);
            if (!result.Success)
            {
                return new ApiResponse<AccessMethodType>
                {
                    Success = false,
                    Message = result.Message,
                    Data = null,
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            return new ApiResponse<AccessMethodType>
            {
                Success = true,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al consultar AccessMethodType por Id.");
            return new ApiResponse<AccessMethodType>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }

    [Function("AccessMethodType_GetAllAccessMethodTypesFunction")]
    public async Task<ApiResponse<IEnumerable<AccessMethodType>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "accessmethodtypes")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = false,
                Message = error!,
                Data = null,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
        _logger.LogInformation("Consultando todos los AccessMethodTypes activos.");
        try
        {
            var result = await _service.GetAllAccessMethodTypesAsync();
            return new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al consultar todos los AccessMethodTypes.");
            return new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }

    [Function("AccessMethodType_FindAccessMethodTypesByFieldsFunction")]
    public async Task<ApiResponse<IEnumerable<AccessMethodType>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "accessmethodtypes/find")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = false,
                Message = error!,
                Data = null,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
        _logger.LogInformation("Consultando AccessMethodTypes por filtros dinámicos.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var filters = JsonConvert.DeserializeObject<Dictionary<string, object>>(requestBody);
            if (filters == null || filters.Count == 0)
            {
                return new ApiResponse<IEnumerable<AccessMethodType>>
                {
                    Success = false,
                    Message = "No se proporcionaron filtros válidos.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var result = await _service.FindAccessMethodTypesByFieldsAsync(filters);
            return new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al consultar AccessMethodTypes por filtros.");
            return new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
