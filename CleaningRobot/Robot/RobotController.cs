using System.Diagnostics;
using CleaningRobot.Models;

namespace CleaningRobot.Robot;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class RobotController
{
    public virtual ExecutionResult Execute(ExecutionPlan executionPlan)
    {
        // Measure execution time.
        var watch = Stopwatch.StartNew();

        var cleaningRobot = RobotFactory.CreateRobot(executionPlan.InitialPosition);
        cleaningRobot.Execute(executionPlan.CommandSequence);

        watch.Stop();

        return new ExecutionResult(cleaningRobot.CleanedArea, watch.ElapsedMilliseconds);
    }
}