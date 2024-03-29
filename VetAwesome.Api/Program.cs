using System.Diagnostics;

const string VetAwesomeCors = "VetAwesomeCors";

try
{
    var builder = WebApplication.CreateBuilder(args);

    string origin = "http://localhost:4200/";
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: VetAwesomeCors, policy =>
        {
            policy.WithOrigins("http://localhost:4200");

        });
    });

    VetAwesome.Application.Extensions.ServicesExtensions.AddVetAwesomeApplication(builder.Services);
    VetAwesome.Persistence.Extensions.ServicesExtensions.AddVetAwesomePersistences(builder.Services, builder.Configuration.GetConnectionString("VetAwesomeDb") ?? string.Empty);

    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();
    app.UseCors(VetAwesomeCors);
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    //Log.Fatal(ex, "Exemplar API terminated unexpectedly");
    if (OperatingSystem.IsWindows())
    {
        var eventLog = new EventLog("Application")
        {
            Source = "Application"
        };
        eventLog.WriteEntry($"VetAwesome API terminated unexpectedly {Environment.NewLine}{ex}");
    }
}
finally
{
    //Log.CloseAndFlush();
}

