// ...existing code...
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.GymImage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Gymmetry.Utils;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace Gymmetry.Functions.GymImageFunction
{
    public class GetGymImageFunction
    {
        private readonly ILogger<GetGymImageFunction> _logger;
        private readonly IGymImageService _service;

        public GetGymImageFunction(ILogger<GetGymImageFunction> logger, IGymImageService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("GymImage_GetGymImageByIdFunction")]
        public async Task<HttpResponseData> GetByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "gymimage/{id:guid}")] HttpRequestData req,
            FunctionContext executionContext,
            Guid id)
        {
            var logger = executionContext.GetLogger("GymImage_GetGymImageByIdFunction");
            logger.LogInformation($"Consultando GymImage por Id: {id}");
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<GymImageResponse>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return unauthorizedResponse;
            }
            try
            {
                var result = await _service.GetGymImageByIdAsync(id);
                var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
                await response.WriteAsJsonAsync(new ApiResponse<GymImageResponse>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status404NotFound
                });
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al consultar GymImage por Id.");
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<GymImageResponse>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return errorResponse;
            }
        }

        [Function("GymImage_GetAllGymImagesFunction")]
        public async Task<HttpResponseData> GetAllAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "gymimages")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GymImage_GetAllGymImagesFunction");
            logger.LogInformation("Consultando todas las imágenes de gimnasio.");
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymImageResponse>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return unauthorizedResponse;
            }
            try
            {
                var result = await _service.GetAllGymImagesAsync();
                var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymImageResponse>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = result.Success ? StatusCodes.Status200OK : StatusCodes.Status404NotFound
                });
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al consultar todas las imágenes de gimnasio.");
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<IEnumerable<GymImageResponse>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return errorResponse;
            }
        }
    }
}
// ...existing code...
