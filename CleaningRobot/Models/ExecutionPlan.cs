using CleaningRobot.Robot.Commands;
using CleaningRobot.Robot.Positioning;

namespace CleaningRobot.Models;

public sealed record ExecutionPlan(Point InitialPosition, IEnumerable<CleaningRobotCommand> CommandSequence);