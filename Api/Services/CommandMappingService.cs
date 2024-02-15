using Api.Common;
using Api.Dtos;
using Api.Dtos.Enums;
using CleaningRobot.Models;
using CleaningRobot.Robot.Commands;
using CleaningRobot.Robot.Commands.Enums;
using CleaningRobot.Robot.Positioning;

namespace Api.Services;

public static class CommandMappingService
{
    private static RobotMovementDirection MapDirection(MovementDirection direction)
    {
        return direction switch
        {
            MovementDirection.North => RobotMovementDirection.Up,
            MovementDirection.South => RobotMovementDirection.Down,
            MovementDirection.East => RobotMovementDirection.Right,
            MovementDirection.West => RobotMovementDirection.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public static ExecutionPlan Map(ExecutionPlanDto executionPlanDto)
    {
        return new ExecutionPlan(new Point(executionPlanDto.Start.X, executionPlanDto.Start.Y),
            executionPlanDto.Commands.Select(c => new CleaningRobotCommand(MapDirection(c.Direction), c.Steps)));
    }

    public static ExecutionResultDto Map(ExecutionResult executionPlan)
    {
        return new ExecutionResultDto(executionPlan.AreaCleaned, executionPlan.CommandsCount,
            TimeUtils.MsToSec(executionPlan.ExecutionTimeInMs));
    }
}