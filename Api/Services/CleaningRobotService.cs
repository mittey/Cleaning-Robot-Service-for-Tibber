using CleaningRobot;
using CleaningRobot.Models;

namespace Api.Services;

public class CleaningRobotService(ExecutionLoggingService loggingService)
{
    public ExecutionResult Execute(ExecutionPlan executionPlan)
    {
        var result = RobotController.Execute(executionPlan);

        loggingService.LogExecutionResult(result);

        return result;
    }
}