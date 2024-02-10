using CleaningRobot.Commands.Enums;

namespace CleaningRobot.Positioning;

public sealed class Point(int x, int y)
{
    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    public void Move(MovementDirection direction)
    {
        switch (direction)
        {
            case MovementDirection.Up:
                Y++;
                break;

            case MovementDirection.Down:
                Y--;
                break;

            case MovementDirection.Left:
                X--;
                break;

            case MovementDirection.Right:
                X++;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}