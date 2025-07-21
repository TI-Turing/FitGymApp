using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.DTO.AccessMethodType.Request;
using FitGymApp.Domain.Models;
using FitGymApp.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FitGymApp.Functions.AccessMethodTypeFunction;

public class AddAccessMethodTypeFunction
{
    private readonly ILogger<AddAccessMethodTypeFunction> _logger;
    private readonly IAccessMethodTypeService _service;

    public AddAccessMethodTypeFunction(ILogger<AddAccessMethodTypeFunction> logger, IAccessMethodTypeService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("AccessMethodType_AddAccessMethodTypeFunction")]
    public async Task<ApiResponse<Guid>> AddAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "accessmethodtype/add")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new ApiResponse<Guid>
            {
                Success = false,
                Message = error!,
                Data = default,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        _logger.LogInformation("Procesando solicitud para agregar un AccessMethodType.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddAccessMethodTypeRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<AddAccessMethodTypeRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null) return validationResult;

            var result = await _service.CreateAccessMethodTypeAsync(objRequest);
            if (!result.Success)
            {
                return new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            return new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = result.Data != null ? result.Data.Id : default,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Error al agregar AccessMethodType.");
            return new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
