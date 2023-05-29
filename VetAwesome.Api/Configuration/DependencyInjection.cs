using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrutor;
using VetAwesome.Infrastructure.Persistence;

namespace VetAwesome.Api.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .Scan(
                selector => selector
                    .FromAssemblies(
                        VetAwesome.Infrastructure.AssemblyReference.Assembly)
                    .AddClasses(false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsMatchingInterface()
                    .WithScopedLifetime());

        services.AddDbContext<VetAwesomeDb>(
            (sp, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(
                    configuration.GetConnectionString("VetAwesome"));
            });

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(VetAwesome.Application.AssemblyReference.Assembly));

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddApplicationPart(VetAwesome.Presentation.AssemblyReference.Assembly);

        services.AddSwaggerGen();

        return services;
    }
}
