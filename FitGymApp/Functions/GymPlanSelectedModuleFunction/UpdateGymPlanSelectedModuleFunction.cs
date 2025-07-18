using FitGymApp.Domain.DTO.GymPlanSelectedModule.Request;
using FitGymApp.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FitGymApp.Application.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using FitGymApp.Utils;

namespace FitGymApp.Functions.GymPlanSelectedModuleFunction;

public class UpdateGymPlanSelectedModuleFunction
{
    private readonly ILogger<UpdateGymPlanSelectedModuleFunction> _logger;
    private readonly IGymPlanSelectedModuleService _service;

    public UpdateGymPlanSelectedModuleFunction(ILogger<UpdateGymPlanSelectedModuleFunction> logger, IGymPlanSelectedModuleService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("GymPlanSelectedModule_UpdateGymPlanSelectedModuleFunction")]
    public async Task<ApiResponse<Guid>> UpdateAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = "gymplanselectedmodule/update")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error))
        {
            return new ApiResponse<Guid>
            {
                Success = false,
                Message = error!,
                Data = default,
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        _logger.LogInformation("Procesando solicitud para actualizar un GymPlanSelectedModule.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<UpdateGymPlanSelectedModuleRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<UpdateGymPlanSelectedModuleRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null) return validationResult;

            var result = await _service.UpdateGymPlanSelectedModuleAsync(objRequest);
            if (!result.Success)
            {
                return new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = objRequest.Id,
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            return new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = objRequest.Id,
                StatusCode = StatusCodes.Status200OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar GymPlanSelectedModule.");
            return new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurri� un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
