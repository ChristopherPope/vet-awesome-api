using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace VetAwesome.Api.Extensions
{
    public static class ApiServiceCollectionExtensions
    {
        static public IServiceCollection AddVetAwesomeSwagger(this IServiceCollection services, WebApplicationBuilder webAppBuilder)
        {
            services.AddSwaggerGen(swagger =>
            {
                var title = "VetAwesomeApi";
                if (webAppBuilder.Environment.IsDevelopment())
                {
                    title = $"DEBUG-{title}";
                }
                else
                {
                    title = $"RELEASE-{title}";
                }

                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = title });
                swagger.EnableAnnotations();
            });

            return services;
        }

        static public IServiceCollection AddVetAwesomeCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsOrigins",
                                  builder =>
                                  {
                                      builder.WithMethods("GET", "DELETE", "POST", "PATCH");
                                      builder.AllowAnyOrigin();
                                      builder.WithHeaders(HeaderNames.ContentType);
                                  });
            });

            return services;
        }
    }
}
