using System.Collections.Immutable;
using Api.Dtos;
using CleaningRobot.Commands;
using CleaningRobot.Models;
using CleaningRobot.Positioning;

namespace Api.Services;

public static class CommandMappingService
{
    public static ExecutionPlan Map(ExecutionPlanDto executionPlanDto)
    {
        return new ExecutionPlan(new Point(executionPlanDto.Start.X, executionPlanDto.Start.Y),
            ImmutableArray<CleaningRobotCommand>.Empty);
    }
}