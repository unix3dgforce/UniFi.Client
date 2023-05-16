using System.Runtime.Serialization;

namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum DynamicDnsProviderEnum
{
    [EnumMember(Value = "afraid")]
    Afraid,
    
    [EnumMember(Value = "dnspark")]
    Dnspark,
    
    [EnumMember(Value = "dslreports")]
    Dslreports,
    
    [EnumMember(Value = "dyndns")]
    Dyndns,
    
    [EnumMember(Value = "easydns")]
    Easydns,
    
    [EnumMember(Value = "namecheap")]
    Namecheap,
    
    [EnumMember(Value = "noip")]
    Noip,
    
    [EnumMember(Value = "sitelutions")]
    Sitelutions,
    
    [EnumMember(Value = "zoneedit")]
    Zoneedit
}