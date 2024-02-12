namespace Api.Dtos;

// ReSharper disable once ClassNeverInstantiated.Global
public record ExecutionPlanDto(StartDto Start, IEnumerable<CommandDto> Commands);