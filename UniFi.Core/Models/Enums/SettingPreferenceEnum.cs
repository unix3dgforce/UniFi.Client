using System.Runtime.Serialization;

namespace UniFi.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum SettingPreferenceEnum
{
    [EnumMember(Value = "auto")]
    Auto,
    [EnumMember(Value = "manual")]
    Manual
}