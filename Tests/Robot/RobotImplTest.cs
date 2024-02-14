using CleaningRobot.Robot;
using CleaningRobot.Robot.Commands;
using CleaningRobot.Robot.Commands.Enums;
using CleaningRobot.Robot.Positioning;

namespace Tests.Robot;

public class RobotImplTest
{
    private const int InitialX = 1;
    private const int InitialY = 1;
    private readonly VisitableArea _cleaningArea;
    private readonly Point _initialPosition;

    private readonly RobotImpl _testRobotImpl;

    public RobotImplTest()
    {
        _initialPosition = new Point(InitialX, InitialY);
        _cleaningArea = new VisitableArea();
        _testRobotImpl = new RobotImpl(_initialPosition, _cleaningArea);
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
        Assert.Equal(1, _testRobotImpl.CleanedArea);
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

        _testRobotImpl.Execute(command);

        Assert.Equal(InitialX, _initialPosition.X);
        Assert.Equal(InitialY + steps, _initialPosition.Y);
    }

    [Fact]
    public void ShouldIncreaseYMovingRight()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(RobotMovementDirection.Right, steps);

        _testRobotImpl.Execute(command);

        Assert.Equal(InitialX + steps, _initialPosition.X);
        Assert.Equal(InitialY, _initialPosition.Y);
    }

    [Fact]
    public void ShouldDecreaseXMovingDown()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(RobotMovementDirection.Down, steps);

        _testRobotImpl.Execute(command);

        Assert.Equal(InitialX, _initialPosition.X);
        Assert.Equal(InitialY - steps, _initialPosition.Y);
    }

    [Fact]
    public void ShouldDecreaseYMovingLeft()
    {
        const int steps = 1;
        var command = new CleaningRobotCommand(RobotMovementDirection.Left, steps);

        _testRobotImpl.Execute(command);

        Assert.Equal(InitialX - steps, _initialPosition.X);
        Assert.Equal(InitialY, _initialPosition.Y);
    }

    [Fact]
    public void ShouldMoveTheRightAmountOfSteps()
    {
        const int steps = 3;
        var command = new CleaningRobotCommand(RobotMovementDirection.Up, steps);

        _testRobotImpl.Execute(command);

        Assert.Equal(1 + steps, _initialPosition.Y);
    }

    [Fact]
    public void ShouldHaveCleanedTheProperAreaAfterExecuting()
    {
        const int steps = 3;
        var command = new CleaningRobotCommand(RobotMovementDirection.Up, steps);

        _testRobotImpl.Execute(command);

        Assert.Equal(steps + 1, _testRobotImpl.CleanedArea);
    }

    [Fact]
    public void ShouldNotCountAlreadyVisitedCellsAsCleaned()
    {
        _testRobotImpl.Execute(new CleaningRobotCommand(RobotMovementDirection.Up, 1));
        _testRobotImpl.Execute(new CleaningRobotCommand(RobotMovementDirection.Right, 1));
        _testRobotImpl.Execute(new CleaningRobotCommand(RobotMovementDirection.Down, 1));
        _testRobotImpl.Execute(new CleaningRobotCommand(RobotMovementDirection.Left, 1));
        _testRobotImpl.Execute(new CleaningRobotCommand(RobotMovementDirection.Up, 1));

        Assert.Equal(4, _testRobotImpl.CleanedArea);
    }


    [Fact]
    public void ShouldBeAbleToRunOnABigSetOfCommandCommands()
    {
        var commands = new List<CleaningRobotCommand>();
        var directionIndex = 0;
        for (var i = 0; i < 10000; i++)
        {
            if (directionIndex == 4)
                directionIndex = 0;

            commands.Add(new CleaningRobotCommand((RobotMovementDirection)directionIndex++, 99999));
        }

        _testRobotImpl.Execute(commands);
    }
}