using CleaningRobot.Models;

namespace Api.Services;

public class ExecutionLoggingService
{
    public void LogExecutionResult(ExecutionResult executionResult)
    {
        Console.WriteLine(executionResult);
    }
}