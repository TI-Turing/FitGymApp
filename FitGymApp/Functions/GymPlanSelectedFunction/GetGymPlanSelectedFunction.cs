using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Gymmetry.Utils;

namespace Gymmetry.Functions.GymPlanSelectedFunction
{
    public class GetGymPlanSelectedFunction
    {
        private readonly ILogger<GetGymPlanSelectedFunction> _logger;
        private readonly IGymPlanSelectedService _service;

        public GetGymPlanSelectedFunction(ILogger<GetGymPlanSelectedFunction> logger, IGymPlanSelectedService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("GymPlanSelected_GetGymPlanSelectedByIdFunction")]
        public async Task<HttpResponseData> GetByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "gymplanselected/{id:guid}")] HttpRequestData req,
            FunctionContext executionContext,
            Guid id)
        {
            var logger = executionContext.GetLogger("GymPlanSelected_GetGymPlanSelectedByIdFunction");
            logger.LogInformation($"Consultando GymPlanSelected por Id: {id}");
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApplicationResponse<GymPlanSelected>
                {
                    Success = false,
                    Message = error!,
                    Data = null
                });
                return unauthorizedResponse;
            }
            try
            {
                var result = await _service.GetGymPlanSelectedByIdAsync(id);
                if (!result.Success)
                {
                    var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
                    await notFoundResponse.WriteAsJsonAsync(new ApplicationResponse<GymPlanSelected>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null
                    });
                    return notFoundResponse;
                }
                var successResponse = req.CreateResponse(HttpStatusCode.OK);
                await successResponse.WriteAsJsonAsync(new ApplicationResponse<GymPlanSelected>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data
                });
                return successResponse;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al consultar GymPlanSelected por Id.");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteAsJsonAsync(new ApplicationResponse<GymPlanSelected>
                {
                    Success = false,
                    Message = "Ocurrió un error inesperado al procesar la solicitud.",
                    Data = null
                });
                return errorResponse;
            }
        }

        [Function("GymPlanSelected_GetAllGymPlanSelectedsFunction")]
        public async Task<HttpResponseData> GetAllAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "gymplanselecteds")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GymPlanSelected_GetAllGymPlanSelectedsFunction");
            logger.LogInformation("Consultando todos los GymPlanSelecteds activos.");
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = false,
                    Message = error!,
                    Data = null
                });
                return unauthorizedResponse;
            }
            try
            {
                var result = await _service.GetAllGymPlanSelectedsAsync();
                var successResponse = req.CreateResponse(HttpStatusCode.OK);
                await successResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data
                });
                return successResponse;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al consultar todos los GymPlanSelecteds.");
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null
                });
                return errorResponse;
            }
        }

        [Function("GymPlanSelected_FindGymPlanSelectedsByFieldsFunction")]
        public async Task<HttpResponseData> FindByFieldsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "gymplanselecteds/find")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GymPlanSelected_FindGymPlanSelectedsByFieldsFunction");
            logger.LogInformation("Consultando GymPlanSelecteds por filtros dinámicos.");
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = false,
                    Message = error!,
                    Data = null
                });
                return unauthorizedResponse;
            }
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymPlanSelected>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null
                    });
                    return badResponse;
                }
                var result = await _service.FindGymPlanSelectedsByFieldsAsync(filters);
                var successResponse = req.CreateResponse(HttpStatusCode.OK);
                await successResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data
                });
                return successResponse;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al consultar GymPlanSelecteds por filtros.");
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymPlanSelected>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null
                });
                return errorResponse;
            }
        }
    }
}
