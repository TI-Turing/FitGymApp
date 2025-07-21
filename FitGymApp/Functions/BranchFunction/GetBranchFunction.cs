using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using FitGymApp.Utils;

namespace FitGymApp.Functions.BranchFunction
{
    public class GetBranchFunction
    {
        private readonly ILogger<GetBranchFunction> _logger;
        private readonly IBranchService _service;

        public GetBranchFunction(ILogger<GetBranchFunction> logger, IBranchService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Branch_GetBranchByIdFunction")]
        public async Task<HttpResponseData> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "branch/{id:guid}")] HttpRequestData req, Guid id)
        {
            var response = req.CreateResponse();
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                await response.WriteAsJsonAsync(new ApiResponse<Branch>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return response;
            }
            _logger.LogInformation($"Consultando Branch por Id: {id}");
            try
            {
                var result = await _service.GetBranchByIdAsync(id);
                if (!result.Success)
                {
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    await response.WriteAsJsonAsync(new ApiResponse<Branch>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    });
                    return response;
                }

                response.StatusCode = System.Net.HttpStatusCode.OK;
                await response.WriteAsJsonAsync(new ApiResponse<Branch>
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
                _logger.LogError(ex, "Error al consultar Branch por Id.");
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(new ApiResponse<Branch>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return response;
            }
        }

        [Function("Branch_GetAllBranchesFunction")]
        public async Task<HttpResponseData> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "branches")] HttpRequestData req)
        {
            var response = req.CreateResponse();
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Branch>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return response;
            }
            _logger.LogInformation("Consultando todos los Branches activos.");
            try
            {
                var result = await _service.GetAllBranchesAsync();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Branch>>
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
                _logger.LogError(ex, "Error al consultar todos los Branches.");
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Branch>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return response;
            }
        }

        [Function("Branch_FindBranchesByFieldsFunction")]
        public async Task<HttpResponseData> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "branches/find")] HttpRequestData req)
        {
            var response = req.CreateResponse();
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Branch>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return response;
            }
            _logger.LogInformation("Consultando Branches por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Branch>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    });
                    return response;
                }
                var result = await _service.FindBranchesByFieldsAsync(filters);
                response.StatusCode = System.Net.HttpStatusCode.OK;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Branch>>
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
                _logger.LogError(ex, "Error al consultar Branches por filtros.");
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(new ApiResponse<IEnumerable<Branch>>
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
