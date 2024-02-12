// ReSharper disable NotAccessedPositionalProperty.Global

namespace CleaningRobot.Robot.Positioning;

internal readonly record struct GridKey(int X, int Y);

internal static class GridKeyExtensions
{
    public static GridKey ToGridKey(this Point p)
    {
        return new GridKey(p.X, p.Y);
    }
}

public class VisitableArea
{
    private readonly Dictionary<GridKey, bool> _grid = new();

    public int VisitedCount { get; private set; }

    public void Visit(Point p)
    {
        var key = p.ToGridKey();
        if (_grid.TryGetValue(key, out var isVisited) && isVisited) return;

        VisitedCount++;
        _grid[key] = true;
    }

    public bool IsVisited(Point p)
    {
        var key = p.ToGridKey();
        _grid.TryAdd(key, false);

        return _grid[key];
    }
}