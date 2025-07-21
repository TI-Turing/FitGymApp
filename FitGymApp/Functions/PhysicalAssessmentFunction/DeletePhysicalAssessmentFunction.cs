using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Utils;
using System.Net;
using Newtonsoft.Json;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace FitGymApp.Functions.PhysicalAssessmentFunction
{
    public class DeletePhysicalAssessmentFunction
    {
        private readonly ILogger<DeletePhysicalAssessmentFunction> _logger;
        private readonly IPhysicalAssessmentService _service;

        public DeletePhysicalAssessmentFunction(ILogger<DeletePhysicalAssessmentFunction> logger, IPhysicalAssessmentService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("PhysicalAssessment_DeletePhysicalAssessmentFunction")]
        public async Task<HttpResponseData> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "physicalassessment/{id:guid}")] HttpRequestData req,
            FunctionContext executionContext,
            Guid id)
        {
            var logger = executionContext.GetLogger("PhysicalAssessment_DeletePhysicalAssessmentFunction");
            logger.LogInformation($"Procesando solicitud de borrado para PhysicalAssessment {id}");
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
                string? ip = req.Headers.TryGetValues("X-Forwarded-For", out var values) ? values.FirstOrDefault()?.Split(',')[0]?.Trim()
                    : req.Headers.TryGetValues("X-Original-For", out var originalForValues) ? originalForValues.FirstOrDefault()?.Split(':')[0]?.Trim()
                    : req.Headers.TryGetValues("REMOTE_ADDR", out var remoteValues) ? remoteValues.FirstOrDefault()
                    : null;

                var result = await _service.DeletePhysicalAssessmentAsync(id);
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
                logger.LogError(ex, "Error al eliminar PhysicalAssessment.");
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
