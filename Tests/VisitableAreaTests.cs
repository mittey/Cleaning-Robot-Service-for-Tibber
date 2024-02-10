using CleaningRobot.Positioning;

namespace Tests;

public class VisitableAreaTests
{
    private const int Width = 100, Height = 200;
    private readonly VisitableArea _testArea = new(Height, Width);

    [Fact]
    public void ShouldInitAGridWithTheProvidedDimensions()
    {
        Assert.Equal(Width, _testArea.Width);
        Assert.Equal(Height, _testArea.Height);
    }

    [Fact]
    public void ShouldInitAllCellsInGridAsNonVisited()
    {
        for (var x = 0; x < _testArea.Height; x++)
        for (var y = 0; y < _testArea.Width; y++)
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