using Microsoft.AspNetCore.Http;
using Gymmetry.Domain.DTO.GymPlanSelected.Request;
using Gymmetry.Domain.DTO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Gymmetry.Application.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Utils;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace Gymmetry.Functions.GymPlanSelectedFunction;

public class UpdateGymPlanSelectedFunction
{
    private readonly ILogger<UpdateGymPlanSelectedFunction> _logger;
    private readonly IGymPlanSelectedService _service;

    public UpdateGymPlanSelectedFunction(ILogger<UpdateGymPlanSelectedFunction> logger, IGymPlanSelectedService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("GymPlanSelected_UpdateGymPlanSelectedFunction")]
    public async Task<HttpResponseData> UpdateAsync(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "gymplanselected/update")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("GymPlanSelected_UpdateGymPlanSelectedFunction");
        logger.LogInformation("Procesando solicitud para actualizar un GymPlanSelected.");
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
            var objRequest = JsonConvert.DeserializeObject<UpdateGymPlanSelectedRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<UpdateGymPlanSelectedRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
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
            var result = await _service.UpdateGymPlanSelectedAsync(objRequest, userId, ip, invocationId);
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
            logger.LogError(ex, "Error al actualizar GymPlanSelected.");
            var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurri� un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status400BadRequest
            });
            return errorResponse;
        }
    }
}
