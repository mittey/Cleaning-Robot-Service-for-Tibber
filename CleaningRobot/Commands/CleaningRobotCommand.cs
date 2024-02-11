using CleaningRobot.Commands.Enums;

namespace CleaningRobot.Commands;

public sealed record CleaningRobotCommand(RobotMovementDirection Direction, int Steps);