namespace UniFi.Core.Models;

public class WirelessNetworkModel : BaseExtendModel
{
    /// <summary>
    /// Name of the network
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Is this network guest
    /// </summary>
    [JsonProperty(PropertyName = "is_guest")]
    public bool IsGuest { get; set; }

    /// <summary>
    /// Is this network enabled?
    /// </summary>
    [JsonProperty(PropertyName = "enabled")]
    public bool IsEnabled { get; set; }
    
    /// <summary>
    /// Is this SSID hidden?
    /// </summary>
    [JsonProperty(PropertyName = "hide_ssid")]
    public bool IsSSIDHidden { get; set; }
    
    /// <summary>
    /// Id of network configuration
    /// </summary>
    [JsonProperty(PropertyName = "networkconf_id")]
    public string NetworkConfigurationId { get; set; }
    
    /// <summary>
    /// Id of user group
    /// </summary>
    [JsonProperty(PropertyName = "usergroup_id")]
    public string UserGroupId { get; set; }
    
    /// <summary>
    /// Id of the RADIUS Profile
    /// </summary>
    [JsonProperty(PropertyName = "radiusprofile_id")]
    public string RadiusProfileId { get; set; }
    
    /// <summary>
    /// Ap Group IDS
    /// </summary>
    [JsonProperty(PropertyName = "ap_group_ids")]
    public IList<string> ApGroupIds { get; set; }
    
    /// <summary>
    /// Current wlan band
    /// </summary>
    [JsonProperty(PropertyName = "wlan_band")]
    public WlanBandEnum WlanBand { get; set; }
    
    /// <summary>
    /// List of wlan bands
    /// </summary>
    [JsonProperty(PropertyName = "wlan_bands")]
    public IList<WlanBandEnum> WlanBands { get; set; }
    
    /// <summary>
    /// Security protocol OPEN | WPAPSK | WPAEAP 
    /// </summary>
    [JsonProperty(PropertyName = "security")]
    public WirelessSecurityProtocolEnum Security { get; set; }
}