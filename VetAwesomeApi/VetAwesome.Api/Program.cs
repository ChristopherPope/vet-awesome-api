using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Serilog;
using VetAwesome.Api.Extensions;
using VetAwesome.Api.Identity;
using VetAwesome.Bll;

WebApplicationBuilder webAppBuilder = WebApplication.CreateBuilder(args);
IServiceCollection services = webAppBuilder.Services;
ConfigurationManager configuration = webAppBuilder.Configuration;


webAppBuilder
    //.AddVetAwesomeLogging(configuration)
    .Host
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .UseSerilog((_, config) => config.ReadFrom.Configuration(webAppBuilder.Configuration));

services
    .AddTransient<IClaimsTransformation, VetAwesomeClaimsTransformation>()
    .AddHttpContextAccessor()
    .AddDistributedMemoryCache()
    .AddSession()
    .AddVetAwesomeCors()
    .AddVetAwesomeSwagger(webAppBuilder)
    .AddControllers();

webAppBuilder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new BllModule(services, configuration.GetConnectionString("VetAwesomeDb")));
});

var app = webAppBuilder.Build();
app.UseSwagger()
   .UseSwaggerUI()
   .UseAuthorization()
   .UseSession();

app.MapControllers();
app.UseCors("CorsOrigins");

app.Run();
