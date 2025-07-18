using System;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FitGymApp.Application.Services
{
    public class GymPlanService : IGymPlanService
    {
        private readonly IGymRepository _gymRepository;
        private readonly ILogger<GymPlanService> _logger;
        private readonly ILogErrorService _logErrorService;

        public GymPlanService(IGymRepository gymRepository, ILogger<GymPlanService> logger, ILogErrorService logErrorService)
        {
            _gymRepository = gymRepository;
            _logger = logger;
            _logErrorService = logErrorService;
        }

        public async Task DeactivateExpiredGymPlansAsync()
        {
            _logger.LogInformation("Starting DeactivateExpiredGymPlansAsync method.");

            try
            {
                var gyms = await _gymRepository.GetAllGymsAsync();
                foreach (var gym in gyms)
                {
                    var activePlans = gym.GymPlanSelecteds?.Where(plan => plan.IsActive && plan.EndDate <= DateTime.UtcNow);
                    if (activePlans != null)
                    {
                        foreach (var plan in activePlans)
                        {
                            plan.IsActive = false;
                        }
                    }
                }

                await _gymRepository.SaveChangesAsync();
                _logger.LogInformation("Expired gym plans deactivated successfully.");
            }
            catch (Exception ex)
            {
                //TODO: Send email if there is an error
                _logger.LogError(ex, "An error occurred while deactivating expired gym plans.");
                await _logErrorService.LogErrorAsync(ex);
                throw;
            }
        }
    }
}