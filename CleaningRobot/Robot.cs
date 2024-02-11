using CleaningRobot.Commands;
using CleaningRobot.Positioning;

namespace CleaningRobot;

public sealed class Robot
{
    private readonly VisitableArea _cleaningArea;
    private readonly Point _position;

    public Robot(Point initialPosition, VisitableArea cleaningArea)
    {
        _cleaningArea = cleaningArea;
        _position = initialPosition;

        _cleaningArea.Visit(_position);
    }


    public int CleanedArea => _cleaningArea.VisitedCount;

    public void Execute(CleaningRobotCommand command)
    {
        for (var i = 0; i < command.Steps; i++)
        {
            _position.Move(command.Direction);
            _cleaningArea.Visit(_position);

            // Simulate robot movement. Each step takes 5ms to execute.
            Thread.Sleep(5);
        }
    }

    public void Execute(IEnumerable<CleaningRobotCommand> commandSequence)
    {
        foreach (var command in commandSequence)
            Execute(command);
    }
}