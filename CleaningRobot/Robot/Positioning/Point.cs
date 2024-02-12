using CleaningRobot.Robot.Commands.Enums;

namespace CleaningRobot.Robot.Positioning;

public sealed class Point(int x, int y)
{
    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    public void Move(RobotMovementDirection direction)
    {
        switch (direction)
        {
            case RobotMovementDirection.Up:
                Y++;
                break;

            case RobotMovementDirection.Down:
                Y--;
                break;

            case RobotMovementDirection.Left:
                X--;
                break;

            case RobotMovementDirection.Right:
                X++;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}