namespace UniFi.Core.Models;

public class DynamicDnsModel : BaseExtendModel
{
    public string Interface { get; set; }

    [CheckExist]
    public DynamicDnsProviderEnum? Service { get; set; }

    [JsonProperty(PropertyName = "host_name")]
    public string HostName { get; set; }

    [JsonProperty(PropertyName = "login")]
    public string Username { get; set; }

    [JsonProperty(PropertyName = "x_password")]
    public string Password { get; set; }

    public string Server { get; set; }
}