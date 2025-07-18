using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;

namespace FitGymApp.Functions.AutomaticProcess
{
    public class GymPlanFunction
    {
        private readonly IGymPlanService _gymPlanService;

        public GymPlanFunction(IGymPlanService gymPlanService)
        {
            _gymPlanService = gymPlanService;
        }

        [FunctionName("DeactivateExpiredGymPlans")]
        public async Task Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("DeactivateExpiredGymPlans function executed at: {time}", DateTime.Now);

            try
            {
                await _gymPlanService.DeactivateExpiredGymPlansAsync();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred while deactivating expired gym plans.");
            }
        }
    }
}