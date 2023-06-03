using VetAwesome.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithMethods("GET", "POST", "PATCH", "PUT");
            policy.WithOrigins("http://localhost:4200", "http://[::1]:4200/");
        });
    })
    .AddInfrastructure(builder.Configuration)
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
    .AddApplication()
    .AddPresentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();
