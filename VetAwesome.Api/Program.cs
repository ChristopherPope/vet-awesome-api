using VetAwesome.Api.Configuration;
using VetAwesome.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy
                .AllowAnyMethod()   //.WithMethods("GET", "POST", "PATCH", "PUT");
                .WithOrigins("http://localhost:4200", "http://[::1]:4200/")
                .AllowAnyHeader();
        });
    })
    .AddInfrastructure(builder.Configuration)
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
app.UseSession();
app.MapControllers();
app.UseCors();
app.Run();
