using System.Diagnostics;
using CleaningRobot.Models;
using CleaningRobot.Positioning;

namespace CleaningRobot;

public static class RobotController
{
    public static ExecutionResult Execute(ExecutionPlan executionPlan)
    {
        var watch = Stopwatch.StartNew();


        var cleaningArea = new VisitableArea();
        var cleaningRobot = new Robot(executionPlan.InitialPosition, cleaningArea);

        cleaningRobot.Execute(executionPlan.CommandsSequence);

        watch.Stop();

        return new ExecutionResult(cleaningRobot.CleanedArea, watch.ElapsedMilliseconds);
    }
}