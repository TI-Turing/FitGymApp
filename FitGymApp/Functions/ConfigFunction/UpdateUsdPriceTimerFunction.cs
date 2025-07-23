using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using Microsoft.Azure.Functions.Worker.Extensions.Timer;

namespace FitGymApp.Functions.ConfigFunction
{
    public class UpdateUsdPriceTimerFunction
    {
        private readonly ILogger<UpdateUsdPriceTimerFunction> _logger;
        private readonly IConfigAutoService _configAutoService;

        public UpdateUsdPriceTimerFunction(ILogger<UpdateUsdPriceTimerFunction> logger, IConfigAutoService configAutoService)
        {
            _logger = logger;
            _configAutoService = configAutoService;
        }

        // Se ejecuta todos los días a la medianoche (0:00)
        //[Function("Config_UpdateUsdPriceTimerFunction")]
        //public async Task Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer)
        //{
        //    _logger.LogInformation($"UpdateUsdPriceTimerFunction ejecutada a: {DateTime.Now}");
        //    await _configAutoService.UpdateUsdPricesFromExchangeAsync();
        //}
    }
}
