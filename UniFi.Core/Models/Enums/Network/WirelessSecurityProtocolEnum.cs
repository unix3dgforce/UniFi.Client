using System.Runtime.Serialization;

namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum WirelessSecurityProtocolEnum
{
    [EnumMember(Value = "open")]
    Open,
    
    [EnumMember(Value = "wpapsk")]
    WpaPSK,
    
    [EnumMember(Value = "wpaeap")]
    WpaEAP
}