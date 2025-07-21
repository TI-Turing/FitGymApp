using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.PhysicalAssessment.Request;
using Newtonsoft.Json;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FitGymApp.Utils;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace FitGymApp.Functions.PhysicalAssessmentFunction
{
    public class AddPhysicalAssessmentFunction
    {
        private readonly ILogger<AddPhysicalAssessmentFunction> _logger;
        private readonly IPhysicalAssessmentService _service;

        public AddPhysicalAssessmentFunction(ILogger<AddPhysicalAssessmentFunction> logger, IPhysicalAssessmentService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("PhysicalAssessment_AddPhysicalAssessmentFunction")]
        public async Task<HttpResponseData> AddAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "physicalassessment/add")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("PhysicalAssessment_AddPhysicalAssessmentFunction");
            logger.LogInformation("Procesando solicitud para agregar un PhysicalAssessment.");
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
                var objRequest = JsonConvert.DeserializeObject<AddPhysicalAssessmentRequest>(requestBody);
                var validationResult = ModelValidator.ValidateModel<AddPhysicalAssessmentRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
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
                var result = await _service.CreatePhysicalAssessmentAsync(objRequest);
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
                logger.LogError(ex, "Error al agregar PhysicalAssessment.");
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
