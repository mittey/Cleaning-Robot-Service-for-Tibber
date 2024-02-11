using CleaningRobot.Commands;
using CleaningRobot.Positioning;

namespace CleaningRobot.Models;

public sealed record ExecutionPlan(Point InitialPosition, IEnumerable<CleaningRobotCommand> CommandsSequence);