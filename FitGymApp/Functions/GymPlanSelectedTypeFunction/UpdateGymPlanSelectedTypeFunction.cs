using FitGymApp.Domain.DTO.GymPlanSelectedType.Request;
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
using Microsoft.AspNetCore.Mvc;

namespace FitGymApp.Functions.GymPlanSelectedTypeFunction;

public class UpdateGymPlanSelectedTypeFunction
{
    private readonly ILogger<UpdateGymPlanSelectedTypeFunction> _logger;
    private readonly IGymPlanSelectedTypeService _service;

    public UpdateGymPlanSelectedTypeFunction(ILogger<UpdateGymPlanSelectedTypeFunction> logger, IGymPlanSelectedTypeService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("GymPlanSelectedType_UpdateGymPlanSelectedTypeFunction")]
    public async Task<IActionResult> UpdateAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = "gymplanselectedtype/update")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error))
        {
            return new JsonResult(new ApiResponse<Guid>
            {
                Success = false,
                Message = error!,
                Data = default,
                StatusCode = StatusCodes.Status401Unauthorized
            });
        }

        _logger.LogInformation("Procesando solicitud para actualizar un GymPlanSelectedType.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<UpdateGymPlanSelectedTypeRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<UpdateGymPlanSelectedTypeRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null) return new JsonResult(validationResult);

            var result = await _service.UpdateGymPlanSelectedTypeAsync(objRequest);
            if (!result.Success)
            {
                return new JsonResult(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = objRequest.Id,
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            return new JsonResult(new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = objRequest.Id,
                StatusCode = StatusCodes.Status200OK
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar GymPlanSelectedType.");
            return new JsonResult(new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status400BadRequest
            });
        }
    }
}
