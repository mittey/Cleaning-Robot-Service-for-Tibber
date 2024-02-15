using Api.Common;
using CleaningRobot.Models;
using Data.Entities;
using Data.Repositories;

namespace Api.Services;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class ExecutionLoggingService(ExecutionLogRepository repository)
{
    public virtual async Task
        LogExecutionResultAsync(ExecutionResult executionResult) // The method is virtual to be mockable.
    {
        await repository.AddExecutionLogAsync(new ExecutionLog
        {
            Result = executionResult.AreaCleaned,
            Timestamp = DateTime.UtcNow,
            Commands = executionResult.CommandsCount,
            Duration = TimeUtils.MsToSec(executionResult.ExecutionTimeInMs)
        });
    }
}