using Api.Dtos;
using Api.Dtos.Enums;
using Api.Services;
using CleaningRobot.Robot.Commands.Enums;

namespace Tests.Api.Services;

public class CommandMappingServiceTest
{
    [Fact]
    public void Map_ShouldProperlyMapExecutionPlanDtoToExecutionPlan()
    {
        var testDto =
            new ExecutionPlanDto(new StartDto(1, 2), new CommandDto[] { new(MovementDirection.North, 2) });

        var result = CommandMappingService.Map(testDto);

        Assert.Equal(testDto.Start.X, result.InitialPosition.X);
        Assert.Equal(testDto.Start.Y, result.InitialPosition.Y);

        Assert.Equal(testDto.Commands.Count(), result.CommandSequence.Count());
        Assert.Equal(testDto.Commands.First().Steps, result.CommandSequence.First().Steps);
    }

    [Fact]
    public void MapDirection_ShouldMapNorthToUp()
    {
        var testDto =
            new ExecutionPlanDto(new StartDto(1, 2), new CommandDto[] { new(MovementDirection.North, 2) });

        var result = CommandMappingService.Map(testDto);

        Assert.Equal(RobotMovementDirection.Up, result.CommandSequence.First().Direction);
    }

    [Fact]
    public void MapDirection_ShouldMapSouthToDown()
    {
        var testDto =
            new ExecutionPlanDto(new StartDto(1, 2), new CommandDto[] { new(MovementDirection.South, 2) });

        var result = CommandMappingService.Map(testDto);

        Assert.Equal(RobotMovementDirection.Down, result.CommandSequence.First().Direction);
    }

    [Fact]
    public void MapDirection_ShouldEastToRight()
    {
        var testDto =
            new ExecutionPlanDto(new StartDto(1, 2), new CommandDto[] { new(MovementDirection.East, 2) });

        var result = CommandMappingService.Map(testDto);

        Assert.Equal(RobotMovementDirection.Right, result.CommandSequence.First().Direction);
    }

    [Fact]
    public void MapDirection_ShouldMapWestToLeft()
    {
        var testDto =
            new ExecutionPlanDto(new StartDto(1, 2), new CommandDto[] { new(MovementDirection.West, 2) });

        var result = CommandMappingService.Map(testDto);

        Assert.Equal(RobotMovementDirection.Left, result.CommandSequence.First().Direction);
    }

    [Fact]
    public void MapDirection_ShouldThrowForInvalidEnumValue()
    {
        var testDto =
            new ExecutionPlanDto(new StartDto(1, 2), new CommandDto[] { new((MovementDirection)(-1), 2) });

        var result = CommandMappingService.Map(testDto);

        Assert.Throws<ArgumentOutOfRangeException>(() => result.CommandSequence.First());
    }
}