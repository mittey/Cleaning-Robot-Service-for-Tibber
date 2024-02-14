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
    private readonly HashSet<GridKey> _visited = [];

    public int VisitedCount => _visited.Count;

    public void Visit(Point p)
    {
        _visited.Add(p.ToGridKey());
    }

    public bool IsVisited(Point p)
    {
        return _visited.Contains(p.ToGridKey());
    }
}