using CleaningRobot.Commands.Enums;

namespace CleaningRobot.Commands;

public class CleaningRobotCommand(MovementDirection direction, int steps)
{
    public MovementDirection Direction { get; private set; } = direction;
    public int Steps { get; private set; } = steps;
}