using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.MachineCategory.Request;
using Newtonsoft.Json;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FitGymApp.Utils;

namespace FitGymApp.Functions.MachineCategoryFunction;

public class AddMachineCategoryFunction
{
    private readonly ILogger<AddMachineCategoryFunction> _logger;
    private readonly IMachineCategoryService _service;

    public AddMachineCategoryFunction(ILogger<AddMachineCategoryFunction> logger, IMachineCategoryService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("MachineCategory_AddMachineCategoryFunction")]
    public async Task<ApiResponse<Guid>> AddAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "machinecategory/add")] HttpRequest req)
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

        _logger.LogInformation("Procesando solicitud para agregar un MachineCategory.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddMachineCategoryRequest>(requestBody);

            var validationResult = ModelValidator.ValidateModel<AddMachineCategoryRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null) return validationResult;

            var result = await _service.CreateMachineCategoryAsync(objRequest);
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
            _logger.LogError(ex, "Error al agregar MachineCategory.");
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
