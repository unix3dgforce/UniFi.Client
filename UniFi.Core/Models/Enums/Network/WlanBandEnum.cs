using System.Runtime.Serialization;

namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum WlanBandEnum
{
    [EnumMember(Value = "both")]
    Both,
    
    [EnumMember(Value = "2g")]
    GHz2,
    
    [EnumMember(Value = "5g")]
    GHz5
}