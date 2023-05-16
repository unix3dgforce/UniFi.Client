namespace UniFi.Core.Models;

public class RadiusCredentialModel
{
    public string Ip { get; set; }
    public int Port { get; set; }

    [JsonProperty(PropertyName = "x_secret")]
    public string Password { get; set; }
}