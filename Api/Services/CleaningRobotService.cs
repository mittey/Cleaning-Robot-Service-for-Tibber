using CleaningRobot;
using CleaningRobot.Models;

namespace Api.Services;

public class CleaningRobotService
{
    public ExecutionResult Execute(ExecutionPlan executionPlan)
    {
        return RobotController.Execute(executionPlan);
    }
}