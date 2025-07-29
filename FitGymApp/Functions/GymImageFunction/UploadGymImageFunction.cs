// ...existing code...
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Domain.DTO.GymImage;
using Gymmetry.Domain.DTO;
using Gymmetry.Application.Services.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Gymmetry.Utils;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace Gymmetry.Functions.GymImageFunction;

public class UploadGymImageFunction
{
    private readonly ILogger<UploadGymImageFunction> _logger;
    private readonly IGymImageService _service;

    public UploadGymImageFunction(ILogger<UploadGymImageFunction> logger, IGymImageService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("GymImage_UploadGymImageFunction")]
    public async Task<HttpResponseData> UploadAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "gymimage/upload")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("GymImage_UploadGymImageFunction");
        logger.LogInformation("Procesando solicitud para subir imagen de gimnasio.");
        try
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return unauthorizedResponse;
            }
            // Procesar multipart/form-data para obtener imagen y datos
            string? contentType = req.Headers.TryGetValues("Content-Type", out var ctValues) ? ctValues.FirstOrDefault() : null;
            var boundary = MultipartRequestHelper.GetBoundary(contentType ?? string.Empty, 4096);
            var sections = await MultipartRequestHelper.GetSectionsAsync(req.Body, boundary);
            Guid? gymId = null;
            Guid? branchId = null;
            byte[]? imageBytes = null;
            string? description = null;

            foreach (var section in sections)
            {
                if (section.Name == "GymId")
                    gymId = Guid.Parse(section.Value);
                if (section.Name == "BranchId")
                    branchId = Guid.Parse(section.Value);
                if (section.Name == "Image" && section.FileContent != null)
                    imageBytes = section.FileContent;
                if (section.Name == "Description")
                    description = section.Value;
            }
            if (imageBytes == null)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "La imagen es requerida.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return badResponse;
            }
            var dto = new UploadGymImageRequest
            {
                GymId = gymId,
                BranchId = branchId,
                Image = imageBytes,
                Description = description
            };
            var result = await _service.UploadGymImageAsync(dto);
            var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(result);
            return response;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al subir imagen de gimnasio.");
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<string>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = null,
                StatusCode = StatusCodes.Status500InternalServerError
            });
            return errorResponse;
        }
    }
}
// ...existing code...
