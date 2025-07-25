using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;

namespace Gymmetry.Functions.AutomaticProcess
{
    public class GymUserFunction
    {
        private readonly IGymUserService _gymUserService;

        public GymUserFunction(IGymUserService gymUserService)
        {
            _gymUserService = gymUserService;
        }

        //[FunctionName("NullifyGymIdForExpiredPlans")]
        //public async Task Run([TimerTrigger("0 1 0 * * *")] TimerInfo myTimer, ILogger log)
        //{
        //    log.LogInformation("NullifyGymIdForExpiredPlans function executed at: {time}", DateTime.Now);

        //    try
        //    {
        //        await _gymUserService.NullifyGymIdForExpiredPlansAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, "An error occurred while nullifying GymId for users with expired plans.");
        //    }
        //}
    }
}