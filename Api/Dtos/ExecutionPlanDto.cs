namespace Api.Dtos;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed record ExecutionPlanDto(StartDto Start, IEnumerable<CommandDto> Commands);