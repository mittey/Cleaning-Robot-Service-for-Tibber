using System.Numerics;

namespace CleaningRobot.Robot.Positioning;

public class LineSweeper
{
    public enum EventType
    {
        Start,
        Vertical,
        End
    }


    // This is my implementation of the Bentley Ottmann Algorithm.
    public int GetIntersectionsCount(IEnumerable<LineEvent> events)
    {
        var sortedEvents = events.OrderBy(e => e.P1.X);
        var currentSections = new HashSet<Vector2>();
        var intersectionsCount = 0;

        foreach (var lineEvent in sortedEvents)
            switch (lineEvent.Type)
            {
                case EventType.Start:
                    currentSections.Add(lineEvent.P1);
                    break;

                case EventType.End:
                    currentSections.Remove(lineEvent.P2);
                    break;

                case EventType.Vertical:
                default:
                    // Include only intersections with sections that are in range of the "vertical" section.
                    intersectionsCount += currentSections.Count(p => lineEvent.P1.Y <= p.Y && p.Y <= lineEvent.P2.Y);
                    break;
            }

        return intersectionsCount;
    }

    public record LineEvent(Vector2 P1, Vector2 P2, EventType Type);
}