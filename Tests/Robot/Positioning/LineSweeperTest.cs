using System.Numerics;
using CleaningRobot.Robot.Positioning;
using Xunit.Abstractions;

namespace Tests.Robot.Positioning;

public class LineSweeperTest
{
    private readonly LineSweeper _lineSweeper = new();

    [Fact]
    public void ShouldNotCountEdgeAsIntersection()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 0), new Vector2(1, 5), LineSweeper.EventType.Vertical),

            new(new Vector2(1, 5), new Vector2(5, 5), LineSweeper.EventType.Start),
            new(new Vector2(5, 5), new Vector2(1, 5), LineSweeper.EventType.End)
        };

        var intersectionsCount = _lineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(0, intersectionsCount);
    }

    [Fact]
    public void ShouldCountSingleIntersection()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 0), new Vector2(1, 5), LineSweeper.EventType.Vertical),

            new(new Vector2(0, 2), new Vector2(5, 2), LineSweeper.EventType.Start),
            new(new Vector2(5, 2), new Vector2(0, 2), LineSweeper.EventType.End)
        };

        var intersectionsCount = _lineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(1, intersectionsCount);
    }

    [Fact]
    public void ShouldCountMultipleIntersectionsWithOneLine()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 0), new Vector2(1, 5), LineSweeper.EventType.Vertical),

            new(new Vector2(0, 2), new Vector2(5, 2), LineSweeper.EventType.Start),
            new(new Vector2(5, 2), new Vector2(0, 2), LineSweeper.EventType.End),
            new(new Vector2(0, 3), new Vector2(5, 3), LineSweeper.EventType.Start),
            new(new Vector2(5, 3), new Vector2(0, 3), LineSweeper.EventType.End)
        };

        var intersectionsCount = _lineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(2, intersectionsCount);
    }

    [Fact]
    public void ShouldNotCountSingleHorizontalLineAsIntersection()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 5), new Vector2(5, 5), LineSweeper.EventType.Start),
            new(new Vector2(5, 5), new Vector2(1, 5), LineSweeper.EventType.End)
        };

        var intersectionsCount = _lineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(0, intersectionsCount);
    }

    [Fact]
    public void ShouldNotSingleVerticalLineAsIntersection()
    {
        var sections = new LineSweeper.LineEvent[]
        {
            new(new Vector2(1, 0), new Vector2(1, 5), LineSweeper.EventType.Vertical),
        };

        var intersectionsCount = _lineSweeper.GetIntersectionsCount(sections);
        Assert.Equal(0, intersectionsCount);
    }
}