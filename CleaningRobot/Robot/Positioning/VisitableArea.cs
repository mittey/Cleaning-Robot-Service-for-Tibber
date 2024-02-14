// ReSharper disable NotAccessedPositionalProperty.Global

using System.Numerics;

namespace CleaningRobot.Robot.Positioning;

internal static class PointExtensions
{
    public static Vector2 ToVector(this Point p)
    {
        return new Vector2(p.X, p.Y);
    }
}

public class VisitableArea
{
    private readonly HashSet<Vector2> _visited = [];

    public int VisitedCount => _visited.Count;

    public void Visit(Point p)
    {
        _visited.Add(p.ToVector());
    }

    public bool IsVisited(Point p)
    {
        return _visited.Contains(p.ToVector());
    }
}