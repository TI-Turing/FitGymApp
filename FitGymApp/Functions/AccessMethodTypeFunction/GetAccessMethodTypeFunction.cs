using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Gymmetry.Utils;
using System.Net;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace Gymmetry.Functions.AccessMethodTypeFunction;

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
    public async Task<HttpResponseData> GetByIdAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "accessmethodtype/{id:guid}")] HttpRequestData req,
        FunctionContext executionContext,
        Guid id)
    {
        var logger = executionContext.GetLogger("AccessMethodType_GetAccessMethodTypeByIdFunction");
        logger.LogInformation($"Consultando AccessMethodType por Id: {id}");
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
            await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<AccessMethodType>
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
            var result = await _service.GetAccessMethodTypeByIdAsync(id);
            if (!result.Success)
            {
                var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
                await notFoundResponse.WriteAsJsonAsync(new ApiResponse<AccessMethodType>
                {
                    Success = false,
                    Message = result.Message,
                    Data = null,
                    StatusCode = StatusCodes.Status404NotFound
                });
                return notFoundResponse;
            }
            var successResponse = req.CreateResponse(HttpStatusCode.OK);
            await successResponse.WriteAsJsonAsync(new ApiResponse<AccessMethodType>
            {
                Success = true,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            });
            return successResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al consultar AccessMethodType por Id.");
            var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<AccessMethodType>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            });
            return errorResponse;
        }
    }

    [Function("AccessMethodType_GetAllAccessMethodTypesFunction")]
    public async Task<HttpResponseData> GetAllAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "accessmethodtypes")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("AccessMethodType_GetAllAccessMethodTypesFunction");
        logger.LogInformation("Consultando todos los AccessMethodTypes activos.");
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
            await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<AccessMethodType>>
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
            var result = await _service.GetAllAccessMethodTypesAsync();
            var successResponse = req.CreateResponse(HttpStatusCode.OK);
            await successResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            });
            return successResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al consultar todos los AccessMethodTypes.");
            var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            });
            return errorResponse;
        }
    }

    [Function("AccessMethodType_FindAccessMethodTypesByFieldsFunction")]
    public async Task<HttpResponseData> FindByFieldsAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "accessmethodtypes/find")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("AccessMethodType_FindAccessMethodTypesByFieldsFunction");
        logger.LogInformation("Consultando AccessMethodTypes por filtros dinámicos.");
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
            await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<AccessMethodType>>
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
            var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
            if (filters == null || filters.Count == 0)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<AccessMethodType>>
                {
                    Success = false,
                    Message = "No se proporcionaron filtros válidos.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return badResponse;
            }
            var result = await _service.FindAccessMethodTypesByFieldsAsync(filters);
            var successResponse = req.CreateResponse(HttpStatusCode.OK);
            await successResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<AccessMethodType>>
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data,
                StatusCode = StatusCodes.Status200OK
            });
            return successResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al consultar AccessMethodTypes por filtros.");
            var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<AccessMethodType>>
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
