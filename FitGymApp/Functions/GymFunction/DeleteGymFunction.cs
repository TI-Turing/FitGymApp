using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using FitGymApp.Utils;
using Microsoft.AspNetCore.Http;

namespace FitGymApp.Functions.GymFunction
{
    public class DeleteGymFunction
    {
        private readonly ILogger<DeleteGymFunction> _logger;
        private readonly IGymService _service;

        public DeleteGymFunction(ILogger<DeleteGymFunction> logger, IGymService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Gym_DeleteGymFunction")]
        public async Task<HttpResponseData> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "gym/{id:guid}")] HttpRequestData req,
            FunctionContext executionContext,
            Guid id)
        {
            var logger = executionContext.GetLogger("Gym_DeleteGymFunction");
            logger.LogInformation($"Procesando solicitud de borrado para Gym {id}");
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
            try
            {
                var result = await _service.DeleteGymAsync(id);
                var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
                await response.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Success ? id : default,
                    StatusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status404NotFound
                });
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar Gym.");
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
