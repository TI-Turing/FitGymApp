using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Gymmetry.Utils;

namespace Gymmetry.Functions.MachineFunction
{
    public class GetMachineFunction
    {
        private readonly ILogger<GetMachineFunction> _logger;
        private readonly IMachineService _service;

        public GetMachineFunction(ILogger<GetMachineFunction> logger, IMachineService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Machine_GetMachineByIdFunction")]
        public async Task<HttpResponseData> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "machine/{id:guid}")] HttpRequestData req, Guid id)
        {
            var response = req.CreateResponse();
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                await response.WriteAsJsonAsync(new ApiResponse<Machine>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return response;
            }
            _logger.LogInformation($"Consultando Machine por Id: {id}");
            try
            {
                var result = await _service.GetMachineByIdAsync(id);
                if (!result.Success)
                {
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    await response.WriteAsJsonAsync(new ApiResponse<Machine>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    });
                    return response;
                }

                response.StatusCode = System.Net.HttpStatusCode.OK;
                await response.WriteAsJsonAsync(new ApiResponse<Machine>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                });
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar Machine por Id.");
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(new ApiResponse<Machine>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return response;
            }
        }

        [Function("Machine_GetAllMachinesFunction")]
        public async Task<HttpResponseData> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "machines")] HttpRequestData req)
        {
            var response = req.CreateResponse();
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Machine>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return response;
            }
            _logger.LogInformation("Consultando todas las Machines activas.");
            try
            {
                var result = await _service.GetAllMachinesAsync();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Machine>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                });
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todas las Machines.");
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Machine>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return response;
            }
        }

        [Function("Machine_FindMachinesByFieldsFunction")]
        public async Task<HttpResponseData> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "machines/find")] HttpRequestData req)
        {
            var response = req.CreateResponse();
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Machine>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return response;
            }
            _logger.LogInformation("Consultando Machines por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Machine>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    });
                    return response;
                }
                var result = await _service.FindMachinesByFieldsAsync(filters);
                response.StatusCode = System.Net.HttpStatusCode.OK;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Machine>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                });
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar Machines por filtros.");
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Machine>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return response;
            }
        }
    }
}
