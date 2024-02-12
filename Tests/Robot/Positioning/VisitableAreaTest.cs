using CleaningRobot.Robot.Positioning;

namespace Tests.Robot.Positioning;

public class VisitableAreaTest
{
    private readonly VisitableArea _testArea = new();

    [Fact]
    public void ShouldInitAllCellsInGridAsNonVisited()
    {
        for (var x = 0; x < 5; x++)
        for (var y = 0; y < 10; y++)
            Assert.False(_testArea.IsVisited(new Point(x, y)));
    }

    [Fact]
    public void ShouldSetCellAsVisitedWhenVisitIsCalled()
    {
        var point = new Point(5, 6);
        Assert.False(_testArea.IsVisited(point));

        _testArea.Visit(point);

        Assert.True(_testArea.IsVisited(point));
    }

    [Fact]
    public void ShouldReturnTheProperAmountOfVisitedCells()
    {
        var pointToVisitTwoTimes = new Point(0, 0);

        Point[] pointsToVisit =
            [pointToVisitTwoTimes, new Point(0, 1), new Point(1, 0), new Point(1, 1), pointToVisitTwoTimes];

        foreach (var p in pointsToVisit)
            _testArea.Visit(p);

        Assert.Equal(
            // The duplicate point should only be counted once.
            pointsToVisit.Length - 1,
            _testArea.VisitedCount);
    }
}