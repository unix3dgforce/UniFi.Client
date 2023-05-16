using System.Runtime.Serialization;

namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum FirewallGroupType
{
    [EnumMember(Value = "address-group")]
    AddressGroupIpV4,
    
    [EnumMember(Value = "ipv6-address-group")]
    AddressGroupIpV6,
    
    [EnumMember(Value = "port-group")]
    PortGroup
}