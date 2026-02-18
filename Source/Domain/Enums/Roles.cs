using System.Text.Json.Serialization;

namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Roles
{
    INCOGNITO = 0,
    ADMINISTRATOR = 1,
    LEADER = 2,
    COLLABORATOR = 3,
}
