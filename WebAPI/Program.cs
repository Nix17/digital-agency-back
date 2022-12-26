using Application;
using Application.Interfaces.Services;

using Domain.Settings;
using FluentValidation.AspNetCore;
//using Infrastructure.Identity;
//using Infrastructure.Identity.Contexts;
//using Infrastructure.Identity.Models;
using Persistence;
using Persistence.Contexts;
using Infrastructure.Shared;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Serilog;

using System.ComponentModel.DataAnnotations;
using System.Text.Json;

using WebApi.Extensions;


var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
var builder = WebApplication.CreateBuilder(args);

// Add configurations
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
builder.Configuration.AddEnvironmentVariables();

// Add logging 
builder.Logging.ClearProviders();
var logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
builder.Logging.AddSerilog(logger);

// Add projects to the container.
builder.Services.AddApplicationLayer();
//builder.Services.AddIdentityInfrastructure(config);
builder.Services.AddPersistenceInfrastructure(config);
builder.Services.AddSharedInfrastructure(config);
builder.Services.AddCorsRules(config);

// Add services to the container.
builder.Services.AddControllers(options => { options.Filters.Add(typeof(WebApi.Attributes.CustomValidationAttribute)); })
                .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddApiVersioningExtension();
builder.Services.AddExtendedMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddServices(config);

// Form Settings
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        //var identityContext = services.GetRequiredService<IdentityContext>();
        //await identityContext.Database.MigrateAsync();

        var persistenceContext = services.GetRequiredService<ApplicationDbContext>();
        //await Persistence.Seeds.DatabaseInitializer.SeedAsync(persistenceContext);
        await persistenceContext.Database.MigrateAsync();

        Log.Information("Migrations Applied");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred migrating the DB");
    }
    //try
    //{
    //    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    //    //var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
    //    //var accountService = services.GetRequiredService<IAccountService>();

    //    //await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
    //    //await Infrastructure.Identity.Seeds.DefaultUser.SeedAsync(userManager);
    //    //await Infrastructure.Identity.Seeds.DefaultAdmin.SeedAsync(userManager);
    //    //await Infrastructure.Identity.Seeds.DefaultRoot.SeedAsync(userManager);
    //    //await accountService.LoadCache();
    //}
    //catch (Exception ex)
    //{
    //    Log.Warning(ex, "An error occurred seeding the DB");
    //}
    //finally
    //{
    //    Log.CloseAndFlush();
    //}
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCorsRules();
app.UseAuthentication();

app.UseAuthorization();

app.UseSwaggerExtension();
app.UseDefaultPage();
app.UseHealthChecks("/health");
app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();