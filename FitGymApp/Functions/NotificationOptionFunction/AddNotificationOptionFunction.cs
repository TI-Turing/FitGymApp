using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.NotificationOption.Request;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FitGymApp.Domain.DTO;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using FitGymApp.Utils;

namespace FitGymApp.Functions.NotificationOptionFunction;

public class AddNotificationOptionFunction
{
    private readonly ILogger<AddNotificationOptionFunction> _logger;
    private readonly INotificationOptionService _service;

    public AddNotificationOptionFunction(ILogger<AddNotificationOptionFunction> logger, INotificationOptionService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("NotificationOption_AddNotificationOptionFunction")]
    public async Task<ApiResponse<Guid>> AddAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "notificationoption/add")] HttpRequest req)
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

        _logger.LogInformation("Procesando solicitud para agregar un NotificationOption.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddNotificationOptionRequest>(requestBody);

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

            var result = await _service.CreateNotificationOptionAsync(objRequest);
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
            _logger.LogError(ex, "Error al agregar NotificationOption.");
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
