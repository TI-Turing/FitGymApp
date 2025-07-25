using Microsoft.Extensions.DependencyInjection;

namespace Gymmetry.Application.Services.Interfaces
{
    public static class IGymmetryServiceRegistration
    {
        public static void AddGymmetryServices(this IServiceCollection services)
        {
            // ...otros servicios...
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
