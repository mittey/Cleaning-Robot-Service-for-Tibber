using CleaningRobot.Robot.Commands.Enums;
using CleaningRobot.Robot.Positioning;

namespace Tests.Robot.Positioning;

public class PointTest
{
    private const int X = 1, Y = 2;
    private readonly Point _testPoint = new(X, Y);

    [Fact]
    public void ShouldInitializeWithConstructorValues()
    {
        Assert.Equal(X, _testPoint.X);
        Assert.Equal(Y, _testPoint.Y);
    }

    [Fact]
    public void ShouldMoveUp()
    {
        _testPoint.Move(RobotMovementDirection.Up);

        Assert.Equal(Y + 1, _testPoint.Y);
        Assert.Equal(X, _testPoint.X);
    }

    [Fact]
    public void ShouldMoveDown()
    {
        _testPoint.Move(RobotMovementDirection.Down);

        Assert.Equal(Y - 1, _testPoint.Y);
        Assert.Equal(X, _testPoint.X);
    }

    [Fact]
    public void ShouldMoveLeft()
    {
        _testPoint.Move(RobotMovementDirection.Left);

        Assert.Equal(Y, _testPoint.Y);
        Assert.Equal(X - 1, _testPoint.X);
    }

    [Fact]
    public void ShouldMoveRight()
    {
        _testPoint.Move(RobotMovementDirection.Right);

        Assert.Equal(Y, _testPoint.Y);
        Assert.Equal(X + 1, _testPoint.X);
    }

    [Fact]
    public void ShouldThrowIfIncorrectMovementDirectionPassed()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _testPoint.Move((RobotMovementDirection)(-1)));
    }
}