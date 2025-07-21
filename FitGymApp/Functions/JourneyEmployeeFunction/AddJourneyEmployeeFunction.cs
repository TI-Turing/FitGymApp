using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.JourneyEmployee.Request;
using Newtonsoft.Json;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FitGymApp.Utils;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace FitGymApp.Functions.JourneyEmployeeFunction;

public class AddJourneyEmployeeFunction
{
    private readonly ILogger<AddJourneyEmployeeFunction> _logger;
    private readonly IJourneyEmployeeService _service;

    public AddJourneyEmployeeFunction(ILogger<AddJourneyEmployeeFunction> logger, IJourneyEmployeeService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("JourneyEmployee_AddJourneyEmployeeFunction")]
    public async Task<HttpResponseData> AddAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "journeyemployee/add")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("JourneyEmployee_AddJourneyEmployeeFunction");
        logger.LogInformation("Procesando solicitud para agregar un JourneyEmployee.");
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
            var objRequest = JsonConvert.DeserializeObject<AddJourneyEmployeeRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<AddJourneyEmployeeRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(validationResult);
                return badResponse;
            }
            var result = await _service.CreateJourneyEmployeeAsync(objRequest);
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
                Data = result.Data?.Id ?? default,
                StatusCode = StatusCodes.Status200OK
            });
            return successResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al agregar JourneyEmployee.");
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
