using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using System;
using System.Threading.Tasks;
using Gymmetry.Utils;

namespace Gymmetry.Functions.BranchFunction
{
    public class DeleteBranchFunction
    {
        private readonly ILogger<DeleteBranchFunction> _logger;
        private readonly IBranchService _service;

        public DeleteBranchFunction(ILogger<DeleteBranchFunction> logger, IBranchService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Branch_DeleteBranchFunction")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "branch/{id:guid}")] HttpRequestData req, Guid id)
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

            _logger.LogInformation($"Procesando solicitud de borrado para Branch {id}");
            try
            {
                var result = await _service.DeleteBranchAsync(id);
                if (!result.Success)
                {
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    await response.WriteAsJsonAsync(new ApiResponse<Guid>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = default,
                        StatusCode = StatusCodes.Status404NotFound
                    });
                    return response;
                }

                response.StatusCode = System.Net.HttpStatusCode.OK;
                await response.WriteAsJsonAsync(new ApiResponse<Guid>
                {
                    Success = true,
                    Message = result.Message,
                    Data = id,
                    StatusCode = StatusCodes.Status200OK
                });
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar Branch.");
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
}
