using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Gymmetry.Domain.DTO.GymPlanSelectedModule.Request;
using Newtonsoft.Json;
using Gymmetry.Domain.DTO;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Gymmetry.Utils;

namespace Gymmetry.Functions.GymPlanSelectedModuleFunction;

public class AddGymPlanSelectedModuleFunction
{
    private readonly ILogger<AddGymPlanSelectedModuleFunction> _logger;
    private readonly IGymPlanSelectedModuleService _service;

    public AddGymPlanSelectedModuleFunction(ILogger<AddGymPlanSelectedModuleFunction> logger, IGymPlanSelectedModuleService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("GymPlanSelectedModule_AddGymPlanSelectedModuleFunction")]
    public async Task<ApiResponse<Guid>> AddAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "gymplanselectedmodule/add")] HttpRequest req)
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

        _logger.LogInformation("Procesando solicitud para agregar un GymPlanSelectedModule.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddGymPlanSelectedModuleRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<AddGymPlanSelectedModuleRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null) return validationResult;

            var result = await _service.CreateGymPlanSelectedModuleAsync(objRequest);
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar GymPlanSelectedModule.");
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
