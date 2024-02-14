using System.Numerics;
using CleaningRobot.Robot.Positioning;

namespace Tests.Robot.Positioning;

public class LineSweeperTest
{
    [Fact]
    public void ShouldNotCountEdgeAsIntersection()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 0), new Vector2(1, 5), LineSweeper.LineEventType.Vertical),

            new(new Vector2(1, 5), new Vector2(5, 5), LineSweeper.LineEventType.Start),
            new(new Vector2(5, 5), new Vector2(1, 5), LineSweeper.LineEventType.End)
        };

        var intersectionsCount = LineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(0, intersectionsCount);
    }

    [Fact]
    public void ShouldCountSingleIntersection()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 0), new Vector2(1, 5), LineSweeper.LineEventType.Vertical),

            new(new Vector2(0, 2), new Vector2(5, 2), LineSweeper.LineEventType.Start),
            new(new Vector2(5, 2), new Vector2(0, 2), LineSweeper.LineEventType.End)
        };

        var intersectionsCount = LineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(1, intersectionsCount);
    }

    [Fact]
    public void ShouldCountMultipleIntersectionsWithOneLine()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 0), new Vector2(1, 5), LineSweeper.LineEventType.Vertical),

            new(new Vector2(0, 2), new Vector2(5, 2), LineSweeper.LineEventType.Start),
            new(new Vector2(5, 2), new Vector2(0, 2), LineSweeper.LineEventType.End),
            new(new Vector2(0, 3), new Vector2(5, 3), LineSweeper.LineEventType.Start),
            new(new Vector2(5, 3), new Vector2(0, 3), LineSweeper.LineEventType.End)
        };

        var intersectionsCount = LineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(2, intersectionsCount);
    }

    [Fact]
    public void ShouldNotCountSingleHorizontalLineAsIntersection()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 5), new Vector2(5, 5), LineSweeper.LineEventType.Start),
            new(new Vector2(5, 5), new Vector2(1, 5), LineSweeper.LineEventType.End)
        };

        var intersectionsCount = LineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(0, intersectionsCount);
    }

    [Fact]
    public void ShouldNotSingleVerticalLineAsIntersection()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 0), new Vector2(1, 5), LineSweeper.LineEventType.Vertical)
        };

        var intersectionsCount = LineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(0, intersectionsCount);
    }
}