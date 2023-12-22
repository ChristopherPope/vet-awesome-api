using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrutor;
using Serilog;
using Serilog.Events;
using System.Reflection;
using VetAwesome.Seeder;
using VetAwesome.Seeder.Database;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting VetAwesome seeder...");

    IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);
    hostBuilder
        .ConfigureAppConfiguration(configBuilder =>
        {
            configBuilder
                .AddJsonFile($"appsettings.json", true, true)
#if DEBUG
                .AddJsonFile("appsettings.development.json", true, true)
#else
                .AddJsonFile("appsettings.production.json", true, true)
#endif
                .AddEnvironmentVariables();
        })
        .UseSerilog()
        .ConfigureServices((hostContext, services) =>
        {
            var config = hostContext.Configuration;

            _ = services.Scan(
                    selector => selector
                        .FromAssemblies(Assembly.GetExecutingAssembly())
                        .AddClasses(false)
                        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                        .AsMatchingInterface()
                        .WithScopedLifetime());

            _ = services
                .AddDbContext<VetAwesomeDb>(options => options.UseSqlServer(config.GetConnectionString("VetAwesome")))
                .AddHostedService<Seeder>();

        })
        .Build()
        .Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
