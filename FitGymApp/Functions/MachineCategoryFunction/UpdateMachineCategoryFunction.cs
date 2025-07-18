using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.MachineCategory.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FitGymApp.Utils;
using System.Linq;

namespace FitGymApp.Functions.MachineCategoryFunction;

public class UpdateMachineCategoryFunction
{
    private readonly ILogger<UpdateMachineCategoryFunction> _logger;
    private readonly IMachineCategoryService _service;

    public UpdateMachineCategoryFunction(ILogger<UpdateMachineCategoryFunction> logger, IMachineCategoryService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("MachineCategory_UpdateMachineCategoryFunction")]
    public async Task<ApiResponse<Guid>> UpdateAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = "machinecategory/update")] HttpRequest req)
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

        _logger.LogInformation("Procesando solicitud para actualizar un MachineCategory.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<UpdateMachineCategoryRequest>(requestBody);

            var validationResult = ModelValidator.ValidateModel<UpdateMachineCategoryRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null) return validationResult;

            var result = await _service.UpdateMachineCategoryAsync(objRequest);
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
            _logger.LogError(ex, "Error al actualizar MachineCategory.");
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
