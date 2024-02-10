namespace CleaningRobot.Positioning;

public class VisitableArea
{
    private readonly Cell[,] _grid;

    public VisitableArea(int height, int width)
    {
        _grid = new Cell[height, width];

        for (var i = 0; i < _grid.GetLength(0); i++)
        for (var j = 0; j < _grid.GetLength(1); j++)
            _grid[i, j] = new Cell();
    }

    public int Height => _grid.GetLength(0);
    public int Width => _grid.GetLength(1);

    public int VisitedCount { get; private set; }

    public void Visit(Point p)
    {
        if (_grid[p.X, p.Y].Visited) return;

        VisitedCount++;
        _grid[p.X, p.Y].Visit();
    }

    public bool IsVisited(Point p)
    {
        return _grid[p.X, p.Y].Visited;
    }
}