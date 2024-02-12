using Api.Dtos;
using Api.Services;
using CleaningRobot.Robot;
using Data;
using Data.Repositories;

namespace Api.ServiceConfiguration;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CleaningRobotService>();
        builder.Services.AddScoped<ExecutionLoggingService>();

        builder.Services.AddScoped<RobotController>();

        builder.Services.AddDbContext<CleaningRobotServiceDbContext>();
        builder.Services.AddScoped<ExecutionLogRepository>();
    }

    public static void ConfigureApp(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var dbContext = scope.ServiceProvider.GetService<CleaningRobotServiceDbContext>();
        dbContext!.Database.EnsureCreated();

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