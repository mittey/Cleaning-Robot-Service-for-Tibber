using System.Text.Json.Serialization;

namespace Api.Dtos;

public record CommandDto(
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    MovementDirection Direction,
    int Steps);