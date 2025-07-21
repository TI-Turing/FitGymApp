using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.GymPlanSelectedType.Request;
using Newtonsoft.Json;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using FitGymApp.Utils;
using Microsoft.AspNetCore.Mvc;

namespace FitGymApp.Functions.GymPlanSelectedTypeFunction;

public class AddGymPlanSelectedTypeFunction
{
    private readonly ILogger<AddGymPlanSelectedTypeFunction> _logger;
    private readonly IGymPlanSelectedTypeService _service;

    public AddGymPlanSelectedTypeFunction(ILogger<AddGymPlanSelectedTypeFunction> logger, IGymPlanSelectedTypeService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("GymPlanSelectedType_AddGymPlanSelectedTypeFunction")]
    public async Task<IActionResult> AddAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "gymplanselectedtype/add")] HttpRequest req)
    {
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            return new JsonResult(new ApiResponse<Guid>
            {
                Success = false,
                Message = error!,
                Data = default,
                StatusCode = StatusCodes.Status401Unauthorized
            });
        }

        _logger.LogInformation("Procesando solicitud para agregar un GymPlanSelectedType.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddGymPlanSelectedTypeRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<AddGymPlanSelectedTypeRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null) return new JsonResult(validationResult);

            var result = await _service.CreateGymPlanSelectedTypeAsync(objRequest);
            if (!result.Success)
            {
                return new JsonResult(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
            return new JsonResult(new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = result.Data != null ? result.Data.Id : default,
                StatusCode = StatusCodes.Status200OK
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar GymPlanSelectedType.");
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
