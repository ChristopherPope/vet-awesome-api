using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VetAwesome.Application.Interfaces.Persistence;
using VetAwesome.Seeder.Database;

namespace VetAwesome.Persistence.Extensions;
public static class ServicesExtensions
{
    public static IServiceCollection AddVetAwesomePersistences(this IServiceCollection services, string dbConnectionString)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<VetAwesomeDb>(options =>
        {
            options.UseSqlServer(dbConnectionString);
        });


        return services;
    }
}