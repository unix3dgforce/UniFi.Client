using System.Runtime.Serialization;

namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum OverrideModeEnum
{
    [EnumMember(Value = "on")]
    On,
    [EnumMember(Value = "off")]
    Off,
    [EnumMember(Value = "default")]
    Default
}