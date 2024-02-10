using CleaningRobot.Commands;
using CleaningRobot.Positioning;

namespace CleaningRobot.Models;

public class ExecutionPlan(Point initialPosition, IEnumerable<CleaningRobotCommand> commandsSequence)
{
    public Point InitialPosition { get; private set; } = initialPosition;
    public IEnumerable<CleaningRobotCommand> CommandSequence { get; private set; } = commandsSequence;
}