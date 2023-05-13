namespace UniFi.Core.Models;

public class RadiusUserModel : BaseExtendModel
{
    [Required]
    [CheckExist]
    [JsonProperty(PropertyName = "name")]
    public string Username { get; set; }

    [Required]
    [JsonProperty(PropertyName = "x_password")]
    public string Password { get; set; }
    [Required]
    public int Vlan { get; set; }
    public TunnelTypeEnum? TunnelType { get; set; }
    public TunnelMediumTypeEnum? TunnelMediumType { get; set; }
}