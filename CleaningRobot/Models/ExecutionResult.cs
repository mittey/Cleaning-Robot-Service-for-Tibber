namespace CleaningRobot.Models;

public class ExecutionResult(int cleanedArea, long executionTimeInMs)
{
    public int CleanedArea { get; private set; } = cleanedArea;
    public long ExecutionTimeInMs { get; private set; } = executionTimeInMs;
}