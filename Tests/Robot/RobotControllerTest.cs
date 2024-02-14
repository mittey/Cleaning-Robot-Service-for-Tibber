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
            new ExecutionPlan(new Point(1, 1),
            [
                new CleaningRobotCommand(RobotMovementDirection.Down, 3),
                new CleaningRobotCommand(RobotMovementDirection.Left, 1),
                new CleaningRobotCommand(RobotMovementDirection.Up, 1),
                new CleaningRobotCommand(RobotMovementDirection.Right,
                    3), // There is an intersection during this command.
            ]);

        var testResult = new RobotController().Execute(testExecutionPlan);

        Assert.Equal(9, testResult.AreaCleaned);
    }
}