using Serilog;

namespace VetAwesome.Api.Extensions
{
    public static class ApiWebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddVetAwesomeLogging(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            return builder;
        }
    }
}
