using FitGymApp.Domain.DTO.Branch.Request;
using FitGymApp.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FitGymApp.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Utils;
using Microsoft.Azure.Functions.Worker.Http;

namespace FitGymApp.Functions.BranchFunction;

public class UpdateBranchFunction
{
    private readonly ILogger<UpdateBranchFunction> _logger;
    private readonly IBranchService _service;

    public UpdateBranchFunction(ILogger<UpdateBranchFunction> logger, IBranchService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("Branch_UpdateBranchFunction")]
    public async Task<HttpResponseData> UpdateAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = "branch/update")] HttpRequestData req)
    {
        var response = req.CreateResponse();
        if (!JwtValidator.ValidateJwt(req, out var error))
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

        _logger.LogInformation("Procesando solicitud para actualizar un Branch.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<UpdateBranchRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<UpdateBranchRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(validationResult);
                return response;
            }

            var result = await _service.UpdateBranchAsync(objRequest);
            if (!result.Success)
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                await response.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = result.Message,
                    Data = objRequest.Id,
                    StatusCode = StatusCodes.Status404NotFound
                });
                return response;
            }

            response.StatusCode = System.Net.HttpStatusCode.OK;
            await response.WriteAsJsonAsync(new ApiResponse<Guid>
            {
                Success = true,
                Message = result.Message,
                Data = objRequest.Id,
                StatusCode = StatusCodes.Status200OK
            });
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar Branch.");
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
}
