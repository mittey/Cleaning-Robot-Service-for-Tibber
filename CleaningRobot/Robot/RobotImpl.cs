using CleaningRobot.Robot.Commands;
using CleaningRobot.Robot.Positioning;

namespace CleaningRobot.Robot;

public sealed class RobotImpl(Point position, LineSweeper lineSweeper)
{
    private int _intersections;
    private int _totalVisited = 1; // We assume that the first point the robot appears on is also cleaned.

    public int CleanedArea => _totalVisited - _intersections;

    public void Execute(IEnumerable<CleaningRobotCommand> commandSequence)
    {
        var events = new List<LineSweeper.LineEvent>();
        foreach (var command in commandSequence)
        {
            _totalVisited += command.Steps;

            var p1 = position.Copy();
            position.Move(command.Direction, command.Steps);
            var p2 = position.Copy();

            if (p1.X == p2.X) // A "vertical" segment.
            {
                events.Add(new LineSweeper.LineEvent(p1.ToVector(), p2.ToVector(), LineSweeper.EventType.Vertical));
            }
            else
            {
                events.Add(new LineSweeper.LineEvent(p1.ToVector(), p2.ToVector(), LineSweeper.EventType.Start));
                events.Add(new LineSweeper.LineEvent(p2.ToVector(), p1.ToVector(), LineSweeper.EventType.End));
            }
        }

        _intersections = lineSweeper.GetIntersectionsCount(events);
    }
}