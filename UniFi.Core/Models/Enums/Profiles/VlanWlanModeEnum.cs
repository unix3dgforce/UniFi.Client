using System.Runtime.Serialization;

namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum VlanWlanModeEnum
{
    [EnumMember(Value = "disabled")]
    Disabled,
    
    [EnumMember(Value = "optional")]
    Optional,
}