using Microsoft.Extensions.DependencyInjection;

namespace Gymmetry.Repository.Services.Interfaces
{
    public static class IGymmetryRepositoryRegistration
    {
        public static void AddGymmetryRepositories(this IServiceCollection services)
        {
            // ...otros repositorios...
            services.AddScoped<IEmailRepository, EmailRepository>();
        }
    }
}
