namespace UniFi.Core.Models;

public class RadiusAccountModel : BaseExtendModel
{
    public int Vlan { get; set; }

    [JsonProperty(PropertyName = "x_password")]
    public string Password { get; set; }
}