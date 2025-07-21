using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using System;
using System.Net;
using System.Threading.Tasks;
using FitGymApp.Utils;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace FitGymApp.Functions.JourneyEmployeeFunction
{
    public class DeleteJourneyEmployeeFunction
    {
        private readonly ILogger<DeleteJourneyEmployeeFunction> _logger;
        private readonly IJourneyEmployeeService _service;

        public DeleteJourneyEmployeeFunction(ILogger<DeleteJourneyEmployeeFunction> logger, IJourneyEmployeeService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("JourneyEmployee_DeleteJourneyEmployeeFunction")]
        public async Task<HttpResponseData> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "journeyemployee/{id:guid}")] HttpRequestData req,
            FunctionContext executionContext,
            Guid id)
        {
            var logger = executionContext.GetLogger("JourneyEmployee_DeleteJourneyEmployeeFunction");
            logger.LogInformation($"Procesando solicitud de borrado para JourneyEmployee {id}");

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

            try
            {
                var result = await _service.DeleteJourneyEmployeeAsync(id);
                if (!result.Success)
                {
                    var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
                    await notFoundResponse.WriteAsJsonAsync(new ApiResponse<Guid>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = default,
                        StatusCode = StatusCodes.Status404NotFound
                    });
                    return notFoundResponse;
                }

                var successResponse = req.CreateResponse(HttpStatusCode.OK);
                await successResponse.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = true,
                    Message = result.Message,
                    Data = id,
                    StatusCode = StatusCodes.Status200OK
                });
                return successResponse;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar JourneyEmployee.");
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
}
