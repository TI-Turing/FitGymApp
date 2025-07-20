using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Domain.DTO.Branch.Request;
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

namespace FitGymApp.Functions.BranchFunction;

public class AddBranchFunction
{
    private readonly ILogger<AddBranchFunction> _logger;
    private readonly IBranchService _service;

    public AddBranchFunction(ILogger<AddBranchFunction> logger, IBranchService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("Branch_AddBranchFunction")]
    public async Task<HttpResponseData> AddAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "branch/add")] HttpRequestData req)
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

        _logger.LogInformation("Procesando solicitud para agregar un Branch.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddBranchRequest>(requestBody);
            var validationResult = ModelValidator.ValidateModel<AddBranchRequest, Guid>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(validationResult);
                return response;
            }

            var result = await _service.CreateBranchAsync(objRequest);
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
            _logger.LogError(ex, "Error al agregar Branch.");
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
