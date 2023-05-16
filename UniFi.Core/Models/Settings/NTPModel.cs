namespace UniFi.Core.Models;

public class NTPModel : BaseExtendModel
{
    public string Key { get; set; }
    
    [JsonProperty(PropertyName = "ntp_server_1")]
    public string NtpServer1 { get; set; }
    
    [JsonProperty(PropertyName = "ntp_server_2")]
    public string NtpServer2 { get; set; }
    
    [JsonProperty(PropertyName = "ntp_server_3")]
    public string NtpServer3 { get; set; }
    
    [JsonProperty(PropertyName = "ntp_server_4")]
    public string NtpServer4 { get; set; }
    
    [JsonProperty(PropertyName = "setting_preference")]
    public SettingPreferenceEnum SettingPreference { get; set; }
}