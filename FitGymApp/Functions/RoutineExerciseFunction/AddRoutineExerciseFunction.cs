using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.RoutineExercise.Request;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using FitGymApp.Utils;
using System.Net;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace FitGymApp.Functions.RoutineExerciseFunction;

public class AddRoutineExerciseFunction
{
    private readonly ILogger<AddRoutineExerciseFunction> _logger;
    private readonly IRoutineExerciseService _service;

    public AddRoutineExerciseFunction(ILogger<AddRoutineExerciseFunction> logger, IRoutineExerciseService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("RoutineExercise_AddRoutineExerciseFunction")]
    public async Task<HttpResponseData> AddAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "routineexercise/add")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("RoutineExercise_AddRoutineExerciseFunction");
        logger.LogInformation("Procesando solicitud para agregar un RoutineExercise.");
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
            var objRequest = JsonConvert.DeserializeObject<AddRoutineExerciseRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<AddRoutineExerciseRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
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
            var result = await _service.CreateRoutineExerciseAsync(objRequest);
            if (!result.Success)
            {
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return errorResponse;
            }
            var successResponse = req.CreateResponse(HttpStatusCode.OK);
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
            logger.LogError(ex, "Error al agregar RoutineExercise.");
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
