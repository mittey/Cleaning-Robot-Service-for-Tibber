using System.Numerics;
using CleaningRobot.Robot.Commands.Enums;

namespace CleaningRobot.Robot.Positioning;

public static class PointExtensions
{
    public static Vector2 ToVector(this Point p)
    {
        return new Vector2(p.X, p.Y);
    }

    public static Point Copy(this Point p)
    {
        return new Point(p.X, p.Y);
    }
}

public sealed class Point(int x, int y)
{
    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    public void Move(RobotMovementDirection direction, int steps)
    {
        switch (direction)
        {
            case RobotMovementDirection.Up:
                Y += steps;
                break;

            case RobotMovementDirection.Down:
                Y -= steps;
                break;

            case RobotMovementDirection.Left:
                X -= steps;
                break;

            case RobotMovementDirection.Right:
                X += steps;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}