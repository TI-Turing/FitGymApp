using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Domain.DTO.Machine.Request;
using Newtonsoft.Json;
using Gymmetry.Domain.DTO;
using Gymmetry.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Gymmetry.Utils;
using System.Linq;

namespace Gymmetry.Functions.MachineFunction;

public class AddMachineFunction
{
    private readonly ILogger<AddMachineFunction> _logger;
    private readonly IMachineService _service;

    public AddMachineFunction(ILogger<AddMachineFunction> logger, IMachineService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("Machine_AddMachineFunction")]
    public async Task<HttpResponseData> AddAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "machine/add")] HttpRequestData req)
    {
        var response = req.CreateResponse();
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            await response.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = false,
                Message = error!,
                Data = default,
                StatusCode = StatusCodes.Status401Unauthorized
            });
            return response;
        }

        _logger.LogInformation("Procesando solicitud para agregar una Machine.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddMachineRequest>(requestBody);

            var validationResult = ModelValidator.ValidateModel<AddMachineRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(validationResult);
                return response;
            }

            var result = await _service.CreateMachineAsync(objRequest);
            if (!result.Success)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return response;
            }

            response.StatusCode = System.Net.HttpStatusCode.OK;
            await response.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = result.Data != null ? result.Data.Id : default,
                StatusCode = StatusCodes.Status200OK
            });
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar Machine.");
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            await response.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status400BadRequest
            });
            return response;
        }
    }

    [Function("Machine_AddMachinesFunction")]
    public async Task<HttpResponseData> AddMachinesAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "machines/add")] HttpRequestData req)
    {
        var response = req.CreateResponse();
        if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
        {
            response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            await response.WriteAsJsonAsync(new ApiResponse<bool>
            {
                Success = false,
                Message = error!,
                Data = false,
                StatusCode = StatusCodes.Status401Unauthorized
            });
            return response;
        }

        _logger.LogInformation("Procesando solicitud para agregar múltiples máquinas.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var requests = JsonConvert.DeserializeObject<IEnumerable<AddMachineRequest>>(requestBody);

            var result = await _service.CreateMachinesAsync(requests);
            response.StatusCode = result.Success ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.BadRequest;
            await response.WriteAsJsonAsync(result);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar múltiples máquinas.");
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            await response.WriteAsJsonAsync(new ApiResponse<bool>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = false,
                StatusCode = StatusCodes.Status400BadRequest
            });
            return response;
        }
    }
}
