using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.UninstallOption.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using FitGymApp.Utils;

namespace FitGymApp.Functions.UninstallOptionFunction;

public class UpdateUninstallOptionFunction
{
    private readonly ILogger<UpdateUninstallOptionFunction> _logger;
    private readonly IUninstallOptionService _service;

    public UpdateUninstallOptionFunction(ILogger<UpdateUninstallOptionFunction> logger, IUninstallOptionService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("UpdateUninstallOptionFunction")]
    public async Task<ApiResponse<Guid>> UpdateAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = "uninstalloption/update")] HttpRequest req)
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

        _logger.LogInformation("Procesando solicitud para actualizar un UninstallOption.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<UpdateUninstallOptionRequest>(requestBody);

            if (objRequest == null)
            {
                return new ApiResponse<Guid>
                {
                    Success = false,
                    Message = "El cuerpo de la solicitud no coincide con la estructura esperada.",
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            var validationContext = new ValidationContext(objRequest, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(objRequest, validationContext, validationResults, true);

            if (!isValid)
            {
                return new ApiResponse<Guid>
                {
                    Success = false,
                    Message = string.Join("; ", validationResults.Select(v => v.ErrorMessage)),
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            var result = _service.UpdateUninstallOption(objRequest);
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
            _logger.LogError(ex, "Error al actualizar UninstallOption.");
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
