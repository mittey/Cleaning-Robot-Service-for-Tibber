using CleaningRobot.Robot.Positioning;

namespace CleaningRobot.Robot;

public static class RobotFactory
{
    public static RobotImpl CreateRobot(Point initialPosition)
    {
        return new RobotImpl(initialPosition, new VisitableArea());
    }
}