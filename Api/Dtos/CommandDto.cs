using System.Text.Json.Serialization;
using Api.Dtos.Enums;

namespace Api.Dtos;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed record CommandDto(
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    MovementDirection Direction,
    int Steps);