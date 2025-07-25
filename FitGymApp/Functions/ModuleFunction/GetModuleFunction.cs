using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Gymmetry.Utils;

namespace Gymmetry.Functions.ModuleFunction;

public class GetModuleFunction
{
    private readonly ILogger<GetModuleFunction> _logger;
    private readonly IModuleService _service;

    public GetModuleFunction(ILogger<GetModuleFunction> logger, IModuleService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("Module_GetModuleByIdFunction")]
    public async Task<ApiResponse<Module>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "module/{id:guid}")] HttpRequest req, Guid id)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new ApiResponse<Module>
            {
                Success = false,
                Message = error!,
                Data = null,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        _logger.LogInformation($"Consultando Module por Id: {id}");
        try
        {
            var result = await _service.GetModuleByIdAsync(id);
            if (!result.Success)
            {
                return new ApiResponse<Module>
                {
                    Success = false,
                    Message = result.Message,
                    Data = null,
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            return new ApiResponse<Module>
            {
                Success = true,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al consultar Module por Id.");
            return new ApiResponse<Module>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }

    [Function("Module_GetAllModulesFunction")]
    public async Task<ApiResponse<IEnumerable<Module>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "modules")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new ApiResponse<IEnumerable<Module>>
            {
                Success = false,
                Message = error!,
                Data = null,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        _logger.LogInformation("Consultando todos los Modules activos.");
        try
        {
            var result = await _service.GetAllModulesAsync();
            return new ApiResponse<IEnumerable<Module>>
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al consultar todos los Modules.");
            return new ApiResponse<IEnumerable<Module>>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }

    [Function("Module_FindModulesByFieldsFunction")]
    public async Task<ApiResponse<IEnumerable<Module>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "modules/find")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new ApiResponse<IEnumerable<Module>>
            {
                Success = false,
                Message = error!,
                Data = null,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        _logger.LogInformation("Consultando Modules por filtros dinámicos.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);

            if (filters == null || filters.Count == 0)
            {
                return new ApiResponse<IEnumerable<Module>>
                {
                    Success = false,
                    Message = "No se proporcionaron filtros válidos.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            var result = await _service.FindModulesByFieldsAsync(filters);
            return new ApiResponse<IEnumerable<Module>>
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al consultar Modules por filtros.");
            return new ApiResponse<IEnumerable<Module>>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
