using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.Gym.Request;
using Gymmetry.Domain.DTO.Gym.Response;
using Gymmetry.Utils;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace Gymmetry.Functions.GymFunction;

public class UtilsGymFunction
{
    private readonly ILogger<UtilsGymFunction> _logger;
    private readonly IGymService _gymService;

    public UtilsGymFunction(ILogger<UtilsGymFunction> logger, IGymService gymService)
    {
        _logger = logger;
        _gymService = gymService;
    }

    [Function("Gym_GenerateQrFunction")]
    public async Task<HttpResponseData> GenerateQrAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "gym/generate-qr")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("Gym_GenerateQrFunction");
        logger.LogInformation($"Procesando solicitud para generar QR de Gym");
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
        var requestDto = System.Text.Json.JsonSerializer.Deserialize<GenerateGymQrRequest>(requestBody);

        var validationResult = ModelValidator.ValidateModel<GenerateGymQrRequest, byte[]>(requestDto, StatusCodes.Status400BadRequest);
        if (validationResult is not null)
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteAsJsonAsync(validationResult);
            return badResponse;
        }

        var result = await _gymService.GenerateGymQrWithPlanTypeAsync(requestDto.GymId, requestDto.Url);
        if (!result.Success || result.Data == null)
        {
            var notFoundResponse = req.CreateResponse(HttpStatusCode.NotFound);
            await notFoundResponse.WriteStringAsync(result.Message ?? "No se pudo generar el QR y tipo de plan");
            return notFoundResponse;
        }

        var response = req.CreateResponse(HttpStatusCode.OK);

        var jsonOptions = new System.Text.Json.JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
            WriteIndented = true
        };

        var responseData = new
        {
            QrCode = result.Data.QrCode,
            result.Data.GymPlanSelectedType
        };

        var jsonString = System.Text.Json.JsonSerializer.Serialize(responseData, jsonOptions);
        await response.WriteStringAsync(jsonString);
        return response;
    }

    [Function("Gym_UploadLogoFunction")]
    public async Task<HttpResponseData> UploadLogoAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "gym/upload-logo")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("Gym_UploadLogoFunction");
        logger.LogInformation("Procesando solicitud para subir logo de Gym");
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
        // Obtener el header Content-Type correctamente
        string? contentType = req.Headers.TryGetValues("Content-Type", out var ctValues) ? ctValues.FirstOrDefault() : null;
        var boundary = MultipartRequestHelper.GetBoundary(contentType ?? string.Empty, 4096);
        var sections = await MultipartRequestHelper.GetSectionsAsync(req.Body, boundary);
        var gymId = Guid.Empty;
        byte[]? imageBytes = null;
        string? fileName = null;

        foreach (var section in sections)
        {
            if (section.Name == "GymId")
            {
                gymId = Guid.Parse(section.Value);
            }
            if (section.Name == "Logo" && section.FileContent != null)
            {
                imageBytes = section.FileContent;
                fileName = section.FileName;
                contentType = section.ContentType;
            }
        }
        if (gymId == Guid.Empty || imageBytes == null)
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteAsJsonAsync(new ApiResponse<string>
            {
                Success = false,
                Message = "GymId y Logo son requeridos.",
                Data = null,
                StatusCode = StatusCodes.Status400BadRequest
            });
            return badResponse;
        }
        var dto = new UploadGymLogoRequest
        {
            GymId = gymId,
            Image = imageBytes,
            FileName = fileName,
            ContentType = contentType
        };
        var result = await _gymService.UploadGymLogoAsync(dto);
        var response = req.CreateResponse(result.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        await response.WriteAsJsonAsync(result);
        return response;
    }
}
