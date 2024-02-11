namespace Api.Dtos;

public record ExecutionPlanDto(StartDto Start, IEnumerable<CommandDto> Commands);