using CleaningRobot.Robot.Commands.Enums;

namespace CleaningRobot.Robot.Commands;

public sealed record CleaningRobotCommand(RobotMovementDirection Direction, int Steps);