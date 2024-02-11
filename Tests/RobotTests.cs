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
        _cleaningArea = new VisitableArea();
        _testRobot = new Robot(_initialPosition, _cleaningArea);
    }


    [Fact]
    public void ShouldBeCreatedWithTheInitialPosition()
    {
        Assert.Equal(InitialX, _initialPosition.X);
        Assert.Equal(InitialY, _initialPosition.Y);
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
        var command = new CleaningRobotCommand(RobotMovementDirection.Up, steps);

        _testRobot.Execute(command);

        Assert.Equal(InitialX, _initialPosition.X);
        Assert.Equal(InitialY + steps, _initialPosition.Y);
    }

    [Fact]
    public void ShouldIncreaseYMovingRight()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(RobotMovementDirection.Right, steps);

        _testRobot.Execute(command);

        Assert.Equal(InitialX + steps, _initialPosition.X);
        Assert.Equal(InitialY, _initialPosition.Y);
    }

    [Fact]
    public void ShouldDecreaseXMovingDown()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(RobotMovementDirection.Down, steps);

        _testRobot.Execute(command);

        Assert.Equal(InitialX, _initialPosition.X);
        Assert.Equal(InitialY - steps, _initialPosition.Y);
    }

    [Fact]
    public void ShouldDecreaseYMovingLeft()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(RobotMovementDirection.Left, steps);

        _testRobot.Execute(command);

        Assert.Equal(InitialX - steps, _initialPosition.X);
        Assert.Equal(InitialY, _initialPosition.Y);
    }

    [Fact]
    public void ShouldMoveTheRightAmountOfSteps()
    {
        const int steps = 3;
        var command = new CleaningRobotCommand(RobotMovementDirection.Up, steps);

        _testRobot.Execute(command);

        Assert.Equal(1 + steps, _initialPosition.Y);
    }

    [Fact]
    public void ShouldHaveCleanedTheProperAreaAfterExecuting()
    {
        const int steps = 3;
        var command = new CleaningRobotCommand(RobotMovementDirection.Up, steps);

        _testRobot.Execute(command);

        Assert.Equal(steps + 1, _testRobot.CleanedArea);
    }

    [Fact]
    public void ShouldNotCountAlreadyVisitedCellsAsCleaned()
    {
        _testRobot.Execute(new CleaningRobotCommand(RobotMovementDirection.Up, 1));
        _testRobot.Execute(new CleaningRobotCommand(RobotMovementDirection.Right, 1));
        _testRobot.Execute(new CleaningRobotCommand(RobotMovementDirection.Down, 1));
        _testRobot.Execute(new CleaningRobotCommand(RobotMovementDirection.Left, 1));
        _testRobot.Execute(new CleaningRobotCommand(RobotMovementDirection.Up, 1));

        Assert.Equal(4, _testRobot.CleanedArea);
    }
}