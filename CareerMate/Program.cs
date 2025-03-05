using Autofac;
using Autofac.Extensions.DependencyInjection;
using FileSource;
using FileSource.API.AutofacModules;
using FileSource.API.Middlewares;
using FileSource.Infrastructure.Persistence;
using FileSource.Infrastructure.Persistence.Seeds;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

var builder = WebApplication.CreateBuilder(args);

string corsPolicy = "CorsPolicy";

// Autofac
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        container.RegisterModule<PersistenceModules>();
    });

// Add services to the container.
builder.Services.RegisterServices(builder.Configuration);
builder.Services.RegisterSystemServices();
builder.Services.RegisterBackgroundJobs();

//Roles configurations
builder.Services.AddRolesPolicies();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy, policy =>
    {
        policy
            .WithOrigins("http://localhost:3000", "https://gray-field-05e650100.5.azurestaticapps.net")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true);
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors(corsPolicy);
app.UseAuthentication();
app.UseAuthorization();

// Middleware 
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext = services.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();

    try
    {
        var roleSeeder = services.GetRequiredService<IdentityRoleSeed>();
        await roleSeeder.SeedRoles();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error while initializing roles");
    }
}

app.MapControllers();

app.Run();
