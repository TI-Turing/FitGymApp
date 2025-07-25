using System;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Repository.Services.Interfaces;
using Gymmetry.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Gymmetry.Application.Services
{
    public class GymUserService : IGymUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlanRepository _planRepository;
        private readonly ILogger<GymUserService> _logger;
        private readonly ILogErrorService _logErrorService;

        public GymUserService(IUserRepository userRepository, IPlanRepository planRepository, ILogger<GymUserService> logger, ILogErrorService logErrorService)
        {
            _userRepository = userRepository;
            _planRepository = planRepository;
            _logger = logger;
            _logErrorService = logErrorService;
        }

        public async Task NullifyGymIdForExpiredPlansAsync()
        {
            _logger.LogInformation("Starting NullifyGymIdForExpiredPlansAsync method.");

            try
            {
                var plans = await _planRepository.GetAllPlansAsync();
                var expiredPlans = plans.Where(plan => plan.EndDate <= DateTime.UtcNow);

                foreach (var plan in expiredPlans)
                {
                    var users = await _userRepository.FindUsersByFieldsAsync(new Dictionary<string, object> { { "PlanId", plan.Id } });
                    foreach (var user in users)
                    {
                        user.GymId = null;
                    }
                }

                await _userRepository.SaveChangesAsync();
                _logger.LogInformation("GymId set to null for users with expired plans successfully.");
            }
            catch (Exception ex)
            {
                //TODO: Send email if there is an error
                _logger.LogError(ex, "An error occurred while nullifying GymId for users with expired plans.");
                await _logErrorService.LogErrorAsync(ex);
                throw;
            }
        }
    }
}