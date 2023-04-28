namespace UniFi.Core.Models;

public class SiteModel : BaseModel
{
    /// <summary>
    /// Unique identifier of the site
    /// </summary>
    [JsonProperty(PropertyName = "_id")]
    public string Id { get; set; }
    
    /// <summary>
    /// Unique anonymous identifier of the site
    /// </summary>
    [JsonProperty(PropertyName = "anonymous_id")]
    public Guid AnonymousId { get; set; }
    
    /// <summary>
    /// Name of the site
    /// </summary>
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    
    /// <summary>
    /// Description of the site
    /// </summary>
    [JsonProperty(PropertyName = "desc")]
    public string Description { get; set; }

    /// <summary>
    /// Internal identifier of the site
    /// </summary>
    [JsonProperty(PropertyName = "attr_hidden_id")]
    public string HiddenId { get; set; }

    /// <summary>
    /// Boolean indicating if deletion of this site is being disallowed
    /// </summary>
    [JsonProperty(PropertyName = "attr_no_delete")]
    public bool? DontAllowDeletion { get; set; }

    /// <summary>
    /// Role of the site? Seems to be admin in my testable scenarios.
    /// </summary>
    [JsonProperty(PropertyName = "role")]
    public string Role { get; set; }
    
    [JsonProperty(PropertyName = "role_hotspot")]
    public bool? RoleHotspot { get; set; }
}