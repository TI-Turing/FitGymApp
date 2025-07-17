using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.GymPlanSelected.Request;
using Newtonsoft.Json;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FitGymApp.Utils;

namespace FitGymApp.Functions.GymPlanSelectedFunction;

public class AddGymPlanSelectedFunction
{
    private readonly ILogger<AddGymPlanSelectedFunction> _logger;
    private readonly IGymPlanSelectedService _service;

    public AddGymPlanSelectedFunction(ILogger<AddGymPlanSelectedFunction> logger, IGymPlanSelectedService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("GymPlanSelected_AddGymPlanSelectedFunction")]
    public async Task<HttpResponseData> AddAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "gymplanselected/add")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("GymPlanSelected_AddGymPlanSelectedFunction");
        logger.LogInformation("Procesando solicitud para agregar un GymPlanSelected.");
        try
        {
            if (!JwtValidator.ValidateJwt(req, out var error))
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
            var objRequest = JsonConvert.DeserializeObject<AddGymPlanSelectedRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<AddGymPlanSelectedRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(validationResult);
                return badResponse;
            }
            var result = await _service.CreateGymPlanSelectedAsync(objRequest);
            if (!result.Success)
            {
                var errorResponse = req.CreateResponse(HttpStatusCode.UnprocessableEntity);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status422UnprocessableEntity
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
            logger.LogError(ex, "Error al agregar GymPlanSelected.");
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurrió un error inesperado al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status500InternalServerError
            });
            return errorResponse;
        }
    }
}
