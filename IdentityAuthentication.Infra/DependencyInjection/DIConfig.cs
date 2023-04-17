using IdentityAuthentication.Application.ApplicationServices.UserApplicationService;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityAuthentication.Crosscutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserApplicationService, UserApplicationService>();

            return services;
        }
    }
}
