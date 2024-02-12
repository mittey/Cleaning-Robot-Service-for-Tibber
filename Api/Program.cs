using Api.Dtos;
using Api.Services;
using CleaningRobot.Robot;
using Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CleaningRobotService>();
builder.Services.AddScoped<ExecutionLoggingService>();

builder.Services.AddScoped<RobotController>();

builder.Services.AddDbContext<CleaningRobotServiceDbContext>();
builder.Services.AddScoped<ExecutionLogRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
using (var dbContext = scope.ServiceProvider.GetService<CleaningRobotServiceDbContext>())
{
    dbContext!.Database.EnsureCreated();
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

app.Run();