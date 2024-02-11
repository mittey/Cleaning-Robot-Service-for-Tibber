namespace CleaningRobot.Positioning;

internal record struct GridKey(int X, int Y);

public class VisitableArea
{
    private readonly Dictionary<GridKey, bool> _grid2 = new();

    public int VisitedCount { get; private set; }

    public void Visit(Point p)
    {
        var key = new GridKey(p.X, p.Y);

        if (_grid2.TryGetValue(key, out var isVisited) && isVisited) return;

        VisitedCount++;
        _grid2[key] = true;
    }

    public bool IsVisited(Point p)
    {
        var key = new GridKey(p.X, p.Y);
        _grid2.TryAdd(key, false);

        return _grid2[key];
    }
}