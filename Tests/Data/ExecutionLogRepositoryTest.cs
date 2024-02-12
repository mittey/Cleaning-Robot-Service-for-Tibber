using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Tests.Data;

public class ExecutionLogRepositoryTest
{
    [Fact]
    public async Task ShouldAddNewLogEntry()
    {
        var dbSetMock = new Mock<DbSet<ExecutionLog>>();
        var dbContextMock = new Mock<CleaningRobotServiceDbContext>();
        dbContextMock.Setup(m => m.Executions).Returns(dbSetMock.Object);

        var testExecutionLog = new ExecutionLog();
        var repo = new ExecutionLogRepository(dbContextMock.Object);

        await repo.AddExecutionLogAsync(testExecutionLog);

        dbSetMock.Verify(m => m.AddAsync(testExecutionLog, It.IsAny<CancellationToken>()));
        dbContextMock.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }
}