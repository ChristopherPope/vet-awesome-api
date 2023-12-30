using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VetAwesome.Application.Mappers;
using VetAwesome.Application.Mappers.Interfaces;

namespace VetAwesome.Application.Extensions;
public static class ServicesExtensions
{
    public static IServiceCollection AddVetAwesomeApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddSingleton<IAppointmentMapper, AppointmentMapper>();

        return services;
    }
}
