using Data.Entities;

namespace Data.Repositories;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class ExecutionLogRepository(CleaningRobotServiceDbContext dbContext)
{
    public virtual async Task AddExecutionLogAsync(ExecutionLog executionLog)
    {
        await dbContext.Executions.AddAsync(executionLog);
        await dbContext.SaveChangesAsync();
    }
}