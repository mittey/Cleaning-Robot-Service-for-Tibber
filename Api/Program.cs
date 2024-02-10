using Api.Dtos;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(CleaningRobotService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/tibber-developer-test/enter-path",
        (ExecutionPlanDto executionPlanDto, CleaningRobotService cleaningRobotService) =>
        {
            var executionPlan = CommandMappingService.Map(executionPlanDto);

            return cleaningRobotService.Execute(executionPlan);
        })
    .WithName("RunCleaningRobot")
    .WithOpenApi();

app.Run();