namespace CleaningRobot.Positioning;

public class Cell
{
    public bool Visited { get; private set; }

    public void Visit()
    {
        Visited = true;
    }
}