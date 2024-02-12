using CleaningRobot.Models;
using Data;
using Data.Entities;

namespace Api.Services;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class ExecutionLoggingService(ExecutionLogRepository repository)
{
    public virtual async Task LogExecutionResultAsync(ExecutionResult executionResult)
    {
        await repository.AddExecutionLogAsync(new ExecutionLog { AreaCleaned = executionResult.AreaCleaned });
    }
}