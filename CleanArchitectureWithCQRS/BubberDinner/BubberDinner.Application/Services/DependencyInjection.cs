using BubberDinner.Application.Services.Authentication.Commands;
using BubberDinner.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BubberDinner.Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;
        }
    }
}
