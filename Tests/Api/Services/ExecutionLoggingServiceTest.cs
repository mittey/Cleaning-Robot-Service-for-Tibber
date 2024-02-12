using Api.Services;
using CleaningRobot.Models;
using Data;
using Data.Entities;
using Data.Repositories;
using Moq;

namespace Tests.Api.Services;

public class ExecutionLoggingServiceTest
{
    [Fact]
    public async Task LogExecutionResultAsync_ShouldProperlyMapExecResultToExecLogAndPassItToTheRepo()
    {
        ExecutionLog? testExecLog = null;

        var dbContextMock = new Mock<CleaningRobotServiceDbContext>();
        var repoMock = new Mock<ExecutionLogRepository>(dbContextMock.Object);
        repoMock.Setup(m => m.AddExecutionLogAsync(It.IsAny<ExecutionLog>()))
            .Callback<ExecutionLog>(log => testExecLog = log)
            .Returns(Task.CompletedTask);

        var execResult = new ExecutionResult(12, 3, 100);

        var loggingService = new ExecutionLoggingService(repoMock.Object);
        await loggingService.LogExecutionResultAsync(execResult);

        repoMock.Verify(m => m.AddExecutionLogAsync(It.IsAny<ExecutionLog>()), Times.Once());
        Assert.NotNull(testExecLog);
        Assert.Equal(execResult.AreaCleaned, testExecLog.Result);
    }
}