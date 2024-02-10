using CleaningRobot.Commands;
using CleaningRobot.Positioning;

namespace CleaningRobot;

public sealed class Robot
{
    private readonly VisitableArea _cleaningArea;

    public Robot(Point initialPosition, VisitableArea cleaningArea)
    {
        _cleaningArea = cleaningArea;
        Position = initialPosition;

        _cleaningArea.Visit(Position);
    }

    public Point Position { get; }

    public int CleanedArea => _cleaningArea.VisitedCount;

    public void ExecuteCommand(CleaningRobotCommand command)
    {
        for (var i = 0; i < command.Steps; i++)
        {
            Position.Move(command.Direction);
            _cleaningArea.Visit(Position);
        }
    }

    public void ExecuteCommandSequence(IEnumerable<CleaningRobotCommand> commandSequence)
    {
        foreach (var command in commandSequence)
            ExecuteCommand(command);
    }
}