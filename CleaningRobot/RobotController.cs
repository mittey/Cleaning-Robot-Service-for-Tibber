using System.Diagnostics;
using CleaningRobot.Models;
using CleaningRobot.Positioning;

namespace CleaningRobot;

public static class RobotController
{
    public static ExecutionResult Execute(ExecutionPlan executionPlan)
    {
        var watch = Stopwatch.StartNew();

        const int twoHundredThousand = 2 * 1000;

        var cleaningArea = new VisitableArea(twoHundredThousand, twoHundredThousand);
        var cleaningRobot = new Robot(executionPlan.InitialPosition, cleaningArea);

        cleaningRobot.Execute(executionPlan.CommandSequence);

        watch.Stop();

        return new ExecutionResult(cleaningRobot.CleanedArea, watch.ElapsedMilliseconds);
    }
}