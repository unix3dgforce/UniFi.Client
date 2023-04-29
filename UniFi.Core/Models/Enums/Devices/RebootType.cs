namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum RebootType
{
    Soft,
    Hard
}