using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VetAwesome.Application.Utils;
using VetAwesome.Application.Utils.Interfaces;

namespace VetAwesome.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddScoped<ICurrentUser, CurrentUser>();

        return services;
    }
}
