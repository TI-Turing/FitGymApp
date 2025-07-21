using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.Module.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using FitGymApp.Utils;
using System.Net;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace FitGymApp.Functions.ModuleFunction;

public class UpdateModuleFunction
{
    private readonly ILogger<UpdateModuleFunction> _logger;
    private readonly IModuleService _service;

    public UpdateModuleFunction(ILogger<UpdateModuleFunction> logger, IModuleService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("Module_UpdateModuleFunction")]
    public async Task<HttpResponseData> UpdateAsync(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "module/update")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("Module_UpdateModuleFunction");
        logger.LogInformation("Procesando solicitud para actualizar un Module.");
        var invocationId = executionContext.InvocationId;

        try
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = error!,
                    Data = default,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return unauthorizedResponse;
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<UpdateModuleRequest>(requestBody);
            
            var validationResult = ModelValidator.ValidateModel<UpdateModuleRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
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

            if (objRequest != null)
            {
                objRequest.Ip = ip;
            }

            var result = await _service.UpdateModuleAsync(objRequest, userId, ip, invocationId);
            if (!result.Success)
            {
                var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
                await notFoundResponse.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = objRequest.Id,
                    StatusCode = StatusCodes.Status404NotFound
                });
                return notFoundResponse;
            }

            var successResponse = req.CreateResponse(HttpStatusCode.OK);
            await successResponse.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = objRequest.Id,
                StatusCode = StatusCodes.Status200OK
            });
            return successResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al actualizar Module.");
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status500InternalServerError
            });
            return errorResponse;
        }
    }
}
