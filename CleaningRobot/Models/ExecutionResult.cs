// ReSharper disable NotAccessedPositionalProperty.Global

namespace CleaningRobot.Models;

public sealed record ExecutionResult(int AreaCleaned, int CommandsCount, long ExecutionTimeInMs);