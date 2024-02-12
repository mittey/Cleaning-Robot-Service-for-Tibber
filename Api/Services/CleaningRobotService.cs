using CleaningRobot.Models;
using CleaningRobot.Robot;

namespace Api.Services;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class CleaningRobotService(ExecutionLoggingService loggingService, RobotController robotController)
{
    public virtual async Task<ExecutionResult> ExecuteAsync(ExecutionPlan executionPlan)
    {
        var result = robotController.Execute(executionPlan);

        await loggingService.LogExecutionResultAsync(result);

        return result;
    }
}