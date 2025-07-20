using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using System;
using System.Threading.Tasks;
using FitGymApp.Utils;

namespace FitGymApp.Functions.MachineFunction
{
    public class DeleteMachineFunction
    {
        private readonly ILogger<DeleteMachineFunction> _logger;
        private readonly IMachineService _service;

        public DeleteMachineFunction(ILogger<DeleteMachineFunction> logger, IMachineService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Machine_DeleteMachineFunction")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "machine/{id:guid}")] HttpRequestData req, Guid id)
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

            _logger.LogInformation($"Procesando solicitud de borrado para Machine {id}");
            try
            {
                var result = await _service.DeleteMachineAsync(id);
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
                _logger.LogError(ex, "Error al eliminar Machine.");
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
