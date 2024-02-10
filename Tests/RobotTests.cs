using CleaningRobot;
using CleaningRobot.Commands;
using CleaningRobot.Commands.Enums;
using CleaningRobot.Positioning;

namespace Tests;

public class RobotTests
{
    private const int InitialX = 1;
    private const int InitialY = 1;
    private readonly VisitableArea _cleaningArea;
    private readonly Point _initialPosition;

    private readonly Robot _testRobot;

    public RobotTests()
    {
        _initialPosition = new Point(InitialX, InitialY);
        _cleaningArea = new VisitableArea(100, 100);
        _testRobot = new Robot(_initialPosition, _cleaningArea);
    }


    [Fact]
    public void ShouldBeCreatedWithTheInitialPosition()
    {
        Assert.Equal(InitialX, _testRobot.Position.X);
        Assert.Equal(InitialY, _testRobot.Position.Y);
    }

    [Fact]
    public void ShouldHaveCleanedOneCellAfterCreation()
    {
        Assert.Equal(1, _testRobot.CleanedArea);
    }

    [Fact]
    public void ShouldVisitTheInitialPositionCellOnTheCleaningArea()
    {
        Assert.True(_cleaningArea.IsVisited(_initialPosition));
    }

    [Fact]
    public void ShouldIncreaseXMovingUp()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(MovementDirection.Up, steps);

        _testRobot.ExecuteCommand(command);

        Assert.Equal(InitialX, _testRobot.Position.X);
        Assert.Equal(InitialY + steps, _testRobot.Position.Y);
    }

    [Fact]
    public void ShouldIncreaseYMovingRight()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(MovementDirection.Right, steps);

        _testRobot.ExecuteCommand(command);

        Assert.Equal(InitialX + steps, _testRobot.Position.X);
        Assert.Equal(InitialY, _testRobot.Position.Y);
    }

    [Fact]
    public void ShouldDecreaseXMovingDown()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(MovementDirection.Down, steps);

        _testRobot.ExecuteCommand(command);

        Assert.Equal(InitialX, _testRobot.Position.X);
        Assert.Equal(InitialY - steps, _testRobot.Position.Y);
    }

    [Fact]
    public void ShouldDecreaseYMovingLeft()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(MovementDirection.Left, steps);

        _testRobot.ExecuteCommand(command);

        Assert.Equal(InitialX - steps, _testRobot.Position.X);
        Assert.Equal(InitialY, _testRobot.Position.Y);
    }

    [Fact]
    public void ShouldMoveTheRightAmountOfSteps()
    {
        const int steps = 3;
        var command = new CleaningRobotCommand(MovementDirection.Up, steps);

        _testRobot.ExecuteCommand(command);

        Assert.Equal(1 + steps, _testRobot.Position.Y);
    }

    [Fact]
    public void ShouldHaveCleanedTheProperAreaAfterExecuting()
    {
        const int steps = 3;
        var command = new CleaningRobotCommand(MovementDirection.Up, steps);

        _testRobot.ExecuteCommand(command);

        Assert.Equal(steps + 1, _testRobot.CleanedArea);
    }

    [Fact]
    public void ShouldNotCountAlreadyVisitedCellsAsCleaned()
    {
        _testRobot.ExecuteCommand(new CleaningRobotCommand(MovementDirection.Up, 1));
        _testRobot.ExecuteCommand(new CleaningRobotCommand(MovementDirection.Right, 1));
        _testRobot.ExecuteCommand(new CleaningRobotCommand(MovementDirection.Down, 1));
        _testRobot.ExecuteCommand(new CleaningRobotCommand(MovementDirection.Left, 1));
        _testRobot.ExecuteCommand(new CleaningRobotCommand(MovementDirection.Up, 1));

        Assert.Equal(4, _testRobot.CleanedArea);
    }
}