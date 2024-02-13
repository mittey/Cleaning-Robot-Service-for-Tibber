using Api.Dtos;
using Api.Services;
using CleaningRobot.Robot;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.ServiceConfiguration;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CleaningRobotService>();
        builder.Services.AddScoped<ExecutionLoggingService>();

        builder.Services.AddScoped<RobotController>();

        builder.Services.AddDbContext<CleaningRobotServiceDbContext>(options =>
        {
            var config = builder.Configuration["Database"];

            // For debug purposes.
            Console.WriteLine($"CONNECTION STRING -> {config}");

            options.UseNpgsql(config);
        });
        builder.Services.AddScoped<ExecutionLogRepository>();
    }

    public static void ConfigureApp(this WebApplication app)
    {
        // This is a kind of hardcoded solution to ensure that there is a existing database when the service launches. In a production environment it would probably be better to use migrations etc.
        using var scope = app.Services.CreateScope();
        using var dbContext = scope.ServiceProvider.GetService<CleaningRobotServiceDbContext>();
        {
            dbContext!.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
        // The api endpoint for the task.
        app.MapPost("/tibber-developer-test/enter-path",
                (ExecutionPlanDto executionPlanDto, CleaningRobotService cleaningRobotService) =>
                {
                    var executionPlan = CommandMappingService.Map(executionPlanDto);

                    return cleaningRobotService.ExecuteAsync(executionPlan);
                })
            .WithName("RunCleaningRobot")
            .WithOpenApi();
    }
}