using System.Numerics;

namespace CleaningRobot.Robot.Positioning;

public abstract class LineSweeper
{
    public enum LineEventType
    {
        Start,
        Vertical,
        End
    }


    // This is my implementation of the Bentley Ottmann (line intersection) algorithm.
    public static int GetIntersectionsCount(IEnumerable<LineEvent> events)
    {
        var sortedEvents = events.OrderBy(e => e.P1.X);
        var currentIntersections = new HashSet<Vector2>();
        var intersectionsCount = 0;

        foreach (var lineEvent in sortedEvents)
            switch (lineEvent.Type)
            {
                case LineEventType.Start:
                    currentIntersections.Add(lineEvent.P1);
                    break;

                case LineEventType.End:
                    currentIntersections.Remove(lineEvent.P2);
                    break;

                case LineEventType.Vertical:
                default:
                    // Include only intersections with sections that are in range of the "vertical" section.
                    intersectionsCount +=
                        currentIntersections.Count(p => lineEvent.P1.Y <= p.Y && p.Y <= lineEvent.P2.Y);
                    break;
            }

        return intersectionsCount;
    }

    public record LineEvent(Vector2 P1, Vector2 P2, LineEventType Type);
}