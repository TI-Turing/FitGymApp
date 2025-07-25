using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Domain.DTO.Gym.Request;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Gymmetry.Domain.DTO;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using Gymmetry.Utils;

namespace Gymmetry.Functions.GymFunction;

public class AddGymFunction
{
    private readonly ILogger<AddGymFunction> _logger;
    private readonly IGymService _service;

    public AddGymFunction(ILogger<AddGymFunction> logger, IGymService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("Gym_AddGymFunction")]
    public async Task<HttpResponseData> AddAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "gym/add")] HttpRequestData req,
        FunctionContext executionContext)
    {

        var logger = executionContext.GetLogger("AddGymFunction");
        logger.LogInformation("Procesando solicitud para agregar un Gym.");

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
        var objRequest = JsonConvert.DeserializeObject<AddGymRequest>(requestBody);
        var validationResult = ModelValidator.ValidateModel<AddGymRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
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

        try
        {
            var result = await _service.CreateGymAsync(objRequest);
            if (!result.Success)
            {
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return errorResponse;
            }

            var successResponse = req.CreateResponse(HttpStatusCode.Created);
            await successResponse.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = result.Data != null ? result.Data.Id : default,
                StatusCode = StatusCodes.Status200OK
            });
            return successResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al agregar Gym.");
            var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status400BadRequest
            });
            return errorResponse;
        }
    }
}
