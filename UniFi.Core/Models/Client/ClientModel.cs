namespace UniFi.Core.Models;

public class ClientModel : BaseExtendModel
{
    [JsonProperty(PropertyName = "_id")] 
    public string Id { get; set; }
    
    /// <summary>
    /// The MAC Address of the client device
    /// </summary>
    [JsonProperty(PropertyName = "mac")]
    public string MacAddress { get; set; }
    
    /// <summary>
    /// Identifier of the site in UniFi to which this client is connected
    /// </summary>
    [JsonProperty(PropertyName = "site_id")]
    public string SiteId { get; set; }
    
    /// <summary>
    /// Hardware Vendor 
    /// </summary>
    [JsonProperty(PropertyName = "oui")]
    public string Vendor { get; set; }
    
    /// <summary>
    /// Boolean indicating if the client is logged in through a guest portal
    /// </summary>
    [JsonProperty(PropertyName = "is_guest")]
    public bool? IsGuest { get; set; }
}