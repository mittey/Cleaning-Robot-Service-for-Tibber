using Api.Services;
using CleaningRobot.Models;
using CleaningRobot.Robot;
using CleaningRobot.Robot.Commands;
using CleaningRobot.Robot.Commands.Enums;
using CleaningRobot.Robot.Positioning;
using Data;
using Data.Repositories;
using Moq;

namespace Tests.Api.Services;

public class CleaningRobotServiceTest
{
    [Fact]
    public async Task ExecuteAsync_ShouldCallRobotControllerAndLoggingService()
    {
        var dbContextMock = new Mock<CleaningRobotServiceDbContext>();
        var repositoryMock = new Mock<ExecutionLogRepository>(dbContextMock.Object);
        var loggerServiceMock = new Mock<ExecutionLoggingService>(repositoryMock.Object);
        var robotControllerMock = new Mock<RobotController>();

        loggerServiceMock.Setup(m => m.LogExecutionResultAsync(It.IsAny<ExecutionResult>()))
            .Returns(Task.CompletedTask);
        robotControllerMock.Setup(m => m.Execute(It.IsAny<ExecutionPlan>())).Returns(new ExecutionResult(1, 2));

        var robotService = new CleaningRobotService(loggerServiceMock.Object, robotControllerMock.Object);
        await robotService.ExecuteAsync(new ExecutionPlan(new Point(1, 2),
            new[] { new CleaningRobotCommand(RobotMovementDirection.Up, 2) }));

        robotControllerMock.Verify(m => m.Execute(It.IsAny<ExecutionPlan>()), Times.Once);
        loggerServiceMock.Verify(m => m.LogExecutionResultAsync(It.IsAny<ExecutionResult>()), Times.Once);
    }
}