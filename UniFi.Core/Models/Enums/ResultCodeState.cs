namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum ResultCodeState
{
    Ok,
    Error,
}