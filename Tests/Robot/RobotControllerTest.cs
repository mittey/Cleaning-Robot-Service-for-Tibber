using CleaningRobot.Models;
using CleaningRobot.Robot;
using CleaningRobot.Robot.Commands;
using CleaningRobot.Robot.Commands.Enums;
using CleaningRobot.Robot.Positioning;

namespace Tests.Robot;

public class RobotControllerTest
{
    [Fact]
    public void Execute_ShouldReturnValidResult()
    {
        var testExecutionPlan =
            new ExecutionPlan(new Point(1, 1), [new CleaningRobotCommand(RobotMovementDirection.Down, 3)]);

        var testResult = new RobotController().Execute(testExecutionPlan);

        Assert.True(testResult.ExecutionTimeInMs > 0);
        Assert.Equal(4, testResult.AreaCleaned);
    }
}